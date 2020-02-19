using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MonitorProcesos.Utils
{
    public static class FileSystemScanner
    {
        public static List<string> UrlDirectoryExist(string url, out string mensaje)
        {
            mensaje = "";
            HttpWebResponse res = null;
            List<string> files = new List<string>();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                    {
                        string html = reader.ReadToEnd();
                        Regex regEx = new Regex(@"href\s*=\s*(?:[""'](?<filename>[^""']*[.txt])[""']|(?<filename>[.txt]\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
                        MatchCollection matches = regEx.Matches(html);
                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {
                                if (match.Success)
                                {
                                    files.Add(match.Groups["filename"].Value);
                                }
                            }
                        }
                        else
                        {
                            mensaje = "La ruta no encontró archivos";
                        }
                    }
                }
                else
                {
                    mensaje = "La ruta no existe";
                }
            }
            catch
            {
                mensaje = "La ruta no existe";
                Debug.WriteLine(mensaje);
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return files;
        }

        public static bool PathDirectoryExist(string path)
        {
            bool exists = false;
            if (Directory.Exists(@path))
            {
                exists = true;
            }

            return exists;
        }

        public static bool GetLogFile(string urlFile, out string mensaje)
        {
            mensaje = "";
            bool canRead = true;
            string completeFile;
            HttpWebResponse res = null;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(urlFile);
            req.Method = "GET";

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                {
                    completeFile = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                mensaje = string.Format("El archivo no existe o no se pudo leer: {0}. {1}", ex.Message, ex.InnerException);
                canRead = false;
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return canRead;
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
    }
}