using BussinesLayer.Services;
using EntityLayer;
using EntityLayer.Models;
using PresentacionLayer.Forms;
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
    public partial class ArticleView : UserControl
    {
        private IArticleService<SortableBindingList<Article>> _articleService = new ArticleService();
        private string id;
        private bool isEdit = false;

        public ArticleView()
        {
            InitializeComponent();
        }

        private void ArticleView_Load(object sender, EventArgs e)
        {
            ShowArticles();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
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
                    isEdit = false;
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
                isEdit = true;
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
            ShowArticles();
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
            var articleService = new ArticleService();
            dgvArticles.DataSource = articleService.GetArticles();
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
    }
}
