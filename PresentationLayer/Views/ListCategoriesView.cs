using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Forms;
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
    public partial class ListCategoriesView : UserControl, IListCategoriesView
    {
        public ListCategoriesView()
        {
            InitializeComponent();
            //Presenter = new ListCategoriesPresenter(this, new CategoryService());
            Presenter = new ListCategoriesPresenter(this);
        }

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
        public string Error { get; set; }
        public string Success { get; set; }
        public int ItemSelected
        {
            get => dgvCategories.CurrentCell.RowIndex;
        }
        public ListCategoriesPresenter Presenter { get; set; }

        public bool ShowError
        {
            get { return lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Error;
                    lblResult.ForeColor = Color.Red;
                    this.ShowResult(5);
                }
            }
        }
        public bool ShowSuccess
        {
            get {return lblResult.Visible;}
            set
            {
                if (value==true)
                {
                    lblResult.Text = Success;
                    lblResult.ForeColor = Color.Green;
                    this.ShowResult(3);
                }
            }
        }
        private void ShowResult(int interval = 5)
        {
            lblResult.Visible = true;
            var timer = new Timer();
            timer.Interval = interval * 1000;
            timer.Tick += (s, e) =>
            {
                lblResult.Hide();
                timer.Stop();
            };
            timer.Start();
        }

        public event EventHandler DeleteClick;
        public event EventHandler AddClick;

        private void ListCategoriesView_Load(object sender, EventArgs e)
        {
            Presenter.LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick?.Invoke(this, e);

            //var frm = new CreateCategoryForm();
            //var result = frm.ShowDialog();
            //if (result != DialogResult.Cancel)
            //{
            //    Presenter.LoadCategories();
            //}

            //var view = (ICreateCategoryView)frm.GetView();
            //if (!string.IsNullOrEmpty(view.Success))
            //{
            //    this.Success = view.Success;
            //    this.ShowSuccess = true;
            //}
        }

        // ??
        public void AddCategory()
        {
            var frm = new CreateCategoryForm();
            var result = frm.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                Presenter.LoadCategories();
            }

            var view = (ICreateCategoryView)frm.GetView();
            if (!string.IsNullOrEmpty(view.Success))
            {
                this.Success = view.Success;
                this.ShowSuccess = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(this, EventArgs.Empty);

            //var category = this.Categories.ToArray()[this.ItemSelected];
            //var result = MessageBox.Show($"¿Desea eliminar la categoría '{category.Name},id={category.Id}'?", "Alerta", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    Presenter.DeleteCategory();
            //    if (!string.IsNullOrEmpty(MsgStatus))
            //    {
            //        MessageBox.Show(MsgStatus);
            //    }
            //    Presenter.LoadCategories();
            //}
        }
    }
}
