using BussinesLayer.Services;
using EntityLayer.Models;
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
        private string _id;
        public string Id
        {
            get => _id; set => _id = value;
        }

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

        public CreateArticleView()
        {
            InitializeComponent();

            Presenter = new CreateArticlePresenter(this, new ArticleService());

            //if (this.article != null)
            //{
            //    txtName.Text = article.Name;
            //    txtDescription.Text = article.Description;
            //    txtStock.Text = article.Stock.ToString();
            //}
            //Presenter.LoadArticleFromEdit(article);
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
                //article = new Article()
                //{
                //    Name = txtName.Name,
                //    Description = txtDescription.Text,
                //    Stock = string.IsNullOrEmpty(txtStock.Text) ? 0 : Convert.ToInt32(txtStock.Text)
                //};
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
