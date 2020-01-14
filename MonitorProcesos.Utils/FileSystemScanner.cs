using System.Diagnostics;
using System.Linq;
using System.Net;

namespace MonitorProcesos.Utils
{
    public static class FileSystemScanner
    {
        public static bool UrlDirectoryExist(string url)
        {
            HttpWebResponse res = null;
            bool exists = false;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Timeout = 1200;
            req.Method = "HEAD";

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                exists = res.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                string log = string.Format("{0} doesn't exist: {1}. {2}", url, ex.Message, ex.InnerException);
                Debug.WriteLine(log);
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return exists;
        }

        public static bool UrlDirectoryDownload(string url)
        {
            HttpWebResponse res = null;
            bool exists = false;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(res.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();
                    System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("href=\\\"([^\\\"]*)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    System.Text.RegularExpressions.MatchCollection matches = regEx.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (System.Text.RegularExpressions.Match match in matches.Where(x => x.Success))
                        {
                            foreach (var item in match.Groups.Where(y => y.Value.ToString().Contains("zip") && !y.Value.ToString().Contains("href")))
                            {
                                Debug.WriteLine(item.Value);
                            }
                        }
                    }
                }
                exists = res.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                string log = string.Format("{0} doesn't exist: {1}. {2}", url, ex.Message, ex.InnerException);
                Debug.WriteLine(log);
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return exists;
        }
    }
}