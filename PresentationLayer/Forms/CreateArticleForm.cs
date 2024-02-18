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

namespace PresentationLayer.Forms
{
    public partial class CreateArticleForm : Form
    {
        public CreateArticleForm(Article article = null)
        {
            InitializeComponent();
            if (article != null)
            {
                this.createArticleView1.Presenter.LoadArticleFromEdit(article);
                this.createArticleView1.Presenter.ActivateEditMode();
            }
        }

        public object GetView() { return this.createArticleView1; }
    }
}
