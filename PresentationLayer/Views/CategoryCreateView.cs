using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
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
    public partial class CategoryCreateView : Form, ICategoryCreateView
    {

        public string NameC
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public CategoryCreatePresenter Presenter { get; set; }
        public string Error { get; set; }
        public bool ShowError
        {
            get { return this.lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Error;
                    lblResult.ForeColor = Color.Red;
                    this.ShowResult(5);
                }
            }
        }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        private Timer _timer;

        public CategoryCreateView()
        {
            InitializeComponent();
            BindingEvents();
            Presenter = new CategoryCreatePresenter(this);
        }

        private void BindingEvents()
        {
            btnAccept.Click += delegate { AcceptClick?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += delegate { CancelClick?.Invoke(this, EventArgs.Empty); };
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        private void ShowResult(int interval = 5)
        {
            lblResult.Visible = true;

            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
            }

            _timer = new Timer();
            _timer.Interval = interval * 1000;
            _timer.Tick += (s, e) =>
            {
                lblResult.Hide();
                _timer.Stop();
            };
            _timer.Start();
        }
    }
}
