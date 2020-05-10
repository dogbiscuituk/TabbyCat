namespace TabbyCat.Controllers
{
    using Commands;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class CommandCon : LocalizationCon
    {
        // Constructors

        public CommandCon(WorldCon worldCon) : base(worldCon) { }

        // Private fields

        private int
            _lastSave,
            _updateCount;

        private readonly Stack<ICommand>
            _undoStack = new Stack<ICommand>(),
            _redoStack = new Stack<ICommand>();

        // Public properties

        public bool IsModified => _lastSave != _undoStack.Count;

        // Private properties

        private bool CanUndo => _undoStack.Count > 0;
        private bool CanRedo => _redoStack.Count > 0;

        private string UndoAction => _undoStack.Peek().UndoAction;
        private string RedoAction => _redoStack.Peek().RedoAction;

        private List<Signal> Signals => Scene.Signals;
        private List<Trace> Traces => Scene.Traces;

        // Public methods

        public void AppendSignal(Signal signal = null) => Run(new SignalInsertCommand(Signals.Count, signal));

        public void AppendTrace(Trace trace = null) => Run(new TraceInsertCommand(Traces.Count, trace));

        public void Clear()
        {
            _lastSave = 0;
            _undoStack.Clear();
            _redoStack.Clear();
            UpdateUI();
        }

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.EditUndo.Click += EditUndo_Click;
                WorldForm.tbUndo.ButtonClick += EditUndo_Click;
                WorldForm.tbUndo.DropDownOpening += TbUndo_DropDownOpening;
                WorldForm.EditRedo.Click += EditRedo_Click;
                WorldForm.tbRedo.ButtonClick += EditRedo_Click;
                WorldForm.tbRedo.DropDownOpening += TbRedo_DropDownOpening;
            }
            else
            {
                WorldForm.EditUndo.Click -= EditUndo_Click;
                WorldForm.tbUndo.ButtonClick -= EditUndo_Click;
                WorldForm.tbUndo.DropDownOpening -= TbUndo_DropDownOpening;
                WorldForm.EditRedo.Click -= EditRedo_Click;
                WorldForm.tbRedo.ButtonClick -= EditRedo_Click;
                WorldForm.tbRedo.DropDownOpening -= TbRedo_DropDownOpening;
            }
        }

        public void DeleteTrace(int index) => Run(new TraceDeleteCommand(index));

        /// <summary>
        /// Run a command, pushing its memento on to the Undo stack.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <returns>True if the command actually caused a property change.</returns>
        public void Save()
        {
            _lastSave = _undoStack.Count;
            UpdateUI();
        }

        // Protected methods

        protected override bool Run(ICommand command)
        {
            if (command == null)
                return false;
            if (_lastSave > _undoStack.Count)
                _lastSave = -1;
            _redoStack.Clear();
            return Redo(command);
        }

        // Private methods

        private void BeginUpdate() => ++_updateCount;

        private bool CanGroup(ICommand cmd1, ICommand cmd2)
        {
            if (cmd2 is ICollectionCommand)
                return false;
            if (cmd1.GetType() == cmd2.GetType())
                switch (cmd1)
                {
                    case IScenePropertyCommand _:
                        return true;
                    case ISignalPropertyCommand spc1:
                        return spc1.Index == ((ISignalPropertyCommand)cmd2).Index;
                    case ITracePropertyCommand tpc1:
                        return tpc1.Index == ((ITracePropertyCommand)cmd2).Index;
                }
            else if (cmd1 is ICollectionCommand cc1 && !cc1.Adding)
                switch (cc1)
                {
                    case ISignalCollectionCommand sc1:
                        if (cmd2 is ISignalPropertyCommand spc2 && spc2.Index == sc1.Index)
                        {
                            if (sc1.Value == null)
                                sc1.Value = Scene.Signals[sc1.Index];
                            return true;
                        }
                        break;
                    case ITraceCollectionCommand tc1:
                        if (cmd2 is ITracePropertyCommand tpc2 && tpc2.Index == tc1.Index)
                        {
                            if (tc1.Value == null)
                                tc1.Value = Scene.Traces[tc1.Index];
                            return true;
                        }
                        break;
                }
            return false;
        }

        private void DoMultiple(object sender, Stack<ICommand> stack, Action act)
        {
            BeginUpdate();
            var peek = ((ToolStripItem)sender).Tag;
            bool more;
            do
            {
                more = stack.Peek() != peek;
                act();
            }
            while (more);
            EndUpdate();
        }

        private void EditRedo_Click(object sender, EventArgs e) => Redo();

        private void EditUndo_Click(object sender, EventArgs e) => Undo();

        private void EndUpdate()
        {
            if (--_updateCount == 0)
                UpdateUI();
        }

        private bool Redo() => CanRedo && Redo(_redoStack.Pop());

        private bool Redo(ICommand command)
        {
            if (!command.Do(Scene))
                return false;
            if (!(CanUndo && CanGroup(_undoStack.Peek(), command)))
                _undoStack.Push(command);
            UpdateUI();
            return true;
        }

        private void RedoMultiple(object sender, EventArgs e) => DoMultiple(sender, _redoStack, () => Redo());

        private void TbUndo_DropDownOpening(object sender, EventArgs e) => Copy(_undoStack, WorldForm.tbUndo, UndoMultiple);

        private void TbRedo_DropDownOpening(object sender, EventArgs e) => Copy(_redoStack, WorldForm.tbRedo, RedoMultiple);

        private bool Undo() => CanUndo && Undo(_undoStack.Pop());

        private bool Undo(ICommand command)
        {
            if (!command.Do(Scene))
                return false;
            _redoStack.Push(command);
            UpdateUI();
            return true;
        }

        private void UndoMultiple(object sender, EventArgs e) => DoMultiple(sender, _undoStack, () => Undo());

        private void UpdateUI()
        {
            if (_updateCount > 0)
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
            WorldCon.ModifiedChanged();
        }

        // Private static methods

        private static void Copy(Stack<ICommand> source, ToolStripDropDownItem target, EventHandler handler)
        {
            const int maxItems = 20;
            var commands = source.ToArray();
            var items = target.DropDownItems;
            items.Clear();
            for (var n = 0; n < Math.Min(commands.Length, maxItems); n++)
            {
                var command = commands[n];
                var item = items.Add(command.ToString(), null, handler);
                item.Tag = command;
                item.MouseEnter += UndoRedoItems_MouseEnter;
                item.Paint += UndoRedoItems_Paint;
            }
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

        private static void UndoRedoItems_MouseEnter(object sender, EventArgs e) => HighlightUndoRedoItems((ToolStripItem)sender);

        private static void UndoRedoItems_Paint(object sender, PaintEventArgs e) => HighlightUndoRedoItems((ToolStripItem)sender);
    }
}
