using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctrl_Dll
{
    public class clsTranslationCtrl
    {
        public bool SetJAtoEN(string str_en, string source_language = "en", string target_language = "ja")
        {
            try
            {
                string url = "https://script.google.com/macros/s/AKfycbwZKnRrH2tF4o147NLkId4xilXCabm4lS5o-nbo8QvAW31jsHZ9/exec";
                url += $"?text={str_en}";
                url += $"&source={source_language}";
                url += $"&target={target_language}";

                //System.Diagnostics.Process.Start(url);

                var startInfo = new System.Diagnostics.ProcessStartInfo(url);
                startInfo.UseShellExecute = true;
                System.Diagnostics.Process.Start(startInfo);

                return true;
                //return url;
            }
            catch 
            {
                return false;
            }
        }
    }
}
