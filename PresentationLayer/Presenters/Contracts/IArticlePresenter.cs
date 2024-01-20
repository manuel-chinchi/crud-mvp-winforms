using BussinesLayer.Services;
using EntityLayer;
using EntityLayer.Models;
using PresentacionLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionLayer.Presenters.Contracts
{
    public interface IArticlePresenter
    {
        IArticleView view { get; set; }
        IArticleService<SortableBindingList<Article>> service { get; set; }
    }
}
