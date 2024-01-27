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
    public partial class ListArticlesForm : Form
    {
        public ListArticlesForm()
        {
            InitializeComponent();
        }

        private void ListArticlesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
