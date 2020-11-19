using RestSharp;
using System;
using System.Text;
using RestSharp.Serializers.NewtonsoftJson;

namespace KohaREST
{
    public class KohaRESTConnection : IDisposable
    {
        private string ConnectionURL { get; set; }
        public string BaseURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private string[] SupportedResources = new string[] { "holds", "patrons" };

        public KohaRESTConnection(string BaseURL, string Username, string Password)
        {
            this.BaseURL = BaseURL;
            this.Username = Username;
            this.Password = Password;
            this.ConnectionURL = "https://" + BaseURL + "/api/v1/";
        }

        public string Delete(Resources Delete, string Value)
        {
            string URL = ConnectionURL + SupportedResources[(int)Delete] + "/" + Value;
            var client = new RestClient(URL);
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Username + ":" + this.Password));

            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public string Get(Resources Get, string Value)
        {
            string URL = ConnectionURL + SupportedResources[(int)Get] + "/" + Value;
            var client = new RestClient(URL);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Username + ":" + this.Password));

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        public string Get(Resources Get, string Key, string Value)
        {
            string URL = ConnectionURL + SupportedResources[(int)Get] + "?" + Key + "=" + Value;
            var client = new RestClient(URL);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Username + ":" + this.Password));

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return response.Content;

        }

        public string Get(Resources Get, string[] Keys, string[] Values)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string Key in Keys)
            {
                builder.Append(Key + "=" + Values[i] + "&");
                i++;
            }

            string URL = ConnectionURL + SupportedResources[(int)Get] + "?" + builder.ToString().Substring(0, builder.ToString().Length - 1);
            var client = new RestClient(URL);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Username + ":" + this.Password));

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return response.Content;

        }

        public string Post<T>(Resources Post, T Object)
        {
            string URL = ConnectionURL + SupportedResources[(int)Post];
            var client = new RestClient(URL);
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Username + ":" + this.Password));
            var request = new RestRequest(Method.POST);
            request.UseNewtonsoftJson();
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(Object);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }



        public void Dispose()
        {

        }
    }

    public enum Resources
    {
        Holds, Patrons
    }

}

