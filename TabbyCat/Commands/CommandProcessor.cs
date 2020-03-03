namespace TabbyCat.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using TabbyCat.Controllers;
    using TabbyCat.Models;
    using TabbyCat.Views;

    internal class CommandProcessor
    {
        #region Public/Internal Interface

        internal CommandProcessor(SceneController sceneController)
        {
            SceneController = sceneController;
            SceneForm.EditUndo.Click += EditUndo_Click;
            SceneForm.tbUndo.ButtonClick += EditUndo_Click;
            SceneForm.tbUndo.DropDownOpening += TbUndo_DropDownOpening;
            SceneForm.EditRedo.Click += EditRedo_Click;
            SceneForm.tbRedo.ButtonClick += EditRedo_Click;
            SceneForm.tbRedo.DropDownOpening += TbRedo_DropDownOpening;
        }

        internal bool IsModified => LastSave != UndoStack.Count;
        internal Scene Scene => SceneController.Scene;
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
        /// <param name="spoof">A flag indicating whether the command should actually be run. 
        /// If true, the command should be run as normal. 
        /// If false, the relevant properties have already been changed on the target, 
        /// so just log the memento to the Undo stack.</param>
        /// <returns>True if the command was run, and actually caused a property change.</returns>
        public bool Run(ICommand command, bool spoof = false)
        {
            if (command == null)
                return false;
            if (LastSave > UndoStack.Count)
                LastSave = -1;
            RedoStack.Clear();
            return Redo(command, spoof);
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

        private readonly SceneController SceneController;
        private SceneForm SceneForm => SceneController.SceneForm;

        private int LastSave, UpdateCount;

        #endregion

        #region Private Event Handlers

        private void EditUndo_Click(object sender, EventArgs e) => Undo();
        private void TbUndo_DropDownOpening(object sender, EventArgs e) => Copy(UndoStack, SceneForm.tbUndo, UndoMultiple);
        private void EditRedo_Click(object sender, EventArgs e) => Redo();
        private void TbRedo_DropDownOpening(object sender, EventArgs e) => Copy(RedoStack, SceneForm.tbRedo, RedoMultiple);
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

        private bool Redo(ICommand command, bool spoof = false)
        {
            var result = spoof || command.Do(Scene);
            if (result)
            {
                UndoStack.Push(command);
                UpdateUI();
            }
            return result;
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
            SceneForm.EditUndo.Enabled = SceneForm.tbUndo.Enabled = CanUndo;
            SceneForm.EditRedo.Enabled = SceneForm.tbRedo.Enabled = CanRedo;
            SceneForm.EditUndo.Text = $"&{undo}";
            SceneForm.EditRedo.Text = $"&{redo}";
            SceneForm.tbUndo.ToolTipText = $"{undo} (^Z)";
            SceneForm.tbRedo.ToolTipText = $"{redo} (^Y)";
            SceneController.ModifiedChanged();
        }

        #endregion
    }
}
