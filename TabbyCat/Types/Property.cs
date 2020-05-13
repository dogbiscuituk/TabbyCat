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
        GlslTargetVersion,
        Samples,
        SceneTitle,
        Shapes,
        Signals,
        Stereo,
        TargetFps,
        VSync,

        // Projection properties

        BeforeProjection,
        ProjectionType,
        FieldOfView,
        NearPlane,
        FarPlane,
        AfterProjection,

        // Shape properties

        ShapeDescription,
        ShapeLocation,
        ShapeMaximum,
        ShapeMinimum,
        ShapeOrientation,
        ShapePattern,
        ShapeScale,
        ShapeStripeCount,
        ShapeVisible,

        // Signal properties

        SignalName,
        SignalAmplitude,
        SignalAmplitudeMaximum,
        SignalAmplitudeMinimum,
        SignalFrequency,
        SignalFrequencyMaximum,
        SignalFrequencyMinimum,
        SignalWaveType,

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
        ShapeVertexShader,
        ShapeTessellationControlShader,
        ShapeTessellationEvaluationShader,
        ShapeGeometryShader,
        ShapeFragmentShader,
        ShapeComputeShader,
        AfterShaders,
    }
}
