using BussinesLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private ArticleService _articleService = new ArticleService();
        private string id;
        private bool isEdit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowArticles();
        }

        private void ShowArticles()
        {
            ArticleService articleService = new ArticleService();
            dataGridView1.DataSource = articleService.GetArticles();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtBrand.Clear();
            txtStock.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit == false)
            {
                try
                {
                    _articleService.InsertArticle(txtName.Text, txtDescription.Text, txtBrand.Text, txtStock.Text);
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
                    _articleService.UpdateArticle(txtName.Text, txtDescription.Text, txtBrand.Text, txtStock.Text, id);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                _articleService.DeleteArticle(id);
                MessageBox.Show("Se ha eliminado el articulo");
                ShowArticles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                isEdit = true;
                txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                txtDescription.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
                txtBrand.Text = dataGridView1.CurrentRow.Cells["Brand"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una sola fila");
            }
        }
    }
}
