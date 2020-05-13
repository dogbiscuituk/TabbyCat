namespace TabbyCat.Utils
{
    using Properties;
    using System.Collections.Generic;
    using Types;

    public static class PropertyUtils
    {
        private static readonly Dictionary<Property, string> PropertyNames = new Dictionary<Property, string>
        {
            { Property.None, Resources.Property_None},

            // Scene properties

            { Property.Background, Resources.Property_Background },
            { Property.Camera, Resources.Property_Camera},
            { Property.CameraFocus, Resources.Property_CameraFocus},
            { Property.CameraPosition, Resources.Property_CameraPosition},
            { Property.GlslTargetVersion, Resources.Property_GLTarget_Version},
            { Property.Samples, Resources.Property_Samples},
            { Property.SceneTitle, Resources.Property_SceneTitle},
            { Property.Signals, Resources.Property_Signals},
            { Property.Stereo, Resources.Property_Stereo},
            { Property.TargetFps, Resources.Property_TargetFPS},
            { Property.Shapes, Resources.Property_Shapes},
            { Property.VSync, Resources.Property_VSync},

            // Projection properties

            { Property.BeforeProjection, Resources.Blank },
            { Property.ProjectionType, Resources.Property_ProjectionType},
            { Property.FieldOfView, Resources.Property_FieldOfView},
            { Property.NearPlane, Resources.Property_NearPlane},
            { Property.FarPlane, Resources.Property_FarPlane},
            { Property.AfterProjection, Resources.Blank },

            // Signal properties

            { Property.SignalName, Resources.Property_SignalName },
            { Property.SignalAmplitude, Resources.Property_SignalAmplitude },
            { Property.SignalAmplitudeMaximum, Resources.Property_SignalAmplitudeMaximum },
            { Property.SignalAmplitudeMinimum, Resources.Property_SignalAmplitudeMinimum },
            { Property.SignalFrequency, Resources.Property_SignalFrequency },
            { Property.SignalFrequencyMaximum, Resources.Property_SignalFrequencyMaximum },
            { Property.SignalFrequencyMinimum, Resources.Property_SignalFrequencyMinimum },
            { Property.SignalWaveType, Resources.Property_SignalWaveType },

            // Shape properties

            { Property.ShapeDescription, Resources.Property_ShapeDescription },
            { Property.ShapeLocation, Resources.Property_ShapeLocation },
            { Property.ShapeMaximum, Resources.Property_ShapeMaximum },
            { Property.ShapeMinimum, Resources.Property_ShapeMinimum },
            { Property.ShapeOrientation, Resources.Property_ShapeOrientation },
            { Property.ShapePattern, Resources.Property_ShapePattern },
            { Property.ShapeScale, Resources.Property_ShapeScale },
            { Property.ShapeStripeCount, Resources.Property_ShapeStripeCount },
            { Property.ShapeVisible, Resources.Property_ShapeVisible },

            // GPU properties

            { Property.GpuLog, Resources.Property_GPULog },
            { Property.GpuStatus, Resources.Property_GPUStatus },
            { Property.GraphicsMode, Resources.Property_GraphicsMode },

            // Shader properties

            { Property.BeforeShaders, Resources.Blank },
            { Property.VertexShader, Resources.Property_VertexShader },
            { Property.TessellationControlShader, Resources.Property_TessellationControlShader },
            { Property.TessellationEvaluationShader, Resources.Property_TessellationEvaluationShader },
            { Property.GeometryShader, Resources.Property_GeometryShader },
            { Property.FragmentShader, Resources.Property_FragmentShader },
            { Property.ComputeShader, Resources.Property_ComputeShader },
            { Property.SceneVertexShader, Resources.Property_SceneVertexShader },
            { Property.SceneTessellationControlShader, Resources.Property_SceneTessellationControlShader },
            { Property.SceneTessellationEvaluationShader, Resources.Property_SceneTessellationEvaluationShader },
            { Property.SceneGeometryShader, Resources.Property_SceneGeometryShader },
            { Property.SceneFragmentShader, Resources.Property_SceneFragmentShader },
            { Property.SceneComputeShader, Resources.Property_SceneComputeShader },
            { Property.ShapeVertexShader, Resources.Property_ShapeVertexShader },
            { Property.ShapeTessellationControlShader, Resources.Property_ShapeTessellationControlShader },
            { Property.ShapeTessellationEvaluationShader, Resources.Property_ShapeTessellationEvaluationShader },
            { Property.ShapeGeometryShader, Resources.Property_ShapeGeometryShader },
            { Property.ShapeFragmentShader, Resources.Property_ShapeFragmentShader },
            { Property.ShapeComputeShader, Resources.Property_ShapeComputeShader },
            { Property.AfterShaders, Resources.Blank },
        };

        // Public methods

        /// <summary>
        /// Retrieve the localized string for a Property enum value.
        /// </summary>
        /// <param name="p">The given enum value.</param>
        /// <returns>A string localized to represent the given enum value.</returns>
        public static string AsString(this Property p) => PropertyNames[p].Split('|')[0];

        public static bool InvalidatesCameraView(this Property p)
        {
            switch (p)
            {
                case Property.Camera:
                case Property.CameraPosition:
                case Property.CameraFocus:
                    return true;
            }
            return false;
        }

        public static bool InvalidatesProgram(this Property p) => p.IsCollectionProperty() || p.IsShaderProperty() || p == Property.SignalName;

        public static bool InvalidatesProjection(this Property p) => p.IsProjectionProperty();

        public static bool InvalidatesShape(this Property p)
        {
            switch (p)
            {
                case Property.ShapePattern:
                case Property.ShapeStripeCount:
                    return true;
            }
            return false;
        }

        // Private methods

        private static bool IsCollectionProperty(this Property p) => p == Property.Signals || p == Property.Shapes;

        private static bool IsProjectionProperty(this Property p) => p > Property.BeforeProjection && p < Property.AfterProjection;

        private static bool IsShaderProperty(this Property p) => p > Property.BeforeShaders && p < Property.AfterShaders || p == Property.GlslTargetVersion;
    }
}
