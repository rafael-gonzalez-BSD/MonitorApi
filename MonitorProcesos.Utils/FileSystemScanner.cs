using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

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
                string log = string.Format("La ruta {0} no existe: {1}. {2}", url, ex.Message, ex.InnerException);
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
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();
                    Regex regEx = new Regex(@"href\s*=\s*(?:[""'](?<filename>[^""']*[.zip])[""']|(?<filename>[.zip]\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
                    MatchCollection matches = regEx.Matches(html);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                Debug.WriteLine(match.Groups["filename"].Value);
                            }
                        }
                    }
                }
                exists = res.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException ex)
            {
                string log = string.Format("La ruta {0} no existe: {1}. {2}", url, ex.Message, ex.InnerException);
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

        public static void MapLog()
        {
            string pathLog = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            string[] files = Directory.GetFiles(pathLog);
        }
    }
}