namespace TabbyCat.Commands
{
    using Models;
    using Types;

    public interface ICommand
    {
        int Index { get; }
        Property Property { get; }
        string RedoAction { get; }
        string UndoAction { get; }

        bool Do(Scene scene);
        void Invert();
        bool Run(Scene scene);
    }

    public interface IScenePropertyCommand : ICommand
    {
        bool RunOn(Scene scene);
    }

    public interface ISignalPropertyCommand : ICommand
    {
        bool RunOn(Signal signal);
    }

    public interface ITracePropertyCommand : ICommand
    {
        bool RunOn(Trace trace);
    }

    public interface ICollectionCommand : ICommand
    {
        bool Adding { get; set; }
    }

    public interface ISignalCollectionCommand : ICollectionCommand
    {
        Signal Value { get; set; }
    }

    public interface ITraceCollectionCommand : ICollectionCommand
    {
        Trace Value { get; set; }
    }
}
