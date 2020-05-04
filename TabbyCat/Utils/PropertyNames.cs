namespace TabbyCat.Utils
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
            AmplitudeMaximum = "Maximum amplitude",
            AmplitudeMinimum = "Minimum amplitude",
            Frequency = "Frequency",
            FrequencyMaximum = "Maximum frequency",
            FrequencyMinimum = "Minimum frequency",
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
    }
}
