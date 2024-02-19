using BussinesLayer.Services;
using EntityLayer.Models;
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
    public partial class CreateArticleView : UserControl, ICreateArticleView
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
                //bs.DataSource = value.ToList();
                cmbCategories.DataSource = bs;
            }
        }

        public CreateArticlePresenter Presenter { get; set; }

        // IBaseView
        public string Error { get; set; }
        public string Success { get; set; }
        public bool ShowError { get; set; }
        public bool ShowSuccess { get; set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        public CreateArticleView()
        {
            InitializeComponent();
            Presenter = new CreateArticlePresenter(this, new ArticleService(), new CategoryService());
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
