using PresentacionLayer.Presenters;
using PresentacionLayer.Views.Contracts;
using BussinesLayer.Services.Contracts;
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
    public partial class ArticleView : UserControl, IArticleView
    {
        private string _id;
        public string Id
        {
            get => dgvArticles.CurrentRow.Cells["colId"].Value.ToString();
            set => _id = value;
        }

        public string NameA
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public string Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        public string Brand
        {
            get => txtBrand.Text;
            set => txtBrand.Text = value;
        }

        public string Stock
        {
            get => txtStock.Text;
            set => txtStock.Text = value;
        }

        public int IncludeName
        {
            get => (int)chkName.CheckState;
            set => chkName.CheckState = (CheckState)Convert.ToInt32(value);
        }

        public int IncludeDescription
        {
            get => (int)chkDescription.CheckState;
            set => chkDescription.CheckState = (CheckState)Convert.ToInt32(value);
        }

        public int IncludeBrand
        {
            get => (int)chkBrand.CheckState;
            set => chkBrand.CheckState = (CheckState)Convert.ToInt32(value);
        }
        public string Search
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        private bool _isEdit;
        public bool IsEdit
        {
            get => _isEdit;
            set => _isEdit = value;
        }

        public int SelectedRows => dgvArticles.SelectedRows.Count;

        public BindingSource DataSource
        {
            get => (BindingSource)dgvArticles.DataSource;
            set => dgvArticles.DataSource = value;
        }

        public ArticlePresenter presenter { get; set; }

        public ArticleView()
        {
            InitializeComponent();
            presenter = new ArticlePresenter(this, new ArticleService());
            AsociateEvents();
        }

        private void AsociateEvents()
        {
            this.btnShowAll.Click += delegate { LoadArticles?.Invoke(this, EventArgs.Empty); };
            this.btnSave.Click += delegate { SaveArticle?.Invoke(this, EventArgs.Empty); };
            this.btnEdit.Click += delegate { EditArticle?.Invoke(this, EventArgs.Empty); };
            this.btnDelete.Click += delegate { DeleteArticle?.Invoke(this, EventArgs.Empty); };
            this.btnSearch.Click += delegate { SearchArticle?.Invoke(this, EventArgs.Empty); };
            this.txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchArticle?.Invoke(this, EventArgs.Empty);
                }
            };
            this.Load += delegate { LoadArticles?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler LoadArticles;
        public event EventHandler SaveArticle;
        public event EventHandler EditArticle;
        public event EventHandler DeleteArticle;
        public event EventHandler SearchArticle;
    }
}
