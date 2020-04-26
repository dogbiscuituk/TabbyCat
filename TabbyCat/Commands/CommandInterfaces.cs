namespace TabbyCat.Commands
{
    using Models;

    internal interface ICollectionCommand : ICommand
    {
        bool Adding { get; set; }
    }

    internal interface ICommand
    {
        int Index { get; }
        string PropertyName { get; }
        string RedoAction { get; }
        string UndoAction { get; }

        bool Do(Scene scene);
        void Invert();
        bool Run(Scene scene);
    }

    internal interface IScenePropertyCommand : ICommand
    {
        bool RunOn(Scene scene);
    }

    internal interface ISignalPropertyCommand : ICommand
    {
        bool RunOn(Signal signal);
    }

    internal interface ITracePropertyCommand : ICommand
    {
        bool RunOn(Trace trace);
    }

    internal interface ITracesCommand : ICollectionCommand
    {
        Trace Value { get; set; }
    }
}
