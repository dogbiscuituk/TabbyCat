namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Properties;
    using TabbyCatControls;

    internal class SceneController : ShaderSetController
    {
        #region Constructors

        internal SceneController(PropertiesController propertiesController)
            : base(propertiesController)
        {
            InitCommonControls(Editor.TableLayoutPanel);
            InitLocalControls();
        }

        #endregion

        #region Fields & Properties

        private SceneEdit Editor => WorldEdit.SceneEdit;

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            if (connect)
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
                Editor.seFPS.ValueChanged += FPS_ValueChanged;
                Editor.seFrustumMinX.ValueChanged += FrustumMin_ValueChanged;
                Editor.seFrustumMinY.ValueChanged += FrustumMin_ValueChanged;
                Editor.seFrustumMinZ.ValueChanged += FrustumMin_ValueChanged;
                Editor.seFrustumMaxX.ValueChanged += FrustumMax_ValueChanged;
                Editor.seFrustumMaxY.ValueChanged += FrustumMax_ValueChanged;
                Editor.seFrustumMaxZ.ValueChanged += FrustumMax_ValueChanged;
                Editor.cbBackground.SelectedIndexChanged += Background_SelectedIndexChanged;
                Editor.cbVSync.CheckedChanged += VSync_CheckedChanged;
                Editor.seSamples.ValueChanged += Samples_ValueChanged;
                Editor.cbGLSLVersion.SelectedValueChanged += GLSLVersion_SelectedValueChanged;
                WorldController.PropertyChanged += WorldController_PropertyChanged;
            }
            else
            {
                Editor.edTitle.TextChanged -= SceneTitle_TextChanged;
                Editor.seCameraPositionX.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraPositionY.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraPositionZ.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraFocusX.ValueChanged -= CameraFocus_ValueChanged;
                Editor.seCameraFocusY.ValueChanged -= CameraFocus_ValueChanged;
                Editor.seCameraFocusZ.ValueChanged -= CameraFocus_ValueChanged;
                Editor.cbProjectionType.SelectedIndexChanged -= ProjectionType_SelectedIndexChanged;
                Editor.seFieldOfView.ValueChanged -= FieldOfView_ValueChanged;
                Editor.seFPS.ValueChanged -= FPS_ValueChanged;
                Editor.seFrustumMinX.ValueChanged -= FrustumMin_ValueChanged;
                Editor.seFrustumMinY.ValueChanged -= FrustumMin_ValueChanged;
                Editor.seFrustumMinZ.ValueChanged -= FrustumMin_ValueChanged;
                Editor.seFrustumMaxX.ValueChanged -= FrustumMax_ValueChanged;
                Editor.seFrustumMaxY.ValueChanged -= FrustumMax_ValueChanged;
                Editor.seFrustumMaxZ.ValueChanged -= FrustumMax_ValueChanged;
                Editor.cbBackground.SelectedIndexChanged -= Background_SelectedIndexChanged;
                Editor.cbVSync.CheckedChanged -= VSync_CheckedChanged;
                Editor.seSamples.ValueChanged -= Samples_ValueChanged;
                Editor.cbGLSLVersion.SelectedValueChanged -= GLSLVersion_SelectedValueChanged;
                WorldController.PropertyChanged -= WorldController_PropertyChanged;
            }
        }

        #endregion

        #region Private Event Handlers

        private void Background_SelectedIndexChanged(object sender, EventArgs e) =>
            Run(new BackgroundColourCommand(Color.FromName(Editor.cbBackground.Text)));

        private void CameraFocus_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraFocusCommand(new Vector3(
                (float)Editor.seCameraFocusX.Value,
                (float)Editor.seCameraFocusY.Value,
                (float)Editor.seCameraFocusZ.Value)));

        private void CameraPosition_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraPositionCommand(new Vector3(
                (float)Editor.seCameraPositionX.Value,
                (float)Editor.seCameraPositionY.Value,
                (float)Editor.seCameraPositionZ.Value)));

        private void FieldOfView_ValueChanged(object sender, EventArgs e) =>
            Run(new FieldOfViewCommand((float)Editor.seFieldOfView.Value));

        private void FPS_ValueChanged(object sender, EventArgs e) =>
            Run(new FpsCommand((float)Editor.seFPS.Value));

        private void FrustumMax_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMaxCommand(new Vector3(
                (float)Editor.seFrustumMaxX.Value,
                (float)Editor.seFrustumMaxY.Value,
                (float)Editor.seFrustumMaxZ.Value)));

        private void FrustumMin_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMinCommand(new Vector3(
                (float)Editor.seFrustumMinX.Value,
                (float)Editor.seFrustumMinY.Value,
                (float)Editor.seFrustumMinZ.Value)));

        private void GLSLVersion_SelectedValueChanged(object sender, EventArgs e) =>
            Run(new GLTargetVersionCommand(Editor.cbGLSLVersion.Text));

        private void ProjectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
            Run(new ProjectionTypeCommand((ProjectionType)Editor.cbProjectionType.SelectedIndex));
        }

        private void Samples_ValueChanged(object sender, EventArgs e) =>
            Run(new SamplesCommand((int)Editor.seSamples.Value));

        private void SceneTitle_TextChanged(object sender, EventArgs e)
            => Run(new TitleCommand(Editor.edTitle.Text));

        private void VSync_CheckedChanged(object sender, EventArgs e) =>
            Run(new VSyncCommand(Editor.cbVSync.Checked));

        private void WorldController_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            UpdateProperties(e.PropertyName);

        #endregion

        #region Private Methods

        private void InitLocalControls()
        {
            InitToolTips();
            new ColourController().AddControls(Editor.cbBackground);
        }

        private void InitToolTips()
        {
            SetToolTip(Editor.cbBackground, Resources.Scene_Background);
            SetToolTip(Editor.seCameraFocusX, Resources.Camera_FocusX);
            SetToolTip(Editor.seCameraFocusY, Resources.Camera_FocusY);
            SetToolTip(Editor.seCameraFocusZ, Resources.Camera_FocusZ);
            SetToolTip(Editor.seCameraPositionX, Resources.Camera_PositionX);
            SetToolTip(Editor.seCameraPositionY, Resources.Camera_PositionY);
            SetToolTip(Editor.seCameraPositionZ, Resources.Camera_PositionZ);
            SetToolTip(Editor.seFrustumMaxX, Resources.Projection_FarPlaneX);
            SetToolTip(Editor.seFrustumMaxY, Resources.Projection_FarPlaneY);
            SetToolTip(Editor.seFrustumMaxZ, Resources.Projection_FarPlaneZ);
            SetToolTip(Editor.cbGLSLVersion, Resources.GLSL_TargetVersion);
            SetToolTip(Editor.seFieldOfView, Resources.Projection_FieldOfView);
            SetToolTip(Editor.seFPS, Resources.Scene_FPS);
            SetToolTip(Editor.seFrustumMinX, Resources.Projection_NearPlaneX);
            SetToolTip(Editor.seFrustumMinY, Resources.Projection_NearPlaneY);
            SetToolTip(Editor.seFrustumMinZ, Resources.Projection_NearPlaneZ);
            SetToolTip(Editor.cbProjectionType, Resources.Projection_Type);
            SetToolTip(Editor.seSamples, Resources.Scene_Samples);
            SetToolTip(Editor.edTitle, Resources.Scene_Title);
            SetToolTip(Editor.cbVSync, Resources.Scene_VSync);
        }

        private void Run(ICommand command)
        {
            if (Updating)
                return;
            Updating = true;
            CommandProcessor.Run(command);
            Updating = false;
        }

        private void UpdateAllProperties()
        {
            UpdateProperties(new[]
            {
                PropertyNames.Background,
                PropertyNames.CameraFocus,
                PropertyNames.CameraPosition,
                PropertyNames.FarPlane,
                PropertyNames.FieldOfView,
                PropertyNames.FPS,
                PropertyNames.GLTargetVersion,
                PropertyNames.NearPlane,
                PropertyNames.ProjectionType,
                PropertyNames.Samples,
                PropertyNames.SceneTitle,
                PropertyNames.VSync
            });
            UpdateUI();
        }

        private void UpdateProperties(params string[] propertyNames)
        {
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Background:
                        Editor.cbBackground.Text = Scene.BackgroundColour.Name;
                        break;
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
                    case PropertyNames.FieldOfView:
                        Editor.seFieldOfView.Value = (decimal)Scene.Projection.FieldOfView;
                        break;
                    case PropertyNames.FPS:
                        Editor.seFPS.Value = (decimal)Scene.FPS;
                        break;
                    case PropertyNames.GLTargetVersion:
                        Editor.cbGLSLVersion.Text = Scene.GLTargetVersion;
                        break;
                    case PropertyNames.NearPlane:
                        Editor.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
                        Editor.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
                        Editor.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
                        break;
                    case PropertyNames.ProjectionType:
                        Editor.cbProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
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

        private void UpdateUI()
        {
            var fov = Editor.cbProjectionType.SelectedIndex == (int)ProjectionType.Perspective;
            Editor.seFrustumMinX.Enabled =
            Editor.seFrustumMinY.Enabled =
            Editor.seFrustumMaxX.Enabled =
            Editor.seFrustumMaxY.Enabled =
                !fov;
            Editor.seFieldOfView.Enabled = fov;
        }

        #endregion
    }
}
