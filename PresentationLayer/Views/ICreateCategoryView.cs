﻿using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface ICreateCategoryView
    {
        string NameC { get; set; }
        string MsgError { get; set; }
        string MsgStatus { get; set; }

        CreateCategoryPresenter Presenter { get; set; }
        void Close();
    }
}