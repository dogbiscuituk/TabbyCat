namespace TabbyCat.Controllers
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using OpenTK;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Common.Utility;
    using TabbyCat.Controls;
    using TabbyCat.Properties;
    using TabbyCat.Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal partial class SceneCon : ShaderSetCon
    {
        internal SceneCon(WorldCon worldCon) : base(worldCon)
        {
            InitCommonControls(SceneEdit.TableLayoutPanel);
            InitLocalControls();
        }

        private SceneForm _SceneForm;

        protected internal override DockContent Form => SceneForm;

        protected override SceneForm SceneForm => _SceneForm ?? (_SceneForm = new SceneForm
        {
            TabText = Resources.SceneForm_TabText,
            Text = Resources.SceneForm_Text,
            ToolTipText = Resources.SceneForm_Text
        });

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
            PropertyNames.Stereo,
            PropertyNames.VSync
        };

        protected internal override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                SceneEdit.edTitle.TextChanged += SceneTitle_TextChanged;
                SceneEdit.seCameraPositionX.ValueChanged += CameraPosition_ValueChanged;
                SceneEdit.seCameraPositionY.ValueChanged += CameraPosition_ValueChanged;
                SceneEdit.seCameraPositionZ.ValueChanged += CameraPosition_ValueChanged;
                SceneEdit.seCameraPitch.ValueChanged += CameraFocus_ValueChanged;
                SceneEdit.seCameraYaw.ValueChanged += CameraFocus_ValueChanged;
                SceneEdit.seCameraRoll.ValueChanged += CameraFocus_ValueChanged;
                SceneEdit.seProjectionType.SelectedItemChanged += ProjectionType_SelectedItemChanged;
                SceneEdit.cbStereo.CheckedChanged += Stereo_CheckedChanged;
                SceneEdit.seFieldOfView.ValueChanged += FieldOfView_ValueChanged;
                SceneEdit.seFPS.ValueChanged += FPS_ValueChanged;
                SceneEdit.seFrustumMinX.ValueChanged += FrustumMin_ValueChanged;
                SceneEdit.seFrustumMinY.ValueChanged += FrustumMin_ValueChanged;
                SceneEdit.seFrustumMinZ.ValueChanged += FrustumMin_ValueChanged;
                SceneEdit.seFrustumMaxX.ValueChanged += FrustumMax_ValueChanged;
                SceneEdit.seFrustumMaxY.ValueChanged += FrustumMax_ValueChanged;
                SceneEdit.seFrustumMaxZ.ValueChanged += FrustumMax_ValueChanged;
                SceneEdit.cbBackground.SelectedIndexChanged += Background_SelectedIndexChanged;
                SceneEdit.cbVSync.CheckedChanged += VSync_CheckedChanged;
                SceneEdit.seSampleCount.SelectedItemChanged += Samples_ValueChanged;
                SceneEdit.seGLSLVersion.SelectedItemChanged += GLSLVersion_SelectedItemChanged;
            }
            else
            {
                SceneEdit.edTitle.TextChanged -= SceneTitle_TextChanged;
                SceneEdit.seCameraPositionX.ValueChanged -= CameraPosition_ValueChanged;
                SceneEdit.seCameraPositionY.ValueChanged -= CameraPosition_ValueChanged;
                SceneEdit.seCameraPositionZ.ValueChanged -= CameraPosition_ValueChanged;
                SceneEdit.seCameraPitch.ValueChanged -= CameraFocus_ValueChanged;
                SceneEdit.seCameraYaw.ValueChanged -= CameraFocus_ValueChanged;
                SceneEdit.seCameraRoll.ValueChanged -= CameraFocus_ValueChanged;
                SceneEdit.seProjectionType.SelectedItemChanged -= ProjectionType_SelectedItemChanged;
                SceneEdit.cbStereo.CheckedChanged -= Stereo_CheckedChanged;
                SceneEdit.seFieldOfView.ValueChanged -= FieldOfView_ValueChanged;
                SceneEdit.seFPS.ValueChanged -= FPS_ValueChanged;
                SceneEdit.seFrustumMinX.ValueChanged -= FrustumMin_ValueChanged;
                SceneEdit.seFrustumMinY.ValueChanged -= FrustumMin_ValueChanged;
                SceneEdit.seFrustumMinZ.ValueChanged -= FrustumMin_ValueChanged;
                SceneEdit.seFrustumMaxX.ValueChanged -= FrustumMax_ValueChanged;
                SceneEdit.seFrustumMaxY.ValueChanged -= FrustumMax_ValueChanged;
                SceneEdit.seFrustumMaxZ.ValueChanged -= FrustumMax_ValueChanged;
                SceneEdit.cbBackground.SelectedIndexChanged -= Background_SelectedIndexChanged;
                SceneEdit.cbVSync.CheckedChanged -= VSync_CheckedChanged;
                SceneEdit.seSampleCount.SelectedItemChanged -= Samples_ValueChanged;
                SceneEdit.seGLSLVersion.SelectedItemChanged -= GLSLVersion_SelectedItemChanged;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.Control_Scene_Title, SceneEdit.lblTitle, SceneEdit.edTitle);
            Localize(Resources.Control_Camera_Position, SceneEdit.lblPosition);
            Localize(Resources.Control_Camera_PositionX, SceneEdit.seCameraPositionX);
            Localize(Resources.Control_Camera_PositionY, SceneEdit.seCameraPositionY);
            Localize(Resources.Control_Camera_PositionZ, SceneEdit.seCameraPositionZ);
            Localize(Resources.Control_Camera_Direction, SceneEdit.lblDirection);
            Localize(Resources.Control_Camera_Pitch, SceneEdit.seCameraPitch);
            Localize(Resources.Control_Camera_Yaw, SceneEdit.seCameraYaw);
            Localize(Resources.Control_Camera_Roll, SceneEdit.seCameraRoll);
            Localize(Resources.Control_Scene_Projection, SceneEdit.lblProjection, SceneEdit.seProjectionType);
            Localize(Resources.Control_Scene_Stereo, SceneEdit.cbStereo);
            Localize(Resources.Control_Scene_FieldOfView, SceneEdit.lblFieldOfView, SceneEdit.seFieldOfView);
            Localize(Resources.Control_Scene_TargetFPS, SceneEdit.lblTargetFPS, SceneEdit.seFPS);
            Localize(Resources.Control_Scene_NearPlane, SceneEdit.lblNearPlane);
            Localize(Resources.Control_Scene_NearPlaneX, SceneEdit.seFrustumMinX);
            Localize(Resources.Control_Scene_NearPlaneY, SceneEdit.seFrustumMinY);
            Localize(Resources.Control_Scene_NearPlaneZ, SceneEdit.seFrustumMinZ);
            Localize(Resources.Control_Scene_FarPlane, SceneEdit.lblFarPlane);
            Localize(Resources.Control_Scene_FarPlaneX, SceneEdit.seFrustumMaxX);
            Localize(Resources.Control_Scene_FarPlaneY, SceneEdit.seFrustumMaxY);
            Localize(Resources.Control_Scene_FarPlaneZ, SceneEdit.seFrustumMaxZ);
            Localize(Resources.Control_Scene_Samples, SceneEdit.lblSamples, SceneEdit.seSampleCount);
            Localize(Resources.Control_Scene_GLVersion, SceneEdit.lblGLSLVersion, SceneEdit.seGLSLVersion);
            Localize(Resources.Control_Scene_Background, SceneEdit.lblBackground, SceneEdit.cbBackground);
            Localize(Resources.Control_Scene_VSync, SceneEdit.cbVSync);
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
                        SceneEdit.cbBackground.Text = Scene.BackgroundColour.Name;
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
                        SceneEdit.seFrustumMaxX.Value = (decimal)Scene.Projection.FrustumMax.X;
                        SceneEdit.seFrustumMaxY.Value = (decimal)Scene.Projection.FrustumMax.Y;
                        SceneEdit.seFrustumMaxZ.Value = (decimal)Scene.Projection.FrustumMax.Z;
                        break;
                    case PropertyNames.FieldOfView:
                        SceneEdit.seFieldOfView.Value = (decimal)Scene.Projection.FieldOfView;
                        break;
                    case PropertyNames.FPS:
                        SceneEdit.seFPS.Value = (decimal)Scene.FPS;
                        break;
                    case PropertyNames.GLTargetVersion:
                        SceneEdit.seGLSLVersion.Text = Scene.GLTargetVersion;
                        break;
                    case PropertyNames.NearPlane:
                        SceneEdit.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
                        SceneEdit.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
                        SceneEdit.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
                        break;
                    case PropertyNames.ProjectionType:
                        SceneEdit.seProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
                        break;
                    case PropertyNames.Samples:
                        SceneEdit.seSampleCount.Text = Scene.Samples.ToString(CultureInfo.CurrentCulture);
                        break;
                    case PropertyNames.SceneTitle:
                        SceneEdit.edTitle.Text = Scene.Title;
                        break;
                    case PropertyNames.Stereo:
                        SceneEdit.cbStereo.Checked = Scene.Stereo;
                        break;
                    case PropertyNames.VSync:
                        SceneEdit.cbVSync.Checked = Scene.VSync;
                        break;
                }
            Updating = false;
            UpdateUI();
        }

        private static void InitDomainUpDownItems(DomainUpDown control, string items)
        {
            control.Items.Clear();
            control.Items.AddRange(items.Split('|').Reverse().ToList());
        }

        private void InitLocalControls()
        {
            SceneEdit.seProjectionType.Items.AddRange(Enum.GetNames(typeof(ProjectionType)));
            SceneEdit.seFieldOfView.Minimum = 1;
            SceneEdit.seFieldOfView.Maximum = 179;
            SceneEdit.seFPS.Minimum = 1;
            SceneEdit.seFPS.Maximum = 300;
            InitDomainUpDownItems(SceneEdit.seGLSLVersion, Settings.Default.GLSLVersions);
            InitDomainUpDownItems(SceneEdit.seSampleCount, Settings.Default.SampleCounts);
            new ColourCon().AddControls(SceneEdit.cbBackground);
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
            SceneEdit.seCameraPitch.Value = (decimal)Scene.Camera.Focus.X;
            SceneEdit.seCameraYaw.Value = (decimal)Scene.Camera.Focus.Y;
            SceneEdit.seCameraRoll.Value = (decimal)Scene.Camera.Focus.Z;
        }

        private void UpdateCameraPosition()
        {
            SceneEdit.seCameraPositionX.Value = (decimal)Scene.Camera.Position.X;
            SceneEdit.seCameraPositionY.Value = (decimal)Scene.Camera.Position.Y;
            SceneEdit.seCameraPositionZ.Value = (decimal)Scene.Camera.Position.Z;
        }

        private void UpdateUI()
        {
            var perspective = SceneEdit.seProjectionType.SelectedIndex == (int)ProjectionType.Perspective;
            SceneEdit.lblFieldOfView.Visible =
            SceneEdit.seFieldOfView.Visible = perspective;
            SceneEdit.seFrustumMinX.Visible =
            SceneEdit.seFrustumMinY.Visible =
            SceneEdit.seFrustumMaxX.Visible =
            SceneEdit.seFrustumMaxY.Visible = !perspective;
        }
    }

    /// <summary>
    /// Command runners.
    /// </summary>
    partial class SceneCon
    {
        private void Background_SelectedIndexChanged(object sender, EventArgs e) =>
            Run(new BackgroundColourCommand(Color.FromName(SceneEdit.cbBackground.Text)));

        private void CameraFocus_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraFocusCommand(new Vector3(
                (float)SceneEdit.seCameraPitch.Value,
                (float)SceneEdit.seCameraYaw.Value,
                (float)SceneEdit.seCameraRoll.Value)));

        private void CameraPosition_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraPositionCommand(new Vector3(
                (float)SceneEdit.seCameraPositionX.Value,
                (float)SceneEdit.seCameraPositionY.Value,
                (float)SceneEdit.seCameraPositionZ.Value)));

        private void FieldOfView_ValueChanged(object sender, EventArgs e) =>
            Run(new FieldOfViewCommand((float)SceneEdit.seFieldOfView.Value));

        private void FPS_ValueChanged(object sender, EventArgs e) =>
            Run(new FpsCommand((float)SceneEdit.seFPS.Value));

        private void FrustumMax_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMaxCommand(new Vector3(
                (float)SceneEdit.seFrustumMaxX.Value,
                (float)SceneEdit.seFrustumMaxY.Value,
                (float)SceneEdit.seFrustumMaxZ.Value)));

        private void FrustumMin_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMinCommand(new Vector3(
                (float)SceneEdit.seFrustumMinX.Value,
                (float)SceneEdit.seFrustumMinY.Value,
                (float)SceneEdit.seFrustumMinZ.Value)));

        private void GLSLVersion_SelectedItemChanged(object sender, EventArgs e) =>
            Run(new GLTargetVersionCommand(SceneEdit.seGLSLVersion.Text));

        private void ProjectionType_SelectedItemChanged(object sender, EventArgs e) =>
            Run(new ProjectionTypeCommand((ProjectionType)SceneEdit.seProjectionType.SelectedIndex));

        private void Samples_ValueChanged(object sender, EventArgs e) =>
            Run(new SamplesCommand(int.Parse(SceneEdit.seSampleCount.Text, CultureInfo.CurrentCulture)));

        private void SceneTitle_TextChanged(object sender, EventArgs e) =>
            Run(new TitleCommand(SceneEdit.edTitle.Text));

        private void Stereo_CheckedChanged(object sender, EventArgs e) =>
            Run(new StereoCommand(SceneEdit.cbStereo.Checked));

        private void VSync_CheckedChanged(object sender, EventArgs e) =>
            Run(new VSyncCommand(SceneEdit.cbVSync.Checked));
    }
}
