namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.ComponentModel;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCatControls;

    internal class SceneEditController : CodeEditController
    {
        #region Internal Constructor

        internal SceneEditController(PropertyController propertyController)
            : base(propertyController) => InitControls(Editor.TableLayoutPanel);

        #endregion

        #region Protected Methods

        protected override void Connect()
        {
            UpdateAllProperties();
            Editor.edTitle.TextChanged += SceneTitle_TextChanged;
            Editor.seCameraPositionX.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraPositionY.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraPositionZ.ValueChanged += CameraPosition_ValueChanged;
            Editor.seCameraFocusX.ValueChanged += CameraFocus_ValueChanged;
            Editor.seCameraFocusY.ValueChanged += CameraFocus_ValueChanged;
            Editor.seCameraFocusZ.ValueChanged += CameraFocus_ValueChanged;
            Editor.cbProjectionType.SelectedIndexChanged += ProjectionType_SelectedIndexChanged;
            Editor.seFieldOfView.ValueChanged += FieldOfView_ValueChanged;
            Editor.seFrustumMinX.ValueChanged += FrustumMin_ValueChanged;
            Editor.seFrustumMinY.ValueChanged += FrustumMin_ValueChanged;
            Editor.seFrustumMinZ.ValueChanged += FrustumMin_ValueChanged;
            Editor.seFrustumMaxX.ValueChanged += FrustumMax_ValueChanged;
            Editor.seFrustumMaxY.ValueChanged += FrustumMax_ValueChanged;
            Editor.seFrustumMaxZ.ValueChanged += FrustumMax_ValueChanged;
            SceneController.PropertyChanged += SceneController_PropertyChanged;
        }

        protected override void Disconnect()
        {
            Editor.edTitle.TextChanged -= SceneTitle_TextChanged;
        }

        #endregion

        #region Private Properties

        private SceneEdit Editor => PropertyEditor.SceneEdit;

        #endregion

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

        private void FieldOfView_ValueChanged(object sender, EventArgs e) =>
            Run(new FieldOfViewCommand((double)Editor.seFieldOfView.Value));

        private void FrustumMax_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMaxCommand(new Vector3d(
                (double)Editor.seFrustumMaxX.Value,
                (double)Editor.seFrustumMaxY.Value,
                (double)Editor.seFrustumMaxZ.Value)));

        private void FrustumMin_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMinCommand(new Vector3d(
                (double)Editor.seFrustumMinX.Value,
                (double)Editor.seFrustumMinY.Value,
                (double)Editor.seFrustumMinZ.Value)));

        private void ProjectionType_SelectedIndexChanged(object sender, EventArgs e) =>
            Run(new ProjectionTypeCommand((ProjectionType)Editor.cbProjectionType.SelectedIndex));

        private void SceneController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        private void SceneTitle_TextChanged(object sender, EventArgs e)
            => Run(new TitleCommand(Editor.edTitle.Text));

        #endregion

        #region Private Methods

        private void UpdateAllProperties() => UpdateProperties(new[]
        {
            PropertyNames.CameraFocus,
            PropertyNames.CameraPosition,
            PropertyNames.FarPlane,
            PropertyNames.FPS,
            PropertyNames.GLTargetVersion,
            PropertyNames.NearPlane,
            PropertyNames.ProjectionType,
            PropertyNames.Samples,
            PropertyNames.SceneTitle,
            PropertyNames.VSync
        });

        private void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.CameraFocus:
                        Editor.seCameraFocusX.Value = (decimal)Scene.Camera.Focus.X;
                        Editor.seCameraFocusY.Value = (decimal)Scene.Camera.Focus.Y;
                        Editor.seCameraFocusZ.Value = (decimal)Scene.Camera.Focus.Z;
                        break;
                    case PropertyNames.CameraPosition:
                        Editor.seCameraPositionX.Value = (decimal)Scene.Camera.Position.X;
                        Editor.seCameraPositionY.Value = (decimal)Scene.Camera.Position.Y;
                        Editor.seCameraPositionZ.Value = (decimal)Scene.Camera.Position.Z;
                        break;
                    case PropertyNames.FarPlane:
                        Editor.seFrustumMaxX.Value = (decimal)Scene.Projection.FrustumMax.X;
                        Editor.seFrustumMaxY.Value = (decimal)Scene.Projection.FrustumMax.Y;
                        Editor.seFrustumMaxZ.Value = (decimal)Scene.Projection.FrustumMax.Z;
                        break;
                    case PropertyNames.FPS:
                        Editor.seFPS.Value = (decimal)Scene.FPS;
                        break;
                    case PropertyNames.GLTargetVersion:
                        Editor.cbGLSLVersion.SelectedItem = Scene.GLTargetVersion;
                        break;
                    case PropertyNames.NearPlane:
                        Editor.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
                        Editor.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
                        Editor.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
                        break;
                    case PropertyNames.ProjectionType:
                        //Editor.cbProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
                        break;
                    case PropertyNames.Samples:
                        Editor.seSamples.Value = Scene.SampleCount;
                        break;
                    case PropertyNames.SceneTitle:
                        Editor.edTitle.Text = Scene.Title;
                        break;
                    case PropertyNames.VSync:
                        Editor.cbVSync.Checked = Scene.VSync;
                        break;
                }
            Updating = false;
        }

        #endregion
    }
}
