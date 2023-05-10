using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;//コンソールにlogを記入用( Debug.WriteLine)

using System.IO;
using System.Net;

namespace Ctrl_Dll
{
    public class clsBrowserCtrl
    {
        //***************************************************************************************************
        /// <summary>
        /// Webブラウザでurl_ページを開く
        /// </summary>
        /// <param name="url_"></param>
        /// <returns></returns>
        //***************************************************************************************************
        public bool OpenWeb(string url_)
        {
            try
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo(url_);
                startInfo.UseShellExecute = true;
                System.Diagnostics.Process.Start(startInfo);
                Debug.WriteLine("OpenWeb success");
                return true;
            }
            catch
            {
                Debug.WriteLine("OpenWeb Err");
                return false;
            }
        }

        //***************************************************************************************************
        public string GetHtml(string url_)
        {
            // 指定されたURLに対してのRequestを作成します。
            var req = (HttpWebRequest)WebRequest.Create(url_);

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
