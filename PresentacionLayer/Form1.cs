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
        private ArticleService articleService = new ArticleService();

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
            try
            {
                articleService.InsertArticle(txtName.Text, txtDescription.Text, txtBrand.Text, txtStock.Text);
                ShowArticles();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
