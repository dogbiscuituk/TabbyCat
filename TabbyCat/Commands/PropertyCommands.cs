namespace TabbyCat.Commands
{
    using Models;
    using Properties;
    using System;
    using System.Text.RegularExpressions;
    using Types;
    using Utils;

    public abstract class PropertyCommand<TItem, TValue> : Command<TValue>
    {
        // Constructors

        protected PropertyCommand(int index, Property property, TValue value, Func<TItem, TValue> get, Action<TItem, TValue> set) : base(index)
        {
            Property = property;
            Value = value;
            Get = get;
            Set = set;
        }

        // Public properties

        private string Action => Resources.Command_PropertyChange.Format(Property.AsString());

        public override string RedoAction => Action;

        public override string UndoAction => Action;

        // Protected properties

        protected Func<TItem, TValue> Get { get; set; }

        protected Action<TItem, TValue> Set { get; set; }

        // Public methods

        public override bool Run(Scene scene)
        {
            var value = GetPropertyValue(scene);
            var result = !Equals(value, Value);
            if (result)
            {
                SetPropertyValue(scene, Value);
                Value = value;
            }
            return result;
        }

        public override string ToString()
        {
            const int maxLength = 50;
            var s = Regex.Replace($"{Value}", @"[\s]+", " ", RegexOptions.Singleline);
            if (s.Length > maxLength)
                s = $"{s.Substring(0, maxLength)}…";
            return $"{Property.AsString()} = {s}";
        }

        // Protected methods

        protected abstract TItem GetItem(Scene scene);

        protected TValue GetPropertyValue(Scene scene) => Get(GetItem(scene));

        protected void SetPropertyValue(Scene scene, TValue value) => Set(GetItem(scene), value);
    }

    public abstract class ScenePropertyCommand<TValue> : PropertyCommand<Scene, TValue>, IScenePropertyCommand
    {
        protected ScenePropertyCommand(Property property, TValue value, Func<Scene, TValue> get, Action<Scene, TValue> set) : base(0, property, value, get, set) { }

        public bool RunOn(Scene scene)
        {
            if (Equals(Get(scene), Value))
                return false;
            Set(scene, Value);
            return true;
        }

        protected override string Target => Resources.Property_Scene;

        protected override Scene GetItem(Scene scene) => scene;
    }

    public abstract class ShapePropertyCommand<TValue> : PropertyCommand<Shape, TValue>, IShapePropertyCommand
    {
        protected ShapePropertyCommand(int index, Property property, TValue value, Func<Shape, TValue> get, Action<Shape, TValue> set) : base(index, property, value, get, set) { }

        public bool RunOn(Shape shape)
        {
            if (Equals(Get(shape), Value))
                return false;
            Set(shape, Value);
            return true;
        }

        protected override string Target => Resources.Property_Shape;

        protected override Shape GetItem(Scene scene) => scene?.Shapes[Index];
    }

    public abstract class SignalPropertyCommand<TValue> : PropertyCommand<Signal, TValue>, ISignalPropertyCommand
    {
        protected SignalPropertyCommand(int index, Property property, TValue value, Func<Signal, TValue> get, Action<Signal, TValue> set) : base(index, property, value, get, set) { }

        public bool RunOn(Signal signal)
        {
            if (Equals(Get(signal), Value))
                return false;
            Set(signal, Value);
            return true;
        }

        protected override string Target => Resources.Property_Signal;

        protected override Signal GetItem(Scene scene) => scene?.Signals[Index];
    }
}
