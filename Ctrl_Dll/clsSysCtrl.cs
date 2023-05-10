using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ctrl_Dll
{
    public class clsSysCtrl
    {
        //******************************************************************
        public string GetClipboard_Text()
        {
            return (Clipboard.ContainsText()) ? Clipboard.GetText() : "";
        }


        //******************************************************************
        public bool SetClipboard_Text(string str_)
        {
            try
            {
                Clipboard.SetDataObject(str_, true);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
