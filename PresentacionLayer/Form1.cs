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
            ArticleService objeto = new ArticleService();
            dataGridView1.DataSource = objeto.GetArticles();
        }
    }
}
