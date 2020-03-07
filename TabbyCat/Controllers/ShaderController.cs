namespace TabbyCat.Controllers
{
    using TabbyCat.Controls;

    internal class ShaderController
    {
        #region Constructors

        internal ShaderController(PropertyController propertyController)
        {
            PropertyController = propertyController;
        }

        private void BtnExportHTML_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Fields & Properties

        internal ShaderEdit Editor => PropertyEditor.ShaderEdit;

        private readonly PropertyController PropertyController;
        private TabbedEdit PropertyEditor => PropertyController.Editor;

        #endregion

        #region Private Methods

        internal void Connect(bool connect)
        {
            if (connect)
            {
                Editor.btnDocumentMap.Click += DocumentMap_Click;
                Editor.btnExportHTML.Click += BtnExportHTML_Click;
                Editor.btnExportRTF.Click += ExportRTF_Click;
                Editor.btnHelp.Click += Help_Click;
                Editor.btnLineNumbers.Click += LineNumbers_Click;
                Editor.btnPrint.Click += Print_Click;
                Editor.btnRuler.Click += Ruler_Click;
                Editor.btnSplit.Click += Split_Click;
            }
            else
            {
                Editor.btnDocumentMap.Click -= DocumentMap_Click;
                Editor.btnExportHTML.Click -= BtnExportHTML_Click;
                Editor.btnExportRTF.Click -= ExportRTF_Click;
                Editor.btnHelp.Click -= Help_Click;
                Editor.btnLineNumbers.Click -= LineNumbers_Click;
                Editor.btnPrint.Click -= Print_Click;
                Editor.btnRuler.Click -= Ruler_Click;
                Editor.btnSplit.Click -= Split_Click;
            }
        }

        private void Split_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Ruler_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Print_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void LineNumbers_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Help_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ExportRTF_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DocumentMap_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
