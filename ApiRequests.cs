using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SonarrApi
{
    public partial class Main
    {
        public string ApiGetRequest(string apiKey, string apiEndPoint)
        {
            var client = new RestClient(_host);
            var request = new RestRequest(apiEndPoint, Method.GET);
            request.AddHeader("X-Api-Key", apiKey);
            var response = client.Execute(request);
            return response.Content;
        }

        public string ApiPostRequest(string apiKey, string apiEndPoint, object JsonBody)
        {
            var client = new RestClient(_host);
            var request = new RestRequest(apiEndPoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(JsonBody);
            request.AddHeader("X-Api-Key", apiKey);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
