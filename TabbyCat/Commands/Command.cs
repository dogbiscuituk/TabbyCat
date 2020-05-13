namespace TabbyCat.Commands
{
    using Models;
    using Types;

    public abstract class Command<TValue> : ICommand
    {
        // Constructors

        protected Command(int index = 0) => Index = index;

        // Public properties

        public int Index { get; private set; }
        public Property Property { get; set; }
        public abstract string RedoAction { get; }
        public abstract string UndoAction { get; }
        public TValue Value { get; set; }

        // Protected properties

        protected abstract string Target { get; }

        // Public methods

        /// <summary>
        /// Invoke the Run method of the command, then immediately invert
        /// the command in readiness for its transfer between the Undo and
        /// Redo stacks. Since property commands are their own inverses
        /// (they just tell the Scene "Swap your property value with the one
        /// I'm carrying"), the Invert() method is almost always empty. See
        /// CollectionCommand classes, for example ShapeInsertCommand
        /// and ShapeDeleteCommand for notable exceptions to this rule.
        /// </summary>
        /// <param name="scene">The Scene object upon which the command is executed.</param>
        public bool Do(Scene scene)
        {
            var result = Run(scene);
            if (result)
                OnPropertyEdit(scene);
            Invert();
            return result;
        }

        public virtual void Invert() { }

        public abstract bool Run(Scene scene);

        // Protected methods

        protected virtual void OnPropertyEdit(Scene scene) => scene?.OnPropertyEdit(Property, Index);
    }
}
