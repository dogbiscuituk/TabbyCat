namespace TabbyCat.Controllers
{
    using OpenTK;
    using System;
    using TabbyCat.Commands;
    using TabbyCat.Common.Types;
    using TabbyCat.Views;

    internal class CameraController : LocalizationController
    {
        internal CameraController(WorldController worldController) : base(worldController) { }

        private const float CameraBump = 0.1f;

        protected internal override void Connect(bool connect)
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
            }
        }

        internal void CameraMoveBack() => CameraMoveFront(-1);
        internal void CameraMoveDown() => CameraMoveUp(-1);
        internal void CameraMoveForward() => CameraMoveFront(+1);
        internal void CameraMoveLeft() => CameraMoveRight(-1);
        internal void CameraMoveRight() => CameraMoveRight(+1);
        internal void CameraMoveUp() => CameraMoveUp(+1);
        internal void CameraRotateDown() => CameraRotateUp(-1);
        internal void CameraRotateLeft() => CameraRotateRight(-1);
        internal void CameraRotateRight() => CameraRotateRight(+1);
        internal void CameraRotateUp() => CameraRotateUp(+1);

        private void CameraMoveBack_Click(object sender, EventArgs e) => CameraMoveBack();
        private void CameraMoveDown_Click(object sender, EventArgs e) => CameraMoveDown();
        private void CameraMoveForward_Click(object sender, EventArgs e) => CameraMoveForward();
        private void CameraMoveLeft_Click(object sender, EventArgs e) => CameraMoveLeft();
        private void CameraMoveRight_Click(object sender, EventArgs e) => CameraMoveRight();
        private void CameraMoveUp_Click(object sender, EventArgs e) => CameraMoveUp();
        private void CameraRotateDown_Click(object sender, EventArgs e) => CameraRotateDown();
        private void CameraRotateLeft_Click(object sender, EventArgs e) => CameraRotateLeft();
        private void CameraRotateRight_Click(object sender, EventArgs e) => CameraRotateRight();
        private void CameraRotateUp_Click(object sender, EventArgs e) => CameraRotateUp();

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

        private void CameraRotate(Vector3 basis, float delta)
        {
            Vector3
                f = Camera.Focus,
                p = Camera.Position - f,
                q = p + delta * CameraBump * basis;
            RunCameraCommand(new Camera(q * p.Length / q.Length + f, f));
        }

        private void RunCameraCommand(Camera camera) => CommandProcessor.Run(new CameraCommand(camera));
    }
}
