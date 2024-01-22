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
        public int ArticleSelected
        {
            get => dgvArticles.CurrentCell.RowIndex;
        }
        public ListArticlesPresenter Presenter { get; set; }

        private IArticleService<IEnumerable<Article>> _articleService = new ArticleService();
        private string id;
        private bool isEditMode = false;

        public ListArticlesView()
        {
            InitializeComponent();

            Presenter = new ListArticlesPresenter(this, _articleService);
        }

        private void ListArticlesView_Load(object sender, EventArgs e)
        {
            //ShowArticles();
            Presenter.LoadArticles();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode == false)
            {
                try
                {
                    _articleService.CreateArticle(txtName.Text, txtDescription.Text, txtStock.Text);
                    MessageBox.Show("Se ha agregado el articulo");
                    ShowArticles();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                try
                {
                    _articleService.UpdateArticle(txtName.Text, txtDescription.Text, txtStock.Text, id);
                    MessageBox.Show("Se edito el articulo");
                    ShowArticles();
                    ClearForm();
                    isEditMode = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvArticles.SelectedRows.Count == 1)
            {
                isEditMode = true;
                txtName.Text = dgvArticles.CurrentRow.Cells["colName"].Value.ToString();
                txtDescription.Text = dgvArticles.CurrentRow.Cells["colDescription"].Value.ToString();
                txtStock.Text = dgvArticles.CurrentRow.Cells["colStock"].Value.ToString();
                id = dgvArticles.CurrentRow.Cells["colId"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una sola fila");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dgvArticles.CurrentRow.Cells["colId"].Value.ToString();
                _articleService.DeleteArticle(id);
                MessageBox.Show("Se ha eliminado el articulo");
                ShowArticles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //ShowArticles();
            Presenter.LoadArticles();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ArticleService articleService = new ArticleService();
                dgvArticles.DataSource = articleService.SearchArticle(((int)chkName.CheckState), ((int)chkDescription.CheckState), txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        #region Methods

        private void ShowArticles()
        {
            //var articleService = new ArticleService();
            //dgvArticles.DataSource = articleService.GetArticles();
            Presenter.LoadArticles();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtStock.Clear();
        }

        #endregion

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new CreateArticleForm();
            frm.ShowDialog();
            MessageBox.Show("Se ha agregado el artículo");
            Presenter.LoadArticles();

            //var stock = string.IsNullOrEmpty(txtStock.Text) == true ? 0 : Convert.ToInt32(txtStock.Text);
            //Presenter.AddArticle(new Article() { Name = txtName.Text, Description = txtDescription.Text, Stock = stock });
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            var frm = new CreateArticleForm(this.Presenter.GetArticleSelected());
            frm.ShowDialog();
            MessageBox.Show("Se ha actualizado el artículo");
            Presenter.LoadArticles();

            //var article = Articles.ToArray()[SelectedRow];
            //Presenter.EditArticle(article.Id);
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            Presenter.DeleteArticle();
            MessageBox.Show("Se ha eliminado el artículo");
            Presenter.LoadArticles();
        }
    }
}
