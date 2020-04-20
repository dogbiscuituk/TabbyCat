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
            CameraFocus = "Camera Focus",
            CameraPosition = "Camera Position",
            FarPlane = "Far Plane",
            FieldOfView = "Field of View",
            FPS = "FPS",
            GLTargetVersion = "GL Target Version",
            NearPlane = "Near Plane",
            ProjectionType = "Projection Type",
            Samples = "#Samples",
            SceneTitle = "Scene Title",
            Stereo = "Stereo",
            Traces = "Traces",
            VSync = "VSync";

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
            GPULog = "GPU Log",
            GPUStatus = "GPU Status",
            GraphicsMode = "Graphics Mode";

        /// <summary>
        /// Scene shader names.
        /// </summary>
        public const string
            SceneVertex = "Scene Vertex Shader",
            SceneTessControl = "Scene Tessellation Control Shader",
            SceneTessEvaluation = "Scene Tessellation Evaluation Shader",
            SceneGeometry = "Scene Geometry Shader",
            SceneFragment = "Scene Fragment Shader",
            SceneCompute = "Scene Compute Shader";

        /// <summary>
        /// Trace shader names.
        /// </summary>
        public const string
            TraceVertex = "Trace Vertex Shader",
            TraceTessControl = "Trace Tessellation Control Shader",
            TraceTessEvaluation = "Trace Tessellation Evaluation Shader",
            TraceGeometry = "Trace Geometry Shader",
            TraceFragment = "Trace Fragment Shader",
            TraceCompute = "Trace Compute Shader";

        /// <summary>
        /// GPU shader names.
        /// </summary>
        public const string
            VertexShader = "Vertex Shader",
            TessControlShader = "Tessellation Control Shader",
            TessEvaluationShader = "Tessellation Evaluation Shader",
            GeometryShader = "Geometry Shader",
            FragmentShader = "Fragment Shader",
            ComputeShader = "Compute Shader";
    }
}
