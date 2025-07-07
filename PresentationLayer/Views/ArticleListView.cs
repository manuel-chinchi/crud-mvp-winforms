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
    public partial class ArticleListView : Form, IArticleListView
    {
        public bool FilterIncludeName
        {
            get { return Convert.ToBoolean(chkName.CheckState); }
            set { chkName.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public bool FilterIncludeDescription
        {
            get { return Convert.ToBoolean(chkDescription.CheckState); }
            set { chkDescription.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public string Search
        {
            get { return ucTxtExSearch.Text; }
            set { ucTxtExSearch.Text = value; }
        }
        public IEnumerable<Article> Articles
        {
            get
            {
                var bs = (BindingSource)dgvArticles.DataSource;
                var list = (IEnumerable<Article>)bs.DataSource;
                return list;
            }
            set
            {
                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Article>(value.ToList());
                dgvArticles.DataSource = bs;
                dgvArticles.Columns["CategoryId"].Visible = false;
            }
        }
        public ArticleListPresenter Presenter { get; set; }
        public string Warning { get; set; }
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
        public string Error { get; set; }
        public bool ShowError { get; set; }
        public string Success { get; set; }
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

        private List<int> selectedIndices = new List<int>();
        public List<int> SelectedIndices
        {
            get
            {
                selectedIndices.Clear();
                foreach (DataGridViewRow row in dgvArticles.Rows)
                {
                    bool isSelected = (bool)(row.Cells["RowsSelector"].Value ?? false);
                    if (isSelected)
                    {
                        selectedIndices.Add(row.Index);
                    }
                }
                return selectedIndices;
            }
        }

        public event EventHandler AddClick;
        public event EventHandler EditClick;
        public event EventHandler DeleteClick;
        public event EventHandler SearchClick;
        public event EventHandler ShowAllClick;
        public event EventHandler ViewLoad;

        private Timer timer;

        public ArticleListView()
        {
            InitializeComponent();
            BindingEvents();
            Presenter = new ArticleListPresenter(this);
        }

        private void BindingEvents()
        {
            btnAdd.Click += delegate { AddClick?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditClick?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteClick?.Invoke(this, EventArgs.Empty); };
            btnShowAll.Click += delegate { ShowAllClick?.Invoke(this, EventArgs.Empty); };
            btnSearch.Click += delegate { SearchClick?.Invoke(this, EventArgs.Empty); };
            this.Load += delegate { ViewLoad?.Invoke(this, EventArgs.Empty); };
            ucTxtExSearch.TextBoxEx_KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    SearchClick?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowView()
        {
            this.ShowDialog();
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

        #region UI Settings

        private void pnlSearchContainer_MouseClick(object sender, MouseEventArgs e)
        {
            ucTxtExSearch.Focus();
        }

        private void dgvArticles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //var colIndex = dgvArticles.Columns["RowsSelector"].Index;
                //bool isSelect = (bool)dgvArticles.Rows[e.RowIndex].Cells[colIndex].Value;
                bool isSelect = (bool)dgvArticles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                var row = dgvArticles.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = isSelect ? Color.Yellow : Color.White;
            }
        }

        #endregion
    }
}
