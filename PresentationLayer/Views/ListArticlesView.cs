using BussinesLayer.Services;
using EntityLayer;
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
    public partial class ListArticlesView : UserControl, IListArticlesView
    {
        public int ArticleSelected
        {
            get => dgvArticles.CurrentCell.RowIndex;
        }
        public bool IncludeName
        {
            get => Convert.ToBoolean(chkName.CheckState);
            set { chkName.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public bool IncludeDescription
        {
            get => Convert.ToBoolean(chkDescription.CheckState);
            set { chkDescription.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public string Search
        {
            get => txtSearch.Text;
            set { txtSearch.Text = value; }
        }
        public string MsgError { get; set; }
        public string MsgStatus { get; set; }
        public IEnumerable<Article> Articles
        {
            get
            {
                var bs = (BindingSource)dgvArticles.DataSource;
                var list = (IEnumerable<Article>)bs.DataSource;
                return list;
            }
            set
            {
                // no permite ordenacion
                //BindingSource bs = new BindingSource();
                //bs.DataSource = new List<Article>();
                //dgvArticles.DataSource = bs.DataSource;

                //BindingSource bs = new BindingSource((IContainer)value.ToList());

                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Article>(value.ToList());
                dgvArticles.DataSource = bs;
            }
        }
        public ListArticlesPresenter Presenter { get; set; }

        public ListArticlesView()
        {
            InitializeComponent();

            Presenter = new ListArticlesPresenter(this, new ArticleService());
        }

        private void ListArticlesView_Load(object sender, EventArgs e)
        {
            Presenter.LoadArticles();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Presenter.LoadArticles();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SearchArticle();
                var error = Presenter.GetError();
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // ting!!! >:c
                e.Handled = true;
                e.SuppressKeyPress = true;

                Presenter.SearchArticle();
                var error = Presenter.GetError();
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new CreateArticleForm();
            frm.ShowDialog();
            Presenter.LoadArticles();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frm = new CreateArticleForm(this.Presenter.GetArticleSelected());
            frm.ShowDialog();
            Presenter.LoadArticles();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Desea eliminar el artículo?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteArticle();
                var status = Presenter.GetStatus();
                if (!string.IsNullOrEmpty(status))
                {
                    MessageBox.Show(status);
                }
                Presenter.LoadArticles();
            }
        }
    }
}
