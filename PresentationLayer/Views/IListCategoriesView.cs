﻿using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface IListCategoriesView : IBaseView
    {
        int ItemSelected { get; }
        IEnumerable<Category> Categories { get; set; }
        ListCategoriesPresenter Presenter { get; set; }

        event EventHandler DeleteClick;
        event EventHandler AddClick;
        event EventHandler ViewLoad;
    }
}
