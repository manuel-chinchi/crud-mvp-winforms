using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Forms;
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
    public partial class CreateArticleView : UserControl, IArticleCreateView
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

        // IBaseView
        public string Error { get; set; }
        public string Success { get; set; }
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

        public bool ShowSuccess { get; set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        private Timer timer;

        public CreateArticleView()
        {
            InitializeComponent();
            Presenter = new ArticleCreatePresenter(this, new ArticleService(), new CategoryService());
        }

        public void ShowView()
        {
            CreateArticleForm frm = (CreateArticleForm)this.ParentForm;
            frm.ShowDialog();
        }

        public void CloseView()
        {
            ((CreateArticleForm)this.TopLevelControl).Close();
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

        private void CreateArticleView_Load(object sender, EventArgs e)
        {
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(this, EventArgs.Empty);
            //((Form)this.TopLevelControl).Close();
        }
    }
}
