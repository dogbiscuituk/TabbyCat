﻿namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCatControls;

    internal class ScenePropertyController : CodeSourcePropertyController
    {
        internal ScenePropertyController(PropertyController propertyController)
            : base(propertyController)
        { }

        private ScenePropertiesControl Editor => PropertyEditor.ScenePropertiesControl;

        private bool Reading;

        #region Private Event Handlers

        private void CameraFocus_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraFocusCommand(new Vector3d(
                (double)Editor.seCameraFocusX.Value,
                (double)Editor.seCameraFocusY.Value,
                (double)Editor.seCameraFocusZ.Value)));

        private void CameraPosition_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraPositionCommand(new Vector3d(
                (double)Editor.seCameraPositionX.Value,
                (double)Editor.seCameraPositionY.Value,
                (double)Editor.seCameraPositionZ.Value)));

        private void ProjectionType_SelectedIndexChanged(object sender, EventArgs e) =>
            Run(new ProjectionTypeCommand((ProjectionType)Editor.cbProjectionType.SelectedIndex));

        private void SceneTitle_TextChanged(object sender, EventArgs e)
            => Run(new TitleCommand(Editor.edTitle.Text));

        #endregion

        protected override void Connect()
        {
            Editor.edTitle.TextChanged += SceneTitle_TextChanged;
            Editor.seCameraPositionX.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraPositionY.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraPositionZ.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraFocusX.ValueChanged += CameraFocus_ValueChanged;
            Editor.seCameraFocusY.ValueChanged += CameraFocus_ValueChanged;
            Editor.seCameraFocusZ.ValueChanged += CameraFocus_ValueChanged;
            Editor.cbProjectionType.SelectedIndexChanged += ProjectionType_SelectedIndexChanged;
        }

        protected override void Disconnect()
        {
            Editor.edTitle.TextChanged -= SceneTitle_TextChanged;
        }

        internal void ReadFromModel()
        {
            Reading = true;
            Editor.edTitle.Text = Scene.Title;
            Editor.seCameraPositionX.Value = (decimal)Scene.Camera.Position.X;
            Editor.seCameraPositionY.Value = (decimal)Scene.Camera.Position.Y;
            Editor.seCameraPositionZ.Value = (decimal)Scene.Camera.Position.Z;
            Editor.seCameraFocusX.Value = (decimal)Scene.Camera.Focus.X;
            Editor.seCameraFocusY.Value = (decimal)Scene.Camera.Focus.Y;
            Editor.seCameraFocusZ.Value = (decimal)Scene.Camera.Focus.Z;
            Editor.cbProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
            Editor.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
            Editor.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
            Editor.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
            Editor.seFrustumMaxX.Value = (decimal)Scene.Projection.FrustumMax.X;
            Editor.seFrustumMaxY.Value = (decimal)Scene.Projection.FrustumMax.Y;
            Editor.seFrustumMaxZ.Value = (decimal)Scene.Projection.FrustumMax.Z;
            Editor.seFPS.Value = (decimal)Scene.FPS;
            Editor.seSamples.Value = Scene.SampleCount;
            Editor.cbVSync.Checked = Scene.VSync;
            Editor.cbGLSLVersion.SelectedItem = Scene.GLTargetVersion;
            Reading = false;
        }
    }
}
