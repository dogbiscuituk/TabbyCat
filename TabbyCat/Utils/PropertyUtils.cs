namespace TabbyCat.Utils
{
    using Properties;
    using System.Collections.Generic;
    using Types;

    internal static class PropertyUtils
    {
        // Private fields

        private static readonly Dictionary<Property, string> PropertyNames = new Dictionary<Property, string>
        {
            { Property.None, Resources.Property_None},

            // Scene properties

            { Property.Background, Resources.Property_Background },
            { Property.Camera, Resources.Property_Camera},
            { Property.CameraFocus, Resources.Property_CameraFocus},
            { Property.CameraPosition, Resources.Property_CameraPosition},
            { Property.FarPlane, Resources.Property_FarPlane},
            { Property.FieldOfView, Resources.Property_FieldOfView},
            { Property.GLTargetVersion, Resources.Property_GLTarget_Version},
            { Property.NearPlane, Resources.Property_NearPlane},
            { Property.ProjectionType, Resources.Property_ProjectionType},
            { Property.Samples, Resources.Property_Samples},
            { Property.SceneTitle, Resources.Property_SceneTitle},
            { Property.Signals, Resources.Property_Signals},
            { Property.Stereo, Resources.Property_Stereo},
            { Property.TargetFPS, Resources.Property_TargetFPS},
            { Property.Traces, Resources.Property_Traces},
            { Property.VSync, Resources.Property_VSync},

            // Signal properties

            { Property.SignalName, Resources.Property_SignalName },
            { Property.SignalAmplitude, Resources.Property_SignalAmplitude },
            { Property.SignalAmplitudeMaximum, Resources.Property_SignalAmplitudeMaximum },
            { Property.SignalAmplitudeMinimum, Resources.Property_SignalAmplitudeMinimum },
            { Property.SignalFrequency, Resources.Property_SignalFrequency },
            { Property.SignalFrequencyMaximum, Resources.Property_SignalFrequencyMaximum },
            { Property.SignalFrequencyMinimum, Resources.Property_SignalFrequencyMinimum },
            { Property.SignalWaveType, Resources.Property_SignalWaveType },

            // Trace properties

            { Property.TraceDescription, Resources.Property_TraceDescription },
            { Property.TraceLocation, Resources.Property_TraceLocation },
            { Property.TraceMaximum, Resources.Property_TraceMaximum },
            { Property.TraceMinimum, Resources.Property_TraceMinimum },
            { Property.TraceOrientation, Resources.Property_TraceOrientation },
            { Property.TracePattern, Resources.Property_TracePattern },
            { Property.TraceScale, Resources.Property_TraceScale },
            { Property.TraceStripeCount, Resources.Property_TraceStripeCount },
            { Property.TraceVisible, Resources.Property_TraceVisible },

            // GPU properties

            { Property.GPULog, Resources.Property_GPULog },
            { Property.GPUStatus, Resources.Property_GPUStatus },
            { Property.GraphicsMode, Resources.Property_GraphicsMode },

            // Shader properties

            { Property.FirstShader, Resources.Property_FirstShader },
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
            { Property.TraceVertexShader, Resources.Property_TraceVertexShader },
            { Property.TraceTessellationControlShader, Resources.Property_TraceTessellationControlShader },
            { Property.TraceTessellationEvaluationShader, Resources.Property_TraceTessellationEvaluationShader },
            { Property.TraceGeometryShader, Resources.Property_TraceGeometryShader },
            { Property.TraceFragmentShader, Resources.Property_TraceFragmentShader },
            { Property.TraceComputeShader, Resources.Property_TraceComputeShader },
            { Property.LastShader, Resources.Property_LastShader },
        };

        // Internal methods

        internal static string AsString(this Property property) => PropertyNames[property].Split('|')[0];
    }
}
