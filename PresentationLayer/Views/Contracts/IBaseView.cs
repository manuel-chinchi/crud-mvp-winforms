using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Views.Helpers.Enums;

namespace PresentationLayer.Views.Contracts
{
    public interface IBaseView
    {
        AlertResult Alert(string text, string title, AlertButtons buttons);
    }
}
