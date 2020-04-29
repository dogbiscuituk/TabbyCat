namespace TabbyCat.Commands
{
    using Common.Utils;
    using Jmk.Common;
    using Models;
    using System.Linq;

    /// <summary>
    /// Common ancestor for collection management (item insert and delete) commands.
    /// Those descendant classes differ only in the value of a private boolean flag,
    /// "Adding", which controls their appearance and behaviour. While most commands
    /// are their own inverses, since they just tell the Scene "Swap your property
    /// value with the one I'm carrying", the Invert() method is usually empty. But
    /// in the case of these commands, toggling the "Adding" flag converts one into
    /// the other, prior to the command processor moving them between the Undo and
    /// Redo stacks.
    /// </summary>
    internal abstract class CollectionCommand<TItem> : Command<TItem>, ICollectionCommand
    {
        // Constructors

        internal CollectionCommand(int index, bool add) : base(index) { Adding = add; }

        // Public properties

        public bool Adding { get; set; }

        public override string RedoAction => GetAction(false);

        public override string UndoAction => GetAction(true);

        // Protected properties

        protected override string Target => Value.ToString();

        // Public methods

        public override void Invert() { Adding = !Adding; }

        public override bool Run(Scene scene)
        {
            if (Adding)
            {
                if (Value == null)
                    Value = GetNewItem(scene);
                var count = GetItemsCount(scene);
                if (Index >= 0 && Index < count)
                    InsertItem(scene);
                else if (Index == count)
                    AddItem(scene);
                else
                    return false;
            }
            else
            {
                if (Value == null)
                    Value = GetItem(scene);
                RemoveItem(scene);
            }
            OnCollectionChanged(scene);
            return true;
        }

        public override string ToString() => $"{(Adding ? "Add" : "Remove")} {Target}";

        // Protected methods

        protected abstract void AddItem(Scene scene);

        protected abstract TItem GetItem(Scene scene);

        protected abstract int GetItemsCount(Scene scene);

        protected abstract TItem GetNewItem(Scene scene);

        protected abstract void InsertItem(Scene scene);

        protected virtual void OnCollectionChanged(Scene scene) => scene.OnCollectionChanged(PropertyName, Adding, Index);

        protected abstract void RemoveItem(Scene scene);

        // Private methods

        private string GetAction(bool undo) => $"{PropertyName} {(Adding ^ undo ? "addition" : "removal")}";
    }

    internal class SignalCollectionCommand : CollectionCommand<Signal>
    {
        // Constructors

        internal SignalCollectionCommand(int index, bool add) : base(index, add) => PropertyName = PropertyNames.Signals;

        // Protected methods

        protected override void AddItem(Scene scene) => scene.AddSignal(Value);

        protected override Signal GetItem(Scene scene) => scene.Signals[Index];

        protected override int GetItemsCount(Scene scene) => scene.Signals.Count;

        protected override Signal GetNewItem(Scene scene) => new Signal();

        protected override void InsertItem(Scene scene) => scene.InsertSignal(Index, Value);

        protected override void RemoveItem(Scene scene) => scene.RemoveSignal(Index);
    }

    internal class SignalDeleteCommand : SignalCollectionCommand
    {
        internal SignalDeleteCommand(int index) : base(index, false) { }
    }

    internal class SignalInsertCommand : SignalCollectionCommand
    {
        internal SignalInsertCommand(int index, Signal signal) : base(index, true) { Value = signal; }
    }

    internal class TraceCollectionCommand : CollectionCommand<Trace>
    {
        // Constructors

        internal TraceCollectionCommand(int index, bool add) : base(index, add) => PropertyName = PropertyNames.Traces;

        // Protected methods

        protected override void AddItem(Scene scene) => scene.AddTrace(Value);

        protected override Trace GetItem(Scene scene) => scene.Traces[Index];

        protected override int GetItemsCount(Scene scene) => scene.Traces.Count;

        protected override Trace GetNewItem(Scene scene) => new Trace(scene);

        protected override void InsertItem(Scene scene) => scene.InsertTrace(Index, Value);

        protected override void RemoveItem(Scene scene) => scene.RemoveTrace(Index);
    }

    internal class TraceDeleteCommand : TraceCollectionCommand
    {
        internal TraceDeleteCommand(int index) : base(index, false) { }
    }

    internal class TraceInsertCommand : TraceCollectionCommand
    {
        internal TraceInsertCommand(int index, Trace trace) : base(index, true) { Value = trace; }
    }
}
