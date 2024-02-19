﻿using BussinesLayer.Services;
using EntityLayer;
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
    public partial class ListArticlesView : UserControl, IListArticlesView
    {
        public int ItemSelected
        {
            get => dgvArticles.CurrentCell.RowIndex;
        }
        public bool IncludeName
        {
            get => Convert.ToBoolean(chkName.CheckState);
            set { chkName.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public bool IncludeDescription
        {
            get => Convert.ToBoolean(chkDescription.CheckState);
            set { chkDescription.CheckState = (CheckState)Convert.ToInt32(value); }
        }
        public string Search
        {
            get => txtSearch.Text;
            set { txtSearch.Text = value; }
        }
        public string Error { get; set; }
        public string Success { get; set; }
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
                // TODO: Esta forma no permite ordenacion
                //BindingSource bs = new BindingSource();
                //bs.DataSource = new List<Article>();
                //dgvArticles.DataSource = bs.DataSource;

                //BindingSource bs = new BindingSource((IContainer)value.ToList());

                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<Article>(value.ToList());
                dgvArticles.DataSource = bs;
            }
        }
        public ListArticlesPresenter Presenter { get; set; }
        public bool ShowError { get; set; }
        public bool ShowSuccess { get; set; }

        public ListArticlesView()
        {
            InitializeComponent();

            Presenter = new ListArticlesPresenter(this, new ArticleService());
        }

        public event EventHandler AddClick;
        public event EventHandler EditClick;
        public event EventHandler DeleteClick;
        public event EventHandler SearchAllClick;

        private void ListArticlesView_Load(object sender, EventArgs e)
        {
            Presenter.LoadArticles();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Presenter.LoadArticles();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAllClick?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // ting!!! >:c
                e.Handled = true;
                e.SuppressKeyPress = true;

                SearchAllClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // passing a model automatically activates the editor mode
            EditClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
