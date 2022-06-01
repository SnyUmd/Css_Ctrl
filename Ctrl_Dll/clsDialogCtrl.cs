using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace Ctrl_Dll
{
    public class clsDialogCtrl
    {
        public bool ShowMsg_YN(string msg, string title_ = "確認")
        {
            DialogResult result = MessageBox.Show(msg, title_, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //bool bl_result = (result == DialogResult.Yes) ? true : false;
            return (result == DialogResult.Yes) ? true : false;
        }
    }
}
