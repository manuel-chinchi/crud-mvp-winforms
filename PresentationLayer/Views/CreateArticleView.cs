using BussinesLayer.Services;
using EntityLayer.Models;
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
            get => txtName.Text; set => txtName.Text = value;
        }
        public string Description
        {
            get => txtDescription.Text; set => txtDescription.Text = value;
        }
        public string Stock
        {
            get => txtStock.Text; set => txtStock.Text = value;
        }
        public string Category
        {
            get => cmbCategories.SelectedItem.ToString(); 
            set => cmbCategories.SelectedItem = value;
        }

        public CreateArticlePresenter Presenter { get; set; }

        public bool IsEditMode
        {
            get; set;
        }
        public string MsgError { get; set; }
        public string MsgStatus { get; set; }
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
        public int CategorySelected
        {
            get => cmbCategories.SelectedIndex;
            set
            {
                cmbCategories.SelectedIndex = value;
            }
        }
        public bool StatusResult
        {
            get {
                var result = false;
                if (((Form)this.TopLevelControl).DialogResult == DialogResult.OK)
                {
                    result = true;
                }
                return result;
            }
            set {
                if (value)
                {
                    ((Form)this.TopLevelControl).DialogResult = DialogResult.OK;
                }
            }
        }

        public CreateArticleView()
        {
            InitializeComponent();

            Presenter = new CreateArticlePresenter(this, new ArticleService(), new CategoryService());
        }

        private void CreateArticleView_Load(object sender, EventArgs e)
        {
            if (this.IsEditMode == true)
            {
            }
            else
            {
                Presenter.LoadCategories();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsEditMode == true)
            {
                Presenter.UpdateArticle();
                IsEditMode = false;
            }
            else
            {
                Presenter.SaveArticle();
            }

            if (!string.IsNullOrEmpty(MsgStatus))
            {
                MessageBox.Show(MsgStatus);
            }
            this.Close();
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
