namespace TabbyCat.Common.Utility
{
    public static class PropertyNames
    {
        /// <summary>
        /// Scene property names.
        /// </summary>
        public const string
            Background = "Background",
            CameraFocus = "Camera Focus",
            CameraPosition = "Camera Position",
            FarPlane = "Far Plane",
            FieldOfView = "Field of View",
            FPS = "FPS",
            GLTargetVersion = "GL Target Version",
            NearPlane = "Near Plane",
            ProjectionType = "Projection Type",
            Samples = "Samples",
            SceneTitle = "Scene Title",
            Traces = "Traces",
            VSync = "VSync";

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
            StripCount = "Strip Count",
            Visible = "Visible";

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
        /// Transient Properties.
        /// </summary>
        public const string
            GPULog = "GPU Log",
            GPUStatus = "GPU Status",
            GraphicsMode = "Graphics Mode";
    }
}
