namespace TabbyCat.Common.Utils
{
    public static class PropertyNames
    {
        /// <summary>
        /// Scene property names.
        /// </summary>
        public const string
            Background = "Background",
            Camera = "Camera",
            CameraFocus = "Camera focus",
            CameraPosition = "Camera position",
            FarPlane = "Far plane",
            FieldOfView = "Field of view",
            FPS = "FPS",
            GLTargetVersion = "GLSL target version",
            NearPlane = "Near plane",
            ProjectionType = "Projection type",
            Samples = "#Samples",
            SceneTitle = "Scene title",
            Signals = "Signals",
            Stereo = "Stereo",
            Traces = "Traces",
            VSync = "VSync";

        /// <summary>
        /// Signal property names.
        /// </summary>
        public const string
            Name = "Name",
            Amplitude = "Amplitude",
            Frequency = "Frequency",
            WaveType = "Wave type";

        /// <summary>
        /// Trace property names.
        /// </summary>
        public const string
            Description = "Description",
            Location = "Location",
            Maximum = "Maximum",
            Minimum = "Minimum",
            Orientation = "Orientation",
            Pattern = "Pattern",
            Scale = "Scale",
            StripeCount = "#Stripes",
            Visible = "Visible";

        /// <summary>
        /// GPU property names.
        /// </summary>
        public const string
            GPULog = "GPU log",
            GPUStatus = "GPU status",
            GraphicsMode = "Graphics mode";

        /// <summary>
        /// Scene shader names.
        /// </summary>
        public const string
            SceneVertex = "Scene vertex shader",
            SceneTessControl = "Scene tessellation control shader",
            SceneTessEvaluation = "Scene tessellation evaluation shader",
            SceneGeometry = "Scene geometry shader",
            SceneFragment = "Scene fragment shader",
            SceneCompute = "Scene compute shader";

        /// <summary>
        /// Trace shader names.
        /// </summary>
        public const string
            TraceVertex = "Trace vertex shader",
            TraceTessControl = "Trace tessellation control shader",
            TraceTessEvaluation = "Trace tessellation evaluation shader",
            TraceGeometry = "Trace geometry shader",
            TraceFragment = "Trace fragment shader",
            TraceCompute = "Trace compute shader";

        /// <summary>
        /// GPU shader names.
        /// </summary>
        public const string
            VertexShader = "Vertex shader",
            TessControlShader = "Tessellation control shader",
            TessEvaluationShader = "Tessellation evaluation shader",
            GeometryShader = "Geometry shader",
            FragmentShader = "Fragment shader",
            ComputeShader = "Compute shader";
    }
}
