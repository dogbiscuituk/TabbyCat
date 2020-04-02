namespace TabbyCat.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using TabbyCat.MvcControllers;
    using TabbyCat.MvcModels;
    using TabbyCat.MvcViews;

    internal class CommandProcessor
    {
        #region Public/Internal Interface

        internal CommandProcessor(WorldController worldController)
        {
            WorldController = worldController;
            WorldForm.EditUndo.Click += EditUndo_Click;
            WorldForm.tbUndo.ButtonClick += EditUndo_Click;
            WorldForm.tbUndo.DropDownOpening += TbUndo_DropDownOpening;
            WorldForm.EditRedo.Click += EditRedo_Click;
            WorldForm.tbRedo.ButtonClick += EditRedo_Click;
            WorldForm.tbRedo.DropDownOpening += TbRedo_DropDownOpening;
        }

        internal bool IsModified => LastSave != UndoStack.Count;
        internal Scene Scene => WorldController.Scene;
        internal List<Trace> Traces => Scene.Traces;

        internal void Clear()
        {
            LastSave = 0;
            UndoStack.Clear();
            RedoStack.Clear();
            UpdateUI();
        }

        internal void AppendTrace() => Run(new TraceInsertCommand(Traces.Count));
        internal void DeleteTrace(int index) => Run(new TraceDeleteCommand(index));
        internal void InsertTrace(int index) => Run(new TraceInsertCommand(index));

        /// <summary>
        /// Run a command, pushing its memento on to the Undo stack.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <returns>True if the command actually caused a property change.</returns>
        public bool Run(ICommand command)
        {
            if (command == null)
                return false;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            return Redo(command);
        }

        public void Save()
        {
            LastSave = UndoStack.Count;
            UpdateUI();
        }

        #endregion

        #region Private Properties

        private bool CanUndo => UndoStack.Count > 0;
        private bool CanRedo => RedoStack.Count > 0;

        private readonly Stack<ICommand> UndoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> RedoStack = new Stack<ICommand>();

        private string UndoAction => UndoStack.Peek().UndoAction;
        private string RedoAction => RedoStack.Peek().RedoAction;

        private readonly WorldController WorldController;
        private WorldForm WorldForm => WorldController.WorldForm;

        private int LastSave, UpdateCount;

        #endregion

        #region Private Event Handlers

        private void EditUndo_Click(object sender, EventArgs e) => Undo();
        private void TbUndo_DropDownOpening(object sender, EventArgs e) => Copy(UndoStack, WorldForm.tbUndo, UndoMultiple);
        private void EditRedo_Click(object sender, EventArgs e) => Redo();
        private void TbRedo_DropDownOpening(object sender, EventArgs e) => Copy(RedoStack, WorldForm.tbRedo, RedoMultiple);
        private static void UndoRedoItems_MouseEnter(object sender, EventArgs e) => HighlightUndoRedoItems((ToolStripItem)sender);
        private static void UndoRedoItems_Paint(object sender, PaintEventArgs e) => HighlightUndoRedoItems((ToolStripItem)sender);

        private void RedoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Redo(); while (UndoStack.Peek() != peek);
            EndUpdate();
        }

        private void UndoMultiple(object sender, EventArgs e)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            do Undo(); while (RedoStack.Peek() != peek);
            EndUpdate();
        }

        #endregion

        #region Private Methods

        private void BeginUpdate() { ++UpdateCount; }

        private bool CanGroup(ICommand cmd1, ICommand cmd2)
        {
            if (cmd2 is ICollectionCommand)
                return false;
            if (cmd1.GetType() == cmd2.GetType())
                switch (cmd1)
                {
                    case IScenePropertyCommand _: return true;
                    case ITracePropertyCommand tpc1: return tpc1.Index == ((ITracePropertyCommand)cmd2).Index;
                }
            else if (cmd1 is ICollectionCommand cc1 && !cc1.Adding)
                switch (cc1)
                {
                    case ITracesCommand tc1:
                        if (cmd2 is ITracePropertyCommand tpc2 && tpc2.Index == tc1.Index)
                        {
                            if (tc1.Value == null) tc1.Value = Scene.Traces[tc1.Index];
                            return true;
                        }
                        break;
                }
            return false;
        }

        private void Copy(Stack<ICommand> source, ToolStripDropDownItem target, EventHandler handler)
        {
            const int MaxItems = 20;
            var commands = source.ToArray();
            var items = target.DropDownItems;
            items.Clear();
            for (int n = 0; n < Math.Min(commands.Length, MaxItems); n++)
            {
                var command = commands[n];
                var item = items.Add(command.ToString(), null, handler);
                item.Tag = command;
                item.MouseEnter += UndoRedoItems_MouseEnter;
                item.Paint += UndoRedoItems_Paint;
            }
        }

        private void EndUpdate()
        {
            if (--UpdateCount == 0)
                UpdateUI();
        }

        private static void HighlightUndoRedoItems(ToolStripItem activeItem)
        {
            if (!activeItem.Selected)
                return;
            var items = activeItem.GetCurrentParent().Items;
            var index = items.IndexOf(activeItem);
            foreach (ToolStripItem item in items)
                item.BackColor = Color.FromKnownColor(items.IndexOf(item) <= index
                    ? KnownColor.GradientActiveCaption
                    : KnownColor.Control);
        }

        private bool Redo() => CanRedo && Redo(RedoStack.Pop());

        private bool Redo(ICommand command)
        {
            if (!command.Do(Scene))
                return false;
            if (!(CanUndo && CanGroup(UndoStack.Peek(), command)))
                UndoStack.Push(command);
            UpdateUI();
            return true;
        }

        private bool Undo() => CanUndo && Undo(UndoStack.Pop());

        private bool Undo(ICommand command)
        {
            if (!command.Do(Scene))
                return false;
            RedoStack.Push(command);
            UpdateUI();
            return true;
        }

        private void UpdateUI()
        {
            if (UpdateCount > 0)
                return;
            string
                undo = CanUndo ? $"Undo {UndoAction}" : "Undo",
                redo = CanRedo ? $"Redo {RedoAction}" : "Redo";
            WorldForm.EditUndo.Enabled = WorldForm.tbUndo.Enabled = CanUndo;
            WorldForm.EditRedo.Enabled = WorldForm.tbRedo.Enabled = CanRedo;
            WorldForm.EditUndo.Text = $"&{undo}";
            WorldForm.EditRedo.Text = $"&{redo}";
            WorldForm.tbUndo.ToolTipText = $"{undo} (^Z)";
            WorldForm.tbRedo.ToolTipText = $"{redo} (^Y)";
            WorldController.ModifiedChanged();
        }

        #endregion
    }
}
