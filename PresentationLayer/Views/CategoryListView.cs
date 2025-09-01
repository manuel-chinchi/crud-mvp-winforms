using EntityLayer.Models;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
using PresentationLayer.Views.Helpers;
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
    // TODO list
    // 1.   la fila seleccionada deberia ser la que se toma cuando uno
    //      ejecuta la accion de editar.
    public partial class CategoryListView : Form, ICategoryListView
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                var bs = (BindingSource)dgvCategories.DataSource;
                var list = (IEnumerable<Category>)bs.DataSource;
                return list;
            }
            set
            {
                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Category>(value.ToList());
                dgvCategories.DataSource = bs;
            }
        }
        public CategoryListPresenter Presenter { get; set; }
        //public string Error { get; set; }
        //public bool ShowError
        //{
        //    get { return lblResult.Visible; }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            lblResult.Text = Error;
        //            lblResult.ForeColor = Color.Red;
        //            this.ShowResult(5);
        //        }
        //    }
        //}
        //public string Success { get; set; }
        //public bool ShowSuccess
        //{
        //    get { return lblResult.Visible; }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            lblResult.Text = Success;
        //            lblResult.ForeColor = Color.Green;
        //            this.ShowResult(3);
        //        }
        //    }
        //}

        private List<int> selectedIndices = new List<int>();
        public List<int> SelectedIndices
        {
            get
            {
                List<int> indices = new List<int>();
                foreach (DataGridViewRow fila in dgvCategories.SelectedRows)
                {
                    indices.Add(fila.Index);
                }
                indices.Sort();
                return indices;

                //selectedIndices.Clear();
                //foreach (DataGridViewRow row in dgvCategories.Rows)
                //{
                //    bool isSelected = (bool)(row.Cells["RowsSelector"].Value ?? false);
                //    if (isSelected)
                //    {
                //        selectedIndices.Add(row.Index);
                //    }
                //}
                //return selectedIndices;
            }
        }

        public event EventHandler DeleteClick;
        public event EventHandler AddClick;
        public event EventHandler ViewLoad;

        private Timer timer;

        public CategoryListView()
        {
            InitializeComponent();
            BindingEvents();
            Presenter = new CategoryListPresenter(this);
        }

        private void BindingEvents()
        {
            btnAdd.Click += delegate { AddClick?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteClick?.Invoke(this, EventArgs.Empty); };
            this.Load += delegate { ViewLoad?.Invoke(this, EventArgs.Empty); };
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        private void ShowResult(int interval = 5)
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

        #region UI settings

        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                bool isSelect = (bool)dgvCategories.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                var row = dgvCategories.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = isSelect ? Color.Yellow : Color.White;
            }
        }

        #endregion

        public Enums.AlertResult Alert(string text, string title, Enums.AlertButtons buttons)
        {
            return ViewHelper.Alert(text, title, buttons);
        }
    }
}
