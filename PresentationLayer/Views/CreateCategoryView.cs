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
        string ICreateCategoryView.NameC
        {
            get => txtName.Text; set { txtName.Text = value; }
        }
        public string Error { get; set; }
        public string Success { get; set; }
        public CreateCategoryPresenter Presenter { get; set; }
        public bool ShowSuccess
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

        public bool ShowError 
        {
            get { return this.lblError.Visible; }
            set 
            {
                lblError.Visible = value;
                lblError.Text = Error;
            }
        }

        public CreateCategoryView()
        {
            InitializeComponent();

            //Presenter = new CreateCategoryPresenter(this, new CategoryService());
            Presenter = new CreateCategoryPresenter(this);
        }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptClick?.Invoke(this, EventArgs.Empty);

            //btnAccept.Click += delegate { AcceptClick.Invoke(this, EventArgs.Empty); };

            //Presenter.SaveCategory();
            //if (string.IsNullOrEmpty(this.MsgStatus))
            //{
            //    MessageBox.Show(this.MsgStatus);
            //}
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(this, EventArgs.Empty);
            //((Form)this.TopLevelControl).Close();
        }

        public void Close()
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
