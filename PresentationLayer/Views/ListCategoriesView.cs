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
            Presenter = new ListCategoriesPresenter(this, new CategoryService());
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
        public string MsgError { get; set; }
        public string MsgStatus { get; set; }
        public int CategorySelected
        {
            get => dgvCategories.CurrentCell.RowIndex;
        }
        public ListCategoriesPresenter Presenter { get; set; }

        private void ListCategoriesView_Load(object sender, EventArgs e)
        {
            Presenter.LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new CreateCategoryForm();
            frm.ShowDialog();
            Presenter.LoadCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var category = this.Categories.ToArray()[this.CategorySelected];
            var result = MessageBox.Show($"¿Desea eliminar la categoría '{category.Name},id={category.Id}'?", "Alerta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteCategory();
                if (!string.IsNullOrEmpty(MsgStatus))
                {
                    MessageBox.Show(MsgStatus);
                }
                Presenter.LoadCategories();
            }
        }
    }
}
