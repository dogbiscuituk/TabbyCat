namespace TabbyCat.Controllers
{
    using Commands;
    using OpenTK;
    using Properties;
    using System;
    using Types;

    public class CameraCon : LocalizationCon
    {
        public CameraCon(WorldCon worldCon) : base(worldCon) => SetDefaultCamera();

        private const float CameraBump = 0.1f;

        private Camera _defaultCamera;

        public override void Connect(bool connect)
        {
            base.Connect(connect);
            if (connect)
            {
                WorldForm.CameraStrafeLeft.Click += CameraMoveLeft_Click;
                WorldForm.CameraStrafeRight.Click += CameraMoveRight_Click;
                WorldForm.CameraMoveForward.Click += CameraMoveForward_Click;
                WorldForm.CameraMoveBack.Click += CameraMoveBack_Click;
                WorldForm.CameraStrafeUp.Click += CameraMoveUp_Click;
                WorldForm.CameraStrafeDown.Click += CameraMoveDown_Click;
                WorldForm.CameraMoveLeft.Click += CameraRotateLeft_Click;
                WorldForm.CameraMoveRight.Click += CameraRotateRight_Click;
                WorldForm.CameraMoveUp.Click += CameraRotateUp_Click;
                WorldForm.CameraMoveDown.Click += CameraRotateDown_Click;
                WorldForm.CameraReset.Click += CameraReset_Click;
            }
            else
            {
                WorldForm.CameraStrafeLeft.Click -= CameraMoveLeft_Click;
                WorldForm.CameraStrafeRight.Click -= CameraMoveRight_Click;
                WorldForm.CameraMoveForward.Click -= CameraMoveForward_Click;
                WorldForm.CameraMoveBack.Click -= CameraMoveBack_Click;
                WorldForm.CameraStrafeUp.Click -= CameraMoveUp_Click;
                WorldForm.CameraStrafeDown.Click -= CameraMoveDown_Click;
                WorldForm.CameraMoveLeft.Click -= CameraRotateLeft_Click;
                WorldForm.CameraMoveRight.Click -= CameraRotateRight_Click;
                WorldForm.CameraMoveUp.Click -= CameraRotateUp_Click;
                WorldForm.CameraMoveDown.Click -= CameraRotateDown_Click;
                WorldForm.CameraReset.Click -= CameraReset_Click;
            }
        }

        public void SetDefaultCamera() => _defaultCamera = new Camera(Camera);

        private void CameraMoveBack_Click(object sender, EventArgs e) => CameraMoveFront(-1);

        private void CameraMoveDown_Click(object sender, EventArgs e) => CameraMoveUp(-1);

        private void CameraMoveForward_Click(object sender, EventArgs e) => CameraMoveFront(+1);

        private void CameraMoveLeft_Click(object sender, EventArgs e) => CameraMoveRight(-1);

        private void CameraMoveRight_Click(object sender, EventArgs e) => CameraMoveRight(+1);

        private void CameraMoveUp_Click(object sender, EventArgs e) => CameraMoveUp(+1);

        private void CameraRotateDown_Click(object sender, EventArgs e) => CameraRotateUp(-1);

        private void CameraRotateLeft_Click(object sender, EventArgs e) => CameraRotateRight(-1);

        private void CameraRotateRight_Click(object sender, EventArgs e) => CameraRotateRight(+1);

        private void CameraRotateUp_Click(object sender, EventArgs e) => CameraRotateUp(+1);

        private void CameraReset_Click(object sender, EventArgs e) => CameraReset();

        private void CameraMoveFront(int delta) => CameraMove(Camera.Ufront, delta, false);

        private void CameraMoveRight(int delta) => CameraMove(Camera.Uright, delta, true);

        private void CameraMoveUp(int delta) => CameraMove(Camera.Uup, delta, true);

        private void CameraRotateRight(int delta) => CameraRotate(Camera.Uright, delta);

        private void CameraRotateUp(int delta) => CameraRotate(Camera.Uup, delta);

        private void CameraMove(Vector3 basis, float delta, bool strafe)
        {
            var shift = delta * CameraBump * basis;
            RunCameraCommand(strafe
                ? new Camera(Camera.Position + shift, Camera.Focus + shift)
                : new Camera(Camera.Position + shift, Camera.Focus));
        }

        private void CameraReset() => RunCameraCommand(_defaultCamera);

        private void CameraRotate(Vector3 basis, float delta)
        {
            Vector3
                f = Camera.Focus,
                p = Camera.Position - f,
                q = p + delta * CameraBump * basis;
            RunCameraCommand(new Camera(q * p.Length / q.Length + f, f));
        }

        protected override void Localize()
        {
            base.Localize();
            Localize(Resources.WorldForm_CameraMenu, WorldForm.CameraMenu);
            Localize(Resources.WorldForm_Camera_Strafe, WorldForm.CameraStrafe);
            Localize(Resources.WorldForm_CameraStrafeDown, WorldForm.CameraStrafeDown);
            Localize(Resources.WorldForm_CameraStrafeLeft, WorldForm.CameraStrafeLeft);
            Localize(Resources.WorldForm_CameraStrafeRight, WorldForm.CameraStrafeRight);
            Localize(Resources.WorldForm_CameraStrafeUp, WorldForm.CameraStrafeUp);
            Localize(Resources.WorldForm_Camera_Move, WorldForm.CameraMove);
            Localize(Resources.WorldForm_CameraMoveDown, WorldForm.CameraMoveDown);
            Localize(Resources.WorldForm_CameraMoveLeft, WorldForm.CameraMoveLeft);
            Localize(Resources.WorldForm_CameraMoveRight, WorldForm.CameraMoveRight);
            Localize(Resources.WorldForm_CameraMoveUp, WorldForm.CameraMoveUp);
            Localize(Resources.WorldForm_CameraMoveForward, WorldForm.CameraMoveForward);
            Localize(Resources.WorldForm_CameraMoveBack, WorldForm.CameraMoveBack);
            Localize(Resources.WorldForm_CameraRollLeft, WorldForm.CameraRollLeft);
            Localize(Resources.WorldForm_CameraRollRight, WorldForm.CameraRollRight);
            Localize(Resources.WorldForm_CameraReset, WorldForm.CameraReset);
        }

        private void RunCameraCommand(Camera camera) => Run(new CameraCommand(camera));
    }
}
