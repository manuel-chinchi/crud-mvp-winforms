using EntityLayer.Models;
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
    public partial class ArticleCreateView : Form, IArticleCreateView
    {
        public string Id { get; set; }
        public string NameA
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string Stock
        {
            get { return txtStock.Text; }
            set { txtStock.Text = value; }
        }
        public string Category
        {
            get { return cmbCategories.SelectedItem.ToString(); }
            set { cmbCategories.SelectedItem = value; }
        }
        public bool IsEditMode { get; set; }
        public int ItemSelected
        {
            get { return cmbCategories.SelectedIndex; }
            set { cmbCategories.SelectedIndex = value; }
        }
        public IEnumerable<Category> Categories
        {
            get
            {
                var bs = (BindingSource)cmbCategories.DataSource;
                var list = (IEnumerable<Category>)bs.DataSource;
                return list;
            }
            set
            {
                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Category>(value.ToList());
                cmbCategories.DataSource = bs;
            }
        }
        public ArticleCreatePresenter Presenter { get; set; }
        public string Error { get; set; }
        public bool ShowError
        {
            get { return lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Error;
                    lblResult.ForeColor = Color.Red;
                    this.ShowResult();
                }
            }
        }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        private Timer _timer;

        public ArticleCreateView()
        {
            InitializeComponent();
            BindingEvents();
            Presenter = new ArticleCreatePresenter(this);
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }

        private void BindingEvents()
        {
            btnAccept.Click += delegate { AcceptClick?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += delegate { CancelClick?.Invoke(this, EventArgs.Empty); };
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
