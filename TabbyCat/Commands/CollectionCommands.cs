namespace TabbyCat.Commands
{
    using Models;
    using Properties;
    using Types;
    using Utils;

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
    public abstract class CollectionCommand<TItem> : Command<TItem>, ICollectionCommand
    {
        // Constructors

        protected CollectionCommand(int index, bool adding) : base(index) => Adding = adding;

        // Public properties

        public bool Adding { get; set; }

        public override string RedoAction => GetAction(false);

        public override string UndoAction => GetAction(true);

        // Protected properties

        protected override string Target => Value.ToString();

        // Public methods

        public override void Invert() => Adding = !Adding;

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
            OnCollectionEdit(scene);
            return true;
        }

        public override string ToString() => (Adding ? Resources.Command_AddItem : Resources.Command_RemoveItem).Format(Target);

        // Protected methods

        protected abstract void AddItem(Scene scene);

        protected abstract TItem GetItem(Scene scene);

        protected abstract int GetItemsCount(Scene scene);

        protected abstract TItem GetNewItem(Scene scene);

        protected abstract void InsertItem(Scene scene);

        protected abstract void RemoveItem(Scene scene);

        // Private methods

        private string GetAction(bool undo) => (Adding ^ undo ? Resources.Command_ItemAddition : Resources.Command_ItemRemoval).Format(Property);

        private void OnCollectionEdit(Scene scene) => scene?.OnCollectionEdit(Property, Index, Adding);
    }

    public class ShapeCollectionCommand : CollectionCommand<Shape>, IShapeCollectionCommand
    {
        // Constructors

        protected ShapeCollectionCommand(int index, bool add) : base(index, add) => Property = Property.Shapes;

        // Protected methods

        protected override void AddItem(Scene scene) => scene?.AddShape(Value);

        protected override Shape GetItem(Scene scene) => scene?.Shapes[Index];

        protected override int GetItemsCount(Scene scene) => scene?.Shapes?.Count ?? 0;

        protected override Shape GetNewItem(Scene scene) => new Shape(scene);

        protected override void InsertItem(Scene scene) => scene?.InsertShape(Index, Value);

        protected override void RemoveItem(Scene scene) => scene?.RemoveShape(Index);
    }

    public class ShapeDeleteCommand : ShapeCollectionCommand
    {
        public ShapeDeleteCommand(int index) : base(index, false) { }
    }

    public class ShapeInsertCommand : ShapeCollectionCommand
    {
        public ShapeInsertCommand(int index, Shape shape) : base(index, true) => Value = shape;
    }

    public class SignalCollectionCommand : CollectionCommand<Signal>, ISignalCollectionCommand
    {
        // Constructors

        protected SignalCollectionCommand(int index, bool add) : base(index, add) => Property = Property.Signals;

        // Protected methods

        protected override void AddItem(Scene scene) => scene?.AddSignal(Value);

        protected override Signal GetItem(Scene scene) => scene?.Signals[Index];

        protected override int GetItemsCount(Scene scene) => scene?.Signals.Count ?? 0;

        protected override Signal GetNewItem(Scene scene) => new Signal();

        protected override void InsertItem(Scene scene) => scene?.InsertSignal(Index, Value);

        protected override void RemoveItem(Scene scene) => scene?.RemoveSignal(Index);
    }

    public class SignalDeleteCommand : SignalCollectionCommand
    {
        public SignalDeleteCommand(int index) : base(index, false) { }
    }

    public class SignalInsertCommand : SignalCollectionCommand
    {
        public SignalInsertCommand(int index, Signal signal) : base(index, true) => Value = signal;
    }
}
