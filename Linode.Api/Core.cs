﻿using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using RestSharp;
using Linode.Api.Objets.Error;

namespace Linode.Api
{
    public class Core
    {
        public static long PerPage = 25;

        private const string ApiServer = " https://api.linode.com/v4";

        public static async Task<string> SendGetRequest(string token, string url)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                var request = new RestRequest(url);
                request.AddHeader("Authorization", $"Bearer {token}");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                    return content;

                case HttpStatusCode.NotFound:
                    // Get error
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    if (error.Errors[0].Reason == "Not found")
                    {
                        return "{}";
                    }
                    else
                    {
                        throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
                    }
                    break;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPostRequest(string token, string url)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                var request = new RestRequest(url, Method.Post);
                request.AddHeader("Authorization", $"Bearer {token}");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                    return content;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPostRequest(string token, string url, string raw)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                RestRequest request = new RestRequest(url, Method.Post);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(raw, "application/json");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return content;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPutRequest(string token, string url, string raw)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                RestRequest request = new RestRequest(url, Method.Put);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(raw, "application/json");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return content;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task SendDeleteRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{ApiServer}{url}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(request);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.OK:
                    break;

                default:
                    //JObject result = JObject.Parse(json);
                    //Error error = JsonConvert.DeserializeObject<Error>($"{result["error"]}") ?? new Error();
                    //throw new Exception($"{error.Code} - {error.Message}");
                    break;
            }
        }
    }
}
