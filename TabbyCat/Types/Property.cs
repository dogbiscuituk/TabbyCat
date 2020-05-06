namespace TabbyCat.Types
{
    public enum Property
    {
        None,

        // Scene properties

        Background,
        Camera,
        CameraFocus,
        CameraPosition,
        FarPlane,
        FieldOfView,
        TargetFPS,
        GLTargetVersion,
        NearPlane,
        ProjectionType,
        Samples,
        SceneTitle,
        Signals,
        Stereo,
        Traces,
        VSync,

        // Signal properties

        SignalName,
        SignalAmplitude,
        SignalAmplitudeMaximum,
        SignalAmplitudeMinimum,
        SignalFrequency,
        SignalFrequencyMaximum,
        SignalFrequencyMinimum,
        SignalWaveType,

        // Trace properties

        TraceDescription,
        TraceLocation,
        TraceMaximum,
        TraceMinimum,
        TraceOrientation,
        TracePattern,
        TraceScale,
        TraceStripeCount,
        TraceVisible,

        // GPU properties

        GPULog,
        GPUStatus,
        GraphicsMode,

        // Shader properties

        FirstShader,
        VertexShader,
        TessellationControlShader,
        TessellationEvaluationShader,
        GeometryShader,
        FragmentShader,
        ComputeShader,
        SceneVertexShader,
        SceneTessellationControlShader,
        SceneTessellationEvaluationShader,
        SceneGeometryShader,
        SceneFragmentShader,
        SceneComputeShader,
        TraceVertexShader,
        TraceTessellationControlShader,
        TraceTessellationEvaluationShader,
        TraceGeometryShader,
        TraceFragmentShader,
        TraceComputeShader,
        LastShader,
    }
}
