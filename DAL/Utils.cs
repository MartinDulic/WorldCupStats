using DAL.Model;
using DAL.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Utils
    {
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

    }
}
