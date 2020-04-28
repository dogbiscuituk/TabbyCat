namespace TabbyCat.Commands
{
    using Models;
    using System;
    using System.Text.RegularExpressions;

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

        public override string ToString()
        {
            const int maxLength = 50;
            var s = Regex.Replace($"{Value}", @"[\s]+", " ", RegexOptions.Singleline);
            if (s.Length > maxLength)
                s = $"{s.Substring(0, maxLength)}…";
            return $"{PropertyName} = {s}";
        }

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
    }

    internal abstract class SignalPropertyCommand<TValue> : PropertyCommand<Signal, TValue>, ISignalPropertyCommand
    {
        protected SignalPropertyCommand(int index, string propertyName,
            TValue value, Func<Signal, TValue> get, Action<Signal, TValue> set)
            : base(index, propertyName, value, get, set) { }

        public bool RunOn(Signal signal)
        {
            if (Equals(Get(signal), Value))
                return false;
            Set(signal, Value);
            return true;
        }

        protected override string Target => "Signal";

        protected override Signal GetItem(Scene scene) => scene.Signals[Index];
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

        protected override Trace GetItem(Scene scene) => scene.Traces[Index];
    }
}
