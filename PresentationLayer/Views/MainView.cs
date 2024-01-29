using PresentationLayer.Forms;
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
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void btnArticles_Click(object sender, EventArgs e)
        {
            var frm = new ListArticlesForm();
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var frm = new ListCategoriesForm();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // TODO: implement report form here
        }
    }
}
