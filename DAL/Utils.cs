using DAL.Model;
using DAL.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public static class Utils
    {
        public static string PROCCES_NAME = "MenForms.exe";

        public static T? GetJsonObjectFromUrl<T>(string url)
        {
            Console.WriteLine("Utils: " + url);
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest == null)
            {
                return default; // Return the default value for the type
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using var s = webRequest.GetResponse().GetResponseStream();
            using var sr = new StreamReader(s);
            var json = sr.ReadToEnd();
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public static T ReadJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Utils: File not found", filePath);
            }
            Console.WriteLine("Utils: " + filePath);

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json, SettingsJson.jsonSerializerSettings);
        }

        public static AppSettings SetSettingsLanguageByTag(AppSettings settings, string tag)
        {

            if (tag == "hr-HR")
            {
                settings.Language = Model.Enums.Language.CROATIAN;
            } else if (tag == "en-US")
            {
                settings.Language = Model.Enums.Language.ENGLISH;
            } else
            {
                throw new Exception("Utils: Invalid tag");
            }

            return settings;
        }

        public static void KillProccess(string processName)
        {


            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

    }
}
