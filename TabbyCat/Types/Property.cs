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
        TargetFPS,
        GLTargetVersion,
        Samples,
        SceneTitle,
        Signals,
        Stereo,
        Traces,
        VSync,

        // Projection properties

        BeforeProjection,
        ProjectionType,
        FieldOfView,
        NearPlane,
        FarPlane,
        AfterProjection,

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

        BeforeShaders,
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
        AfterShaders,
    }
}
