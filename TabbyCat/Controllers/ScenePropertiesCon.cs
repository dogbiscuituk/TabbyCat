namespace TabbyCat.Controllers
{
    using Commands;
    using Common.Types;
    using Common.Utils;
    using Controls;
    using OpenTK;
    using Properties;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Views;
    using WeifenLuo.WinFormsUI.Docking;

    internal partial class ScenePropertiesCon : PropertiesCon
    {
        internal ScenePropertiesCon(WorldCon worldCon) : base(worldCon)
        {
            InitCommonControls(ScenePropertiesEdit.TableLayoutPanel);
            InitLocalControls();
        }

        private ScenePropertiesForm _ScenePropertiesForm;

        protected internal override DockContent Form => ScenePropertiesForm;

        protected override ScenePropertiesForm ScenePropertiesForm => _ScenePropertiesForm ?? (_ScenePropertiesForm = new ScenePropertiesForm
        {
            TabText = Resources.ScenePropertiesForm_TabText,
            Text = Resources.ScenePropertiesForm_Text,
            ToolTipText = Resources.ScenePropertiesForm_Text
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
                ScenePropertiesEdit.edTitle.TextChanged += SceneTitle_TextChanged;
                ScenePropertiesEdit.seCameraPositionX.ValueChanged += CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPositionY.ValueChanged += CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPositionZ.ValueChanged += CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPitch.ValueChanged += CameraFocus_ValueChanged;
                ScenePropertiesEdit.seCameraYaw.ValueChanged += CameraFocus_ValueChanged;
                ScenePropertiesEdit.seCameraRoll.ValueChanged += CameraFocus_ValueChanged;
                ScenePropertiesEdit.seProjectionType.SelectedItemChanged += ProjectionType_SelectedItemChanged;
                ScenePropertiesEdit.cbStereo.CheckedChanged += Stereo_CheckedChanged;
                ScenePropertiesEdit.seFieldOfView.ValueChanged += FieldOfView_ValueChanged;
                ScenePropertiesEdit.seFPS.ValueChanged += FPS_ValueChanged;
                ScenePropertiesEdit.seFrustumMinX.ValueChanged += FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMinY.ValueChanged += FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMinZ.ValueChanged += FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxX.ValueChanged += FrustumMax_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxY.ValueChanged += FrustumMax_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxZ.ValueChanged += FrustumMax_ValueChanged;
                ScenePropertiesEdit.cbBackground.SelectedIndexChanged += Background_SelectedIndexChanged;
                ScenePropertiesEdit.cbVSync.CheckedChanged += VSync_CheckedChanged;
                ScenePropertiesEdit.seSampleCount.SelectedItemChanged += Samples_ValueChanged;
                ScenePropertiesEdit.seGLSLVersion.SelectedItemChanged += GLSLVersion_SelectedItemChanged;
                WorldForm.ViewSceneProperties.Click += ViewSceneProperties_Click;
            }
            else
            {
                ScenePropertiesEdit.edTitle.TextChanged -= SceneTitle_TextChanged;
                ScenePropertiesEdit.seCameraPositionX.ValueChanged -= CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPositionY.ValueChanged -= CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPositionZ.ValueChanged -= CameraPosition_ValueChanged;
                ScenePropertiesEdit.seCameraPitch.ValueChanged -= CameraFocus_ValueChanged;
                ScenePropertiesEdit.seCameraYaw.ValueChanged -= CameraFocus_ValueChanged;
                ScenePropertiesEdit.seCameraRoll.ValueChanged -= CameraFocus_ValueChanged;
                ScenePropertiesEdit.seProjectionType.SelectedItemChanged -= ProjectionType_SelectedItemChanged;
                ScenePropertiesEdit.cbStereo.CheckedChanged -= Stereo_CheckedChanged;
                ScenePropertiesEdit.seFieldOfView.ValueChanged -= FieldOfView_ValueChanged;
                ScenePropertiesEdit.seFPS.ValueChanged -= FPS_ValueChanged;
                ScenePropertiesEdit.seFrustumMinX.ValueChanged -= FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMinY.ValueChanged -= FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMinZ.ValueChanged -= FrustumMin_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxX.ValueChanged -= FrustumMax_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxY.ValueChanged -= FrustumMax_ValueChanged;
                ScenePropertiesEdit.seFrustumMaxZ.ValueChanged -= FrustumMax_ValueChanged;
                ScenePropertiesEdit.cbBackground.SelectedIndexChanged -= Background_SelectedIndexChanged;
                ScenePropertiesEdit.cbVSync.CheckedChanged -= VSync_CheckedChanged;
                ScenePropertiesEdit.seSampleCount.SelectedItemChanged -= Samples_ValueChanged;
                ScenePropertiesEdit.seGLSLVersion.SelectedItemChanged -= GLSLVersion_SelectedItemChanged;
                WorldForm.ViewSceneProperties.Click -= ViewSceneProperties_Click;
            }
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_ViewSceneProperties, WorldForm.ViewSceneProperties);
            Localize(Resources.Control_Scene_Title, ScenePropertiesEdit.lblTitle, ScenePropertiesEdit.edTitle);
            Localize(Resources.Control_Camera_Position, ScenePropertiesEdit.lblPosition);
            Localize(Resources.Control_Camera_PositionX, ScenePropertiesEdit.seCameraPositionX);
            Localize(Resources.Control_Camera_PositionY, ScenePropertiesEdit.seCameraPositionY);
            Localize(Resources.Control_Camera_PositionZ, ScenePropertiesEdit.seCameraPositionZ);
            Localize(Resources.Control_Camera_Direction, ScenePropertiesEdit.lblDirection);
            Localize(Resources.Control_Camera_Pitch, ScenePropertiesEdit.seCameraPitch);
            Localize(Resources.Control_Camera_Yaw, ScenePropertiesEdit.seCameraYaw);
            Localize(Resources.Control_Camera_Roll, ScenePropertiesEdit.seCameraRoll);
            Localize(Resources.Control_Scene_Projection, ScenePropertiesEdit.lblProjection, ScenePropertiesEdit.seProjectionType);
            Localize(Resources.Control_Scene_Stereo, ScenePropertiesEdit.cbStereo);
            Localize(Resources.Control_Scene_FieldOfView, ScenePropertiesEdit.lblFieldOfView, ScenePropertiesEdit.seFieldOfView);
            Localize(Resources.Control_Scene_TargetFPS, ScenePropertiesEdit.lblTargetFPS, ScenePropertiesEdit.seFPS);
            Localize(Resources.Control_Scene_NearPlane, ScenePropertiesEdit.lblNearPlane);
            Localize(Resources.Control_Scene_NearPlaneX, ScenePropertiesEdit.seFrustumMinX);
            Localize(Resources.Control_Scene_NearPlaneY, ScenePropertiesEdit.seFrustumMinY);
            Localize(Resources.Control_Scene_NearPlaneZ, ScenePropertiesEdit.seFrustumMinZ);
            Localize(Resources.Control_Scene_FarPlane, ScenePropertiesEdit.lblFarPlane);
            Localize(Resources.Control_Scene_FarPlaneX, ScenePropertiesEdit.seFrustumMaxX);
            Localize(Resources.Control_Scene_FarPlaneY, ScenePropertiesEdit.seFrustumMaxY);
            Localize(Resources.Control_Scene_FarPlaneZ, ScenePropertiesEdit.seFrustumMaxZ);
            Localize(Resources.Control_Scene_Samples, ScenePropertiesEdit.lblSamples, ScenePropertiesEdit.seSampleCount);
            Localize(Resources.Control_Scene_GLVersion, ScenePropertiesEdit.lblGLSLVersion, ScenePropertiesEdit.seGLSLVersion);
            Localize(Resources.Control_Scene_Background, ScenePropertiesEdit.lblBackground, ScenePropertiesEdit.cbBackground);
            Localize(Resources.Control_Scene_VSync, ScenePropertiesEdit.cbVSync);
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
                        ScenePropertiesEdit.cbBackground.Text = Scene.BackgroundColour.Name;
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
                        ScenePropertiesEdit.seFrustumMaxX.Value = (decimal)Scene.Projection.FrustumMax.X;
                        ScenePropertiesEdit.seFrustumMaxY.Value = (decimal)Scene.Projection.FrustumMax.Y;
                        ScenePropertiesEdit.seFrustumMaxZ.Value = (decimal)Scene.Projection.FrustumMax.Z;
                        break;
                    case PropertyNames.FieldOfView:
                        ScenePropertiesEdit.seFieldOfView.Value = (decimal)Scene.Projection.FieldOfView;
                        break;
                    case PropertyNames.FPS:
                        ScenePropertiesEdit.seFPS.Value = (decimal)Scene.FPS;
                        break;
                    case PropertyNames.GLTargetVersion:
                        ScenePropertiesEdit.seGLSLVersion.Text = Scene.GLTargetVersion;
                        break;
                    case PropertyNames.NearPlane:
                        ScenePropertiesEdit.seFrustumMinX.Value = (decimal)Scene.Projection.FrustumMin.X;
                        ScenePropertiesEdit.seFrustumMinY.Value = (decimal)Scene.Projection.FrustumMin.Y;
                        ScenePropertiesEdit.seFrustumMinZ.Value = (decimal)Scene.Projection.FrustumMin.Z;
                        break;
                    case PropertyNames.ProjectionType:
                        ScenePropertiesEdit.seProjectionType.SelectedIndex = (int)Scene.Projection.ProjectionType;
                        break;
                    case PropertyNames.Samples:
                        ScenePropertiesEdit.seSampleCount.Text = Scene.Samples.ToString(CultureInfo.CurrentCulture);
                        break;
                    case PropertyNames.SceneTitle:
                        ScenePropertiesEdit.edTitle.Text = Scene.Title;
                        break;
                    case PropertyNames.Stereo:
                        ScenePropertiesEdit.cbStereo.Checked = Scene.Stereo;
                        break;
                    case PropertyNames.VSync:
                        ScenePropertiesEdit.cbVSync.Checked = Scene.VSync;
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
            ScenePropertiesEdit.seProjectionType.Items.AddRange(Enum.GetNames(typeof(ProjectionType)));
            ScenePropertiesEdit.seFieldOfView.Minimum = 1;
            ScenePropertiesEdit.seFieldOfView.Maximum = 179;
            ScenePropertiesEdit.seFPS.Minimum = 1;
            ScenePropertiesEdit.seFPS.Maximum = 300;
            InitDomainUpDownItems(ScenePropertiesEdit.seGLSLVersion, Settings.Default.GLSLVersions);
            InitDomainUpDownItems(ScenePropertiesEdit.seSampleCount, Settings.Default.SampleCounts);
            new ColourCon().AddControls(ScenePropertiesEdit.cbBackground);
        }

        private void UpdateCameraFocus()
        {
            ScenePropertiesEdit.seCameraPitch.Value = (decimal)Scene.Camera.Focus.X;
            ScenePropertiesEdit.seCameraYaw.Value = (decimal)Scene.Camera.Focus.Y;
            ScenePropertiesEdit.seCameraRoll.Value = (decimal)Scene.Camera.Focus.Z;
        }

        private void UpdateCameraPosition()
        {
            ScenePropertiesEdit.seCameraPositionX.Value = (decimal)Scene.Camera.Position.X;
            ScenePropertiesEdit.seCameraPositionY.Value = (decimal)Scene.Camera.Position.Y;
            ScenePropertiesEdit.seCameraPositionZ.Value = (decimal)Scene.Camera.Position.Z;
        }

        private void UpdateUI()
        {
            var perspective = ScenePropertiesEdit.seProjectionType.SelectedIndex == (int)ProjectionType.Perspective;
            ScenePropertiesEdit.lblFieldOfView.Visible =
            ScenePropertiesEdit.seFieldOfView.Visible = perspective;
            ScenePropertiesEdit.seFrustumMinX.Visible =
            ScenePropertiesEdit.seFrustumMinY.Visible =
            ScenePropertiesEdit.seFrustumMaxX.Visible =
            ScenePropertiesEdit.seFrustumMaxY.Visible = !perspective;
        }
    }

    /// <summary>
    /// Command runners.
    /// </summary>
    partial class ScenePropertiesCon
    {
        private void Background_SelectedIndexChanged(object sender, EventArgs e) => Run(new BackgroundColourCommand(Color.FromName(ScenePropertiesEdit.cbBackground.Text)));

        private void CameraFocus_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraFocusCommand(new Vector3(
                (float)ScenePropertiesEdit.seCameraPitch.Value,
                (float)ScenePropertiesEdit.seCameraYaw.Value,
                (float)ScenePropertiesEdit.seCameraRoll.Value)));

        private void CameraPosition_ValueChanged(object sender, EventArgs e) =>
            Run(new CameraPositionCommand(new Vector3(
                (float)ScenePropertiesEdit.seCameraPositionX.Value,
                (float)ScenePropertiesEdit.seCameraPositionY.Value,
                (float)ScenePropertiesEdit.seCameraPositionZ.Value)));

        private void FieldOfView_ValueChanged(object sender, EventArgs e) => Run(new FieldOfViewCommand((float)ScenePropertiesEdit.seFieldOfView.Value));

        private void FPS_ValueChanged(object sender, EventArgs e) =>  Run(new FpsCommand((float)ScenePropertiesEdit.seFPS.Value));

        private void FrustumMax_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMaxCommand(new Vector3(
                (float)ScenePropertiesEdit.seFrustumMaxX.Value,
                (float)ScenePropertiesEdit.seFrustumMaxY.Value,
                (float)ScenePropertiesEdit.seFrustumMaxZ.Value)));

        private void FrustumMin_ValueChanged(object sender, EventArgs e) =>
            Run(new FrustumMinCommand(new Vector3(
                (float)ScenePropertiesEdit.seFrustumMinX.Value,
                (float)ScenePropertiesEdit.seFrustumMinY.Value,
                (float)ScenePropertiesEdit.seFrustumMinZ.Value)));

        private void GLSLVersion_SelectedItemChanged(object sender, EventArgs e) => Run(new GLTargetVersionCommand(ScenePropertiesEdit.seGLSLVersion.Text));

        private void ProjectionType_SelectedItemChanged(object sender, EventArgs e) => Run(new ProjectionTypeCommand((ProjectionType)ScenePropertiesEdit.seProjectionType.SelectedIndex));

        private void Samples_ValueChanged(object sender, EventArgs e) => Run(new SamplesCommand(int.Parse(ScenePropertiesEdit.seSampleCount.Text, CultureInfo.CurrentCulture)));

        private void SceneTitle_TextChanged(object sender, EventArgs e) => Run(new TitleCommand(ScenePropertiesEdit.edTitle.Text));

        private void Stereo_CheckedChanged(object sender, EventArgs e) => Run(new StereoCommand(ScenePropertiesEdit.cbStereo.Checked));

        private void ViewSceneProperties_Click(object sender, EventArgs e) => ToggleVisibility();

        private void VSync_CheckedChanged(object sender, EventArgs e) => Run(new VSyncCommand(ScenePropertiesEdit.cbVSync.Checked));
    }
}
