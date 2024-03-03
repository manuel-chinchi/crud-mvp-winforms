﻿using EntityLayer.Models;
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
    public partial class ListCategoriesView : UserControl, ICategoryListView
    {
        private int _itemSelected;
        public int ItemSelected
        {
            get { return dgvCategories.CurrentCell.RowIndex; }
            set
            {
                if (value >= 0 && value < dgvCategories.RowCount)
                {
                    dgvCategories.CurrentCell = dgvCategories.Rows[value].Cells[0];
                    _itemSelected = value;
                }
            }
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

        public CategoryListPresenter Presenter { get; set; }

        // IBaseView
        public string Error { get; set; }
        public string Success { get; set; }
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
            get { return lblResult.Visible; }
            set
            {
                if (value == true)
                {
                    lblResult.Text = Success;
                    lblResult.ForeColor = Color.Green;
                    this.ShowResult(3);
                }
            }
        }

        public event EventHandler DeleteClick;
        public event EventHandler AddClick;
        public event EventHandler ViewLoad;

        private Timer timer;

        public ListCategoriesView()
        {
            InitializeComponent();
            Presenter = new CategoryListPresenter(this);
        }

        private void ListCategoriesView_Load(object sender, EventArgs e)
        {
            ViewLoad?.Invoke(this, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(this, EventArgs.Empty);
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

        public void ShowView()
        {
            this.Show();
        }

        public void CloseView()
        {
            //throw new NotImplementedException();
            Application.Exit();
        }
    }
}
