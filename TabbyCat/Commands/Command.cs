namespace TabbyCat.Commands
{
    using Models;

    internal abstract class Command<TValue> : ICommand
    {
        // Constructors

        protected Command(int index = 0) { Index = index; }

        // Public properties

        public int Index { get; private set; }
        public string PropertyName { get; set; }
        public abstract string RedoAction { get; }
        public abstract string UndoAction { get; }

        // Internal properties

        internal TValue Value { get; set; }

        // Protected properties

        protected abstract string Target { get; }

        // Public methods

        /// <summary>
        /// Invoke the Run method of the command, then immediately invert
        /// the command in readiness for its transfer between the Undo and
        /// Redo stacks. Since most commands are their own inverses (they
        /// just tell the Scene "Swap your property value with the one I'm
        /// carrying", the Invert() method is almost always empty. See the
        /// SceneInsertTraceCommand and SceneDeleteTraceCommand classes
        /// for two notable exceptions to this rule.
        /// </summary>
        /// <param name="scene"></param>
        public bool Do(Scene scene)
        {
            var result = Run(scene);
            if (result)
                OnPropertyChanged(scene);
            Invert();
            return result;
        }

        public virtual void Invert() { }

        public abstract bool Run(Scene scene);

        // Protected methods

        protected virtual void OnPropertyChanged(Scene scene) => scene.OnPropertyChanged(PropertyName);
    }
}
