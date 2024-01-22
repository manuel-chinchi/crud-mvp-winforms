using EntityLayer.Models;
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
    public partial class CreateArticleView : UserControl
    {
        Article article { get; set; } = new Article();

        public CreateArticleView()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            article.Name = txtName.Text;
            article.Description = txtDescription.Text;
            article.Stock = string.IsNullOrEmpty(txtStock.Text) ? 0 : Convert.ToInt32(txtStock.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
