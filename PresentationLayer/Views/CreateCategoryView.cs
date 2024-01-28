using BussinesLayer.Services;
using PresentationLayer.Forms;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateCategoryView : UserControl, ICreateCategoryView
    {
        public string NameC
        {
            get => txtName.Text; set { txtName.Text = value; }
        }
        public string MsgError { get; set; }
        public string MsgStatus { get; set; }
        public CreateCategoryPresenter Presenter { get; set; }
        public bool StatusResult
        {
            get
            {
                var result = false;
                if (((Form)this.TopLevelControl).DialogResult == DialogResult.OK)
                {
                    result = true;
                }
                return result;
            }
            set
            {
                if (value)
                {
                    ((Form)this.TopLevelControl).DialogResult = DialogResult.OK;
                }
            }
        }

        public CreateCategoryView()
        {
            InitializeComponent();

            Presenter = new CreateCategoryPresenter(this, new CategoryService());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Presenter.SaveCategory();
            if (string.IsNullOrEmpty(this.MsgStatus))
            {
                MessageBox.Show(this.MsgStatus);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        public void Close()
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
