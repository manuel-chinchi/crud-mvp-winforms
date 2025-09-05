using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public static class Enums
    {
        public enum AlertResult
        {
            None = 0, // close alert window
            OK,
            Yes,
            No,
            Cancel
        }

        public enum AlertButtons
        {
            OK,
            YesNo,
            YesNoCancel
        }
    }
}
