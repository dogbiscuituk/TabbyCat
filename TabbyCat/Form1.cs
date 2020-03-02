namespace TabbyCat
{
    using System;
    using System.Windows.Forms;
    using TabbyCat.Controllers;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new SceneController().Show(this);
        }
    }
}
