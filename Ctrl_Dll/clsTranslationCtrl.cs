using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Collections.Generic;
using System.IO;
//using System.Text;
using System.Net;
//using System.Text.RegularExpressions;

namespace Ctrl_Dll
{
    public class clsTranslationCtrl
    {
        //***************************************************************************************************
        public bool SetTranslation(string str_en, string source_language = "en", string target_language = "ja")
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

        //***************************************************************************************************
        /// <summary>
        /// 引数urlにアクセスした際に取得できるHTMLを返します。
        /// </summary>
        /// <param name="url">URL(アドレス)</param>
        /// <returns>取得したHTML</returns>
        //***************************************************************************************************
        public string GetHtml(string str_en, string source_language = "en", string target_language = "ja")
        {
            string url = "https://script.google.com/macros/s/AKfycbwZKnRrH2tF4o147NLkId4xilXCabm4lS5o-nbo8QvAW31jsHZ9/exec";
            url += $"?text={str_en}";
            url += $"&source={source_language}";
            url += $"&target={target_language}";

            // 指定されたURLに対してのRequestを作成します。
            var req = (HttpWebRequest)WebRequest.Create(url);

            // html取得文字列
            string html = "";

            // 指定したURLに対してReqestを投げてResponseを取得します。
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())
            // 取得した文字列をUTF8でエンコードします。
            using (var sr = new StreamReader(resSt, Encoding.UTF8))
            {
                // HTMLを取得する。
                html = sr.ReadToEnd();
            }

            return html;
        }
    }


}
