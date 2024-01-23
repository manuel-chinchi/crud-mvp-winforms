using BussinesLayer.Services;
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

        public CreateArticlePresenter Presenter { get; set; }

        public bool IsEditMode
        {
            get; set;
        }
        public string MsgError { get; set; }
        public string MsgStatus { get; set; }

        public CreateArticleView()
        {
            InitializeComponent();

            Presenter = new CreateArticlePresenter(this, new ArticleService());
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
