using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace XenforoAPI
{
    public class Hub
    {
        protected string _apiKey;
        protected string _baseURL;

        public Hub(string url, string apiKey) 
        {
            _apiKey = apiKey;
            _baseURL = url;
        }

        public partial class Users : XenforoAPI.Users
        {
            public Users(string url, string apiKey) : base(url, apiKey) { }
        }

        protected static async Task<string> GetRequestAsync(string url, string token, string user = "")
        {
            var header = new WebHeaderCollection
            {
                { "XF-Api-Key", token },
                { "XF-Api-User", user }
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Headers = header;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        protected static async Task<string> PostRequestAsync(string url, string data, string token, string user = "", string contentType = "application/x-www-form-urlencoded", string method = "POST")
        {
            var headers = new WebHeaderCollection
            {
                { "XF-Api-Key", token },
                { "XF-Api-User", user }
            };

            var request = (HttpWebRequest)WebRequest.Create(url + "/?" + data);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = data.Length;
            request.ContentType = contentType;
            request.Method = method;
            request.Accept = "application/json";
            request.Headers = headers;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                await streamWriter.WriteAsync(data);
            }
            var response = (HttpWebResponse)await request.GetResponseAsync();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}