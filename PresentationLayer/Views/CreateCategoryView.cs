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
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public CreateCategoryPresenter Presenter { get; set; }

        // IBaseView
        public string Error { get; set; }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }
        public bool ShowError
        {
            get { return this.lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Error;
                    lblResult.ForeColor = Color.Red;
                    ShowResult(5);
                }
            }
        }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        private Timer timer;

        public CreateCategoryView()
        {
            InitializeComponent();

            //Presenter = new CreateCategoryPresenter(this, new CategoryService());
            Presenter = new CreateCategoryPresenter(this);
        }

        public void CloseView()
        {
            //((Form)this.TopLevelControl).Close();
            ((CreateCategoryForm)this.TopLevelControl).Close();

            // Si se usa Form como vista usar así:
            //this.Close();
        }

        public void ShowView()
        {
            CreateCategoryForm frm = (CreateCategoryForm)this.ParentForm;
            frm.ShowDialog();

            // Si se usa Form como vista usar así:
            //this.ShowDialog();
        }

        private void ShowResult(int interval = 5)
        {
            lblResult.Visible = true;

            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }

            timer = new Timer();
            timer.Interval = interval * 1000;
            timer.Tick += (s, e) =>
            {
                lblResult.Hide();
                timer.Stop();
            };
            timer.Start();
        }

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
    }
}
