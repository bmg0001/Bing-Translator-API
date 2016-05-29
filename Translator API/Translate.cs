using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinHttp;

namespace Translator_API
{
    public class Translate
    {
        public string KR(string English)
        {
            try
            {
                WinHttpRequest wt = new WinHttpRequest();
                wt.Open("POST", "https://www.bing.com/translator");
                wt.SetRequestHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                wt.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.8,en-US;q=0.6,en;q=0.4");
                wt.SetRequestHeader("Content-Type", "text/html; charset=utf-8");
                wt.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
                wt.Send();
                string[] cookie = wt.GetAllResponseHeaders().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                int cookieCount = 0;
                foreach (String header in cookie)
                {
                    if (header.StartsWith("Set-Cookie: "))
                    {
                        cookieCount++;
                    }
                }
                String[] cookies = new String[cookieCount];
                cookieCount = 0;
                string Fcookie = "";
                foreach (String header in cookie)
                {
                    if (header.StartsWith("Set-Cookie: "))
                    {
                        String cookie1 = header.Replace("Set-Cookie: ", "");
                        cookies[cookieCount] = cookie1;
                        Fcookie += cookie1;
                    }
                }
                string mtstkn = "mtstkn=" + Regex.Split(Regex.Split(Fcookie, "mtstkn=")[1], ";")[0] + ";";
                string _EDGE_S = "_EDGE_S=" + Regex.Split(Regex.Split(Fcookie, "_EDGE_S=")[1], ";")[0] + ";";
                string EDGE_V = "_EDGE_V=" + Regex.Split(Regex.Split(Fcookie, "_EDGE_V=")[1], ";")[0] + ";";
                string MUID = "MUID=" + Regex.Split(Regex.Split(Fcookie, "MUID=")[1], ";")[0] + ";";
                string MUIDB = "MUIDB=" + Regex.Split(Regex.Split(Fcookie, "MUIDB=")[1], ";")[0] + ";";
                Fcookie = ""; Fcookie = mtstkn + _EDGE_S + EDGE_V + MUID + MUIDB;

                wt.Open("GET", "https://www.bing.com/secure/Passport.aspx?popup=1&ssl=1");
                wt.SetRequestHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                wt.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.8,en-US;q=0.6,en;q=0.4");
                wt.SetRequestHeader("Content-Type", "text/html; charset=utf-8");
                wt.SetRequestHeader("Cookie", Fcookie);
                wt.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
                wt.Send();
                string[] cookie2 = wt.GetAllResponseHeaders().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                int cookieCount2 = 0;
                foreach (String header in cookie2)
                {
                    if (header.StartsWith("Set-Cookie: "))
                    {
                        cookieCount2++;
                    }
                }
                String[] cookies2 = new String[cookieCount2];
                cookieCount2 = 0;
                string Fcookie2 = "";
                foreach (String header in cookie2)
                {
                    if (header.StartsWith("Set-Cookie: "))
                    {
                        String cookie1 = header.Replace("Set-Cookie: ", "");
                        cookies2[cookieCount] = cookie1;
                        Fcookie2 += cookie1;
                    }
                }
                string SRCHUID = "SRCHUID=" + Regex.Split(Regex.Split(Fcookie, "SRCHUID=")[0], ";")[1] + ";";
                string SRCHUSR = "SRCHUSR=" + Regex.Split(Regex.Split(Fcookie, "SRCHUSR=")[0], ";")[1] + ";";
                string _SSSID = "_SS=SID=" + Regex.Split(Regex.Split(Fcookie, "_SS=SID=")[0], ";")[1] + ";";

                wt.Open("POST", "https://www.bing.com/translator/api/Translate/TranslateArray?from=en&to=ko");
                wt.SetRequestHeader("Accept", "application/json, text/javascript, */*; q=0.01");
                wt.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.8,en-US;q=0.6,en;q=0.4");
                wt.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
                wt.SetRequestHeader("Cookie", Fcookie + "destLang=ko; dmru_list=ko; destDia=ko-KR; SRCHD=AF=NOFORM;" + SRCHUID + SRCHUSR + _SSSID + "WLS=C=&N=; srcLang=-; smru_list=; sourceDia=en-US");
                wt.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36");
                wt.Send("[{\"id\":2137,\"text\":\"" + English + "\"}]");
                return Regex.Split(Regex.Split(wt.ResponseText, "\"text\": \"")[1], "\",")[0];
            }
            catch
            {
                throw new Exception("시스템오류 발생");
            }
        }
    }
}
