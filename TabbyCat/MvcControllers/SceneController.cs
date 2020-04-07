namespace TabbyCat.MvcControllers
{
    using OpenTK;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Properties;

    internal class SceneController : ShaderSetController
    {
        #region Constructors

        internal SceneController(WorldController worldController)
            : base(worldController)
        {
            InitCommonControls(Editor.TableLayoutPanel);
            InitLocalControls();
        }

        #endregion

        #region Fields & Properties

        protected override string[] AllProperties => new[]
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
        };

        #endregion

        #region Protected Internal Methods

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                Editor.edTitle.TextChanged += SceneTitle_TextChanged;
                Editor.seCameraPositionX.ValueChanged += CameraPosition_ValueChanged;
                Editor.seCameraPositionY.ValueChanged += CameraPosition_ValueChanged;
                Editor.seCameraPositionZ.ValueChanged += CameraPosition_ValueChanged;
                Editor.seCameraPitch.ValueChanged += CameraFocus_ValueChanged;
                Editor.seCameraYaw.ValueChanged += CameraFocus_ValueChanged;
                Editor.seCameraRoll.ValueChanged += CameraFocus_ValueChanged;
                Editor.seProjectionType.SelectedItemChanged += ProjectionType_SelectedItemChanged;
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
                Editor.seSampleCount.SelectedItemChanged += Samples_ValueChanged;
                Editor.seGLSLVersion.SelectedItemChanged += GLSLVersion_SelectedItemChanged;
            }
            else
            {
                Editor.edTitle.TextChanged -= SceneTitle_TextChanged;
                Editor.seCameraPositionX.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraPositionY.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraPositionZ.ValueChanged -= CameraPosition_ValueChanged;
                Editor.seCameraPitch.ValueChanged -= CameraFocus_ValueChanged;
                Editor.seCameraYaw.ValueChanged -= CameraFocus_ValueChanged;
                Editor.seCameraRoll.ValueChanged -= CameraFocus_ValueChanged;
                Editor.seProjectionType.SelectedItemChanged -= ProjectionType_SelectedItemChanged;
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
                Editor.seSampleCount.SelectedItemChanged -= Samples_ValueChanged;
                Editor.seGLSLVersion.SelectedItemChanged -= GLSLVersion_SelectedItemChanged;
            }
        }

        #endregion

        #region Protected Methods

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Control_Scene_Title, Editor.lblTitle, Editor.edTitle);
            Localize(Resources.Control_Camera_Position, Editor.lblPosition);
            Localize(Resources.Control_Camera_PositionX, Editor.seCameraPositionX);
            Localize(Resources.Control_Camera_PositionY, Editor.seCameraPositionY);
            Localize(Resources.Control_Camera_PositionZ, Editor.seCameraPositionZ);
            Localize(Resources.Control_Camera_Direction, Editor.lblDirection);
            Localize(Resources.Control_Camera_Pitch, Editor.seCameraPitch);
            Localize(Resources.Control_Camera_Yaw, Editor.seCameraYaw);
            Localize(Resources.Control_Camera_Roll, Editor.seCameraRoll);
            Localize(Resources.Control_Scene_Projection, Editor.lblProjection, Editor.seProjectionType);
            Localize(Resources.Control_Scene_Stereo, Editor.cbStereo);
            Localize(Resources.Control_Scene_FieldOfView, Editor.lblFieldOfView, Editor.seFieldOfView);
            Localize(Resources.Control_Scene_TargetFPS, Editor.lblTargetFPS, Editor.seFPS);
            Localize(Resources.Control_Scene_NearPlane, Editor.lblNearPlane);
            Localize(Resources.Control_Scene_NearPlaneX, Editor.seFrustumMinX);
            Localize(Resources.Control_Scene_NearPlaneY, Editor.seFrustumMinY);
            Localize(Resources.Control_Scene_NearPlaneZ, Editor.seFrustumMinZ);
            Localize(Resources.Control_Scene_FarPlane, Editor.lblFarPlane);
            Localize(Resources.Control_Scene_FarPlaneX, Editor.seFrustumMaxX);
            Localize(Resources.Control_Scene_FarPlaneY, Editor.seFrustumMaxY);
            Localize(Resources.Control_Scene_FarPlaneZ, Editor.seFrustumMaxZ);
            Localize(Resources.Control_Scene_Samples, Editor.lblSamples, Editor.seSampleCount);
            Localize(Resources.Control_Scene_GLVersion, Editor.lblGLSLVersion, Editor.seGLSLVersion);
            Localize(Resources.Control_Scene_Background, Editor.lblBackground, Editor.cbBackground);
            Localize(Resources.Control_Scene_VSync, Editor.cbVSync);
        }

        protected override void UpdateProperties(params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.ProjectionType:
                        UpdateUI();
                        break;
                }
            if (Updating)
                return;
            Updating = true;
            foreach (var propertyName in propertyNames)
                switch (propertyName)
                {
                    case PropertyNames.Background:
                        Editor.cbBackground.Text = Scene.BackgroundColour.Name;
                        break;
                    case PropertyNames.Camera:
                        UpdateCameraPosition();
                        UpdateCameraFocus();
                        break;
                    case PropertyNames.CameraFocus:
                        UpdateCameraFocus();
                        break;
                    case PropertyNames.CameraPosition:
                        UpdateCameraPosition();
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
                        Editor.seGLSLVersion.Text = Scene.GLTargetVersion;
                        break;
                    case PropertyNames.NearPlane:
                        Editor.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
                        Editor.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
                        Editor.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
                        break;
                    case PropertyNames.ProjectionType:
                        Editor.seProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
                        break;
                    case PropertyNames.Samples:
                        Editor.seSampleCount.Text = Scene.Samples.ToString();
                        break;
                    case PropertyNames.SceneTitle:
                        Editor.edTitle.Text = Scene.Title;
                        break;
                    case PropertyNames.VSync:
                        Editor.cbVSync.Checked = Scene.VSync;
                        break;
                }
            Updating = false;
            UpdateUI();
        }

        #endregion

        #region Private Properties

        private SceneEdit Editor => PropertiesEdit.SceneEdit;

        #endregion

        #region Private Event Handlers

        private void Background_SelectedIndexChanged(object sender, EventArgs e) =>
            Run(new BackgroundColourCommand(Color.FromName(Editor.cbBackground.Text)));

        private void CameraFocus_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraFocusCommand(new Vector3(
                (float)Editor.seCameraPitch.Value,
                (float)Editor.seCameraYaw.Value,
                (float)Editor.seCameraRoll.Value)));

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

        private void GLSLVersion_SelectedItemChanged(object sender, EventArgs e) =>
            Run(new GLTargetVersionCommand(Editor.seGLSLVersion.Text));

        private void ProjectionType_SelectedItemChanged(object sender, EventArgs e) =>
            Run(new ProjectionTypeCommand((ProjectionType)Editor.seProjectionType.SelectedIndex));

        private void Samples_ValueChanged(object sender, EventArgs e) =>
            Run(new SamplesCommand(int.Parse(Editor.seSampleCount.Text)));

        private void SceneTitle_TextChanged(object sender, EventArgs e) =>
            Run(new TitleCommand(Editor.edTitle.Text));

        private void VSync_CheckedChanged(object sender, EventArgs e) =>
            Run(new VSyncCommand(Editor.cbVSync.Checked));

        #endregion

        #region Private Methods

        private static void InitDomainUpDownItems(DomainUpDown control, string items)
        {
            control.Items.Clear();
            control.Items.AddRange(items.Split('|').Reverse().ToList());
        }

        private void InitLocalControls()
        {
            Editor.seProjectionType.Items.AddRange(Enum.GetNames(typeof(ProjectionType)));
            Editor.seFieldOfView.Minimum = 1;
            Editor.seFieldOfView.Maximum = 179;
            Editor.seFPS.Minimum = 1;
            Editor.seFPS.Maximum = 300;
            InitDomainUpDownItems(Editor.seGLSLVersion, Settings.Default.GLSLVersions);
            InitDomainUpDownItems(Editor.seSampleCount, Settings.Default.SampleCounts);
            new ColourController().AddControls(Editor.cbBackground);
        }

        private void Run(ICommand command)
        {
            if (Updating)
                return;
            Updating = true;
            CommandProcessor.Run(command);
            Updating = false;
        }

        private void UpdateCameraFocus()
        {
            Editor.seCameraPitch.Value = (decimal)Scene.Camera.Focus.X;
            Editor.seCameraYaw.Value = (decimal)Scene.Camera.Focus.Y;
            Editor.seCameraRoll.Value = (decimal)Scene.Camera.Focus.Z;
        }

        private void UpdateCameraPosition()
        {
            Editor.seCameraPositionX.Value = (decimal)Scene.Camera.Position.X;
            Editor.seCameraPositionY.Value = (decimal)Scene.Camera.Position.Y;
            Editor.seCameraPositionZ.Value = (decimal)Scene.Camera.Position.Z;
        }

        private void UpdateUI()
        {
            var perspective = Editor.seProjectionType.SelectedIndex == (int)ProjectionType.Perspective;
            Editor.lblFieldOfView.Visible =
            Editor.seFieldOfView.Visible = perspective;
            Editor.seFrustumMinX.Visible =
            Editor.seFrustumMinY.Visible =
            Editor.seFrustumMaxX.Visible =
            Editor.seFrustumMaxY.Visible = !perspective;
        }

        #endregion
    }
}
