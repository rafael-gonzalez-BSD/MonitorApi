using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                            mensaje = "No se encontro el archivo de Test";
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

        public static List<string> PathDirectoryExist(string path, out string mensaje)
        {            
            mensaje = "";
            List<string> files = new List<string>();
            try
            {
                if (Directory.Exists(@path))
                {
                    files = Directory.GetFiles(path).ToList();
                    if (files.Count == 0)
                    {
                        mensaje = "No se encontro el archivo de Test";
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
            }

            return files;
        }

        public static bool GetLogFile(string urlFile, int tipoDirectorio,out string mensaje)
        {
            mensaje = "";
            bool canRead = true;
            string completeFile;
            HttpWebResponse res = null;

            switch (tipoDirectorio)
            {
                case 2:
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
                    catch (WebException)
                    {
                        mensaje = "No se pudo leer el archivo de Test";
                        canRead = false;
                    }
                    finally
                    {
                        if (res != null)
                        {
                            res.Close();
                        }
                    }
                    break;
                case 1:
                    try
                    {
                        completeFile = File.ReadAllText(urlFile, Encoding.UTF8);                        
                    }
                    catch
                    {
                        mensaje = "No se pudo leer el archivo de Test";
                        canRead = false;
                    }
                    break;
            }            

            return canRead;
        }
    }
}