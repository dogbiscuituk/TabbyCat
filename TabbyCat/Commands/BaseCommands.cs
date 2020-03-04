namespace TabbyCat.Commands
{
    using System;
    using TabbyCat.Models;

    #region Abstract Base Command

    internal abstract class Command<TValue> : ICommand
    {
        protected Command(int index = 0) { Index = index; }

        public int Index { get; private set; }

        public abstract string RedoAction { get; }

        public abstract string UndoAction { get; }

        internal TValue Value { get; set; }

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
                OnPropertyChanged(scene, PropertyName);
            Invert();
            return result;
        }

        public virtual void Invert() { }

        protected abstract void OnPropertyChanged(Scene scene, string propertyName);

        public abstract bool Run(Scene scene);

        public string PropertyName { get; set; }

        protected abstract string Target { get; }
    }

    #endregion

    #region Abstract Property Commands

    internal abstract class PropertyCommand<TItem, TValue> : Command<TValue>
    {
        protected PropertyCommand(int index, string propertyName,
            TValue value, Func<TItem, TValue> get, Action<TItem, TValue> set)
            : base(index)
        {
            PropertyName = propertyName;
            Value = value;
            Get = get;
            Set = set;
        }

        public override string RedoAction => Action;

        public override string UndoAction => Action;

        public override bool Run(Scene scene)
        {
            var value = GetValue(scene);
            var result = !Equals(value, Value);
            if (result)
            {
                SetValue(scene, Value);
                Value = value;
            }
            return result;
        }

        public override string ToString() => $"{PropertyName} = {Value}";

        private string Action => $"{PropertyName} change";

        protected Func<TItem, TValue> Get;

        protected Action<TItem, TValue> Set;

        protected abstract TItem GetItem(Scene scene);

        protected TValue GetValue(Scene scene) => Get(GetItem(scene));

        protected void SetValue(Scene scene, TValue value) => Set(GetItem(scene), value);
    }

    internal abstract class ScenePropertyCommand<TValue> : PropertyCommand<Scene, TValue>, IScenePropertyCommand
    {
        protected ScenePropertyCommand(string propertyName,
            TValue value, Func<Scene, TValue> get, Action<Scene, TValue> set)
            : base(0, propertyName, value, get, set) { }

        public bool RunOn(Scene scene)
        {
            if (Equals(Get(scene), Value))
                return false;
            Set(scene, Value);
            return true;
        }

        protected override string Target => "Scene";

        protected override Scene GetItem(Scene scene) => scene;

        protected override void OnPropertyChanged(Scene scene, string propertyName) =>
            scene.OnPropertyChanged(propertyName);
    }

    internal abstract class TracePropertyCommand<TValue> : PropertyCommand<Trace, TValue>, ITracePropertyCommand
    {
        protected TracePropertyCommand(int index, string propertyName,
            TValue value, Func<Trace, TValue> get, Action<Trace, TValue> set)
            : base(index, propertyName, value, get, set) { }

        public bool RunOn(Trace trace)
        {
            if (Equals(Get(trace), Value))
                return false;
            Set(trace, Value);
            return true;
        }

        protected override string Target => "Trace";

        protected override void OnPropertyChanged(Scene scene, string propertyName) =>
            scene.OnPropertyChanged($"Traces[{Index}].{propertyName}");

        protected override Trace GetItem(Scene scene) => scene.Traces[Index];
    }

    #endregion

    #region Collection Commands

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
        internal CollectionCommand(int index, bool add) : base(index) { Adding = add; }

        public bool Adding { get; set; }

        public override string RedoAction => GetAction(false);

        public override string UndoAction => GetAction(true);

        public override void Invert() { Adding = !Adding; }

        public override string ToString() => $"{(Adding ? "Add" : "Remove")} {Target}";

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
            return true;
        }

        protected abstract void AddItem(Scene scene);

        protected abstract TItem GetItem(Scene scene);

        protected abstract int GetItemsCount(Scene scene);
        
        protected abstract TItem GetNewItem(Scene scene);
        
        protected abstract void InsertItem(Scene scene);
        
        protected abstract void RemoveItem(Scene scene);

        private string GetAction(bool undo) => $"{PropertyName} {(Adding ^ undo ? "addition" : "removal")}";
    }

    internal class TracesCommand : CollectionCommand<Trace>
    {
        internal TracesCommand(int index, bool add) : base(index, add) => PropertyName = "Traces";

        protected override string Target => Value.ToString();

        protected override void AddItem(Scene scene) => scene.AddTrace(Value);
        
        protected override Trace GetItem(Scene scene) => scene.Traces[Index];
        
        protected override int GetItemsCount(Scene scene) => scene.Traces.Count;
        
        protected override Trace GetNewItem(Scene scene) => scene.NewTrace();
        
        protected override void InsertItem(Scene scene) => scene.InsertTrace(Index, Value);
        
        protected override void OnPropertyChanged(Scene scene, string propertyName) => scene.OnPropertyChanged(propertyName);
        
        protected override void RemoveItem(Scene scene) => scene.RemoveTrace(Index);
    }

    #endregion
}
