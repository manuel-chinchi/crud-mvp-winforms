using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Contracts
{
    public interface IBaseView
    {
        string Error { get; set; }
        bool ShowError { get; set; }
        string Success { get; set; }
        bool ShowSuccess { get; set; }
    }
}
