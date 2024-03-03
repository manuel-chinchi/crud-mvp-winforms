using BussinesLayer.Services;
using EntityLayer.Models;
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
    public partial class ListArticlesView : UserControl, IArticleListView
    {
        private int _itemSelected;
        public int ItemSelected
        {
            get { return dgvArticles.CurrentCell.RowIndex; }
            set
            {
                if (value >= 0 && value <= dgvArticles.RowCount)
                {
                    dgvArticles.CurrentCell = dgvArticles.Rows[value].Cells[0];
                    _itemSelected = value;
                }
            }
        }

        public bool IncludeName
        {
            get { return Convert.ToBoolean(chkName.CheckState); }
            set { chkName.CheckState = (CheckState)Convert.ToInt32(value); }
        }

        public bool IncludeDescription
        {
            get { return Convert.ToBoolean(chkDescription.CheckState); }
            set { chkDescription.CheckState = (CheckState)Convert.ToInt32(value); }
        }

        public string Search
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public IEnumerable<Article> Articles
        {
            // TODO Aca ocurre el error, hay que cargar los articulos en el constructor
            // del presentador o en el evento on 'Load' de la vista
            get
            {
                var bs = (BindingSource)dgvArticles.DataSource;
                var list = (IEnumerable<Article>)bs.DataSource;
                return list;
            }
            set
            {
                // TODO: Esta forma no permite ordenacion
                //BindingSource bs = new BindingSource();
                //bs.DataSource = new List<Article>();
                //dgvArticles.DataSource = bs.DataSource;
                //BindingSource bs = new BindingSource((IContainer)value.ToList());

                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Article>(value.ToList());
                dgvArticles.DataSource = bs;

                dgvArticles.Columns["CategoryId"].Visible = false;
            }
        }

        public ArticleListPresenter Presenter { get; set; }

        // IBaseView
        public string Error { get; set; }
        public string Success { get; set; }
        public string Warning { get; set; }
        public bool ShowError { get; set; }
        public bool ShowSuccess
        {
            get { return lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Success;
                    lblResult.ForeColor = Color.Green;
                    this.ShowResult();
                }
                else
                {
                    if (timer != null && timer.Enabled)
                        timer.Stop();
                    lblResult.Visible = value;
                }
            }
        }
        public bool ShowWarning
        {
            get { return lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Warning;
                    lblResult.ForeColor = Color.Goldenrod;
                    this.ShowResult();
                }
            }
        }

        public event EventHandler AddClick;
        public event EventHandler EditClick;
        public event EventHandler DeleteClick;
        public event EventHandler SearchClick;
        public event EventHandler ShowAllClick;
        public event EventHandler ViewLoad;

        private Timer timer;

        public ListArticlesView()
        {
            InitializeComponent();
            Presenter = new ArticleListPresenter(this, new ArticleService());
        }

        private void ListArticlesView_Load(object sender, EventArgs e)
        {
            ViewLoad?.Invoke(this, EventArgs.Empty);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ShowAllClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClick?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // ting!!! >:c
                e.Handled = true;
                e.SuppressKeyPress = true;

                SearchClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(this, EventArgs.Empty);
        }

        private void ShowResult(int interval = 3)
        {
            lblResult.Visible = true;

            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }

            timer = new Timer();
            timer.Interval = interval * 1000;
            timer.Tick += (s, e) =>
            {
                lblResult.Hide();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
