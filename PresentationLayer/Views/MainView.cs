using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
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
    public partial class MainView : Form, IMainView
    {
        public string Error { get; set; }
        public bool ShowError { get;set; }
        public string Success { get;set; }
        public bool ShowSuccess { get;set; }
        public MainPresenter Presenter { get; set; }

        public event EventHandler ArticlesClick;
        public event EventHandler CategoriesClick;
        public event EventHandler ReportsClick;

        public MainView()
        {
            InitializeComponent();

            btnArticles.Click += delegate { ArticlesClick?.Invoke(this, EventArgs.Empty); };
            btnCategories.Click += delegate { CategoriesClick?.Invoke(this, EventArgs.Empty); };
            btnReports.Click += delegate { ReportsClick?.Invoke(this, EventArgs.Empty); };
            llbAbout.Click += delegate { System.Diagnostics.Process.Start("https://github.com/manuel-chinchi/crud-mvp-winforms?tab=readme-ov-file#crud-mvp-winforms"); };

            Presenter = new MainPresenter(this);
        }
    }
}
