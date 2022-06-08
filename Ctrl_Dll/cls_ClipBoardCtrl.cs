using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ctrl_Dll
{
    public class cls_ClipBoardCtrl
    {
        public string[] GetClipBoardInf()
        {
            string[] aryResult = new string[0];

            IDataObject data = Clipboard.GetDataObject();
            if (data != null)
                aryResult = data.GetFormats();

            return aryResult;
        }
    }
}
