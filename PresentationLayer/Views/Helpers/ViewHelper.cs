using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static PresentationLayer.Enums;

namespace PresentationLayer.Views.Helpers
{
    public static class ViewHelper
    {
        public static AlertResult Alert(string text, string title, Enums.AlertButtons buttons)
        {
            MessageBoxButtons buttonsNative;
            switch (buttons)
            {
                case AlertButtons.OK:
                    buttonsNative = MessageBoxButtons.OK;
                    break;
                case AlertButtons.YesNo:
                    buttonsNative = MessageBoxButtons.YesNo;
                    break;
                case AlertButtons.YesNoCancel:
                    buttonsNative = MessageBoxButtons.YesNoCancel;
                    break;
                default:
                    buttonsNative = MessageBoxButtons.OK;
                    break;
            }

            var resultNative = System.Windows.Forms.MessageBox.Show(text, title, buttonsNative);
            AlertResult result = AlertResult.None;

            switch (resultNative)
            {
                case DialogResult.None:
                    result = AlertResult.None;
                    break;
                case DialogResult.OK:
                    result = AlertResult.OK;
                    break;
                case DialogResult.Cancel:
                    result = AlertResult.Cancel;
                    break;
                //case DialogResult.Abort:
                //    break;
                //case DialogResult.Retry:
                //    break;
                //case DialogResult.Ignore:
                //    break;
                case DialogResult.Yes:
                    result = AlertResult.Yes;
                    break;
                case DialogResult.No:
                    result = AlertResult.No;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
