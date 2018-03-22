using System;
using System.Threading.Tasks;
using RestSharp;

namespace Agate.Business.API
{
    public class Client
    {
       public static string BaseAddress = "https://oppapi.azurewebsites.net/api/v1/";

        public static async Task<TResponse> Post<TRequest,TResponse>(string api, TRequest request)
            where TResponse : class
        {
            var client = new RestClient(BaseAddress);
            var restRequest = new RestRequest(api, Method.POST);
            restRequest.AddJsonBody(request);
            var result = await client.ExecuteTaskAsync<TResponse>(restRequest);
            if (result.IsSuccessful)
                return result.Data;
            else
            {
                if (result.ErrorMessage != null)
                    throw new Exception(result.ErrorMessage);
                if (result.ErrorException != null)
                    throw result.ErrorException;
                throw new Exception(result.Content);
            }
        }

        public static async Task<TResponse> Get<TResponse>(string api)
            where TResponse : class
        {
            try
            {
                //System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                ////client.BaseAddress = new System.Uri(Services.BaseAddress);
                //var response = await client.GetAsync(BaseAddress + api, HttpCompletionOption.ResponseContentRead);
                //var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                //return result;

                var client = new RestClient(BaseAddress);
                var restRequest = new RestRequest(api, Method.GET);
                restRequest.RequestFormat = DataFormat.Json;
                var result = await client.ExecuteTaskAsync<TResponse>(restRequest);
                if (result.IsSuccessful)
                    return result.Data;
                else
                {
                    if (result.ErrorMessage != null)
                        throw new Exception(result.ErrorMessage);
                    if (result.ErrorException != null)
                        throw result.ErrorException;
                    throw new Exception(result.Content);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<TResponse> Get<TRequest, TResponse>(string api, TRequest request)
            where TResponse : class
        {
            var client = new RestClient(BaseAddress);
            var restRequest = new RestRequest(api, Method.GET);
            restRequest.AddJsonBody(request);
            var result = await client.ExecuteTaskAsync<TResponse>(restRequest);
            if (result.IsSuccessful)
                return result.Data;
            else
            {
                if (result.ErrorMessage != null)
                    throw new Exception(result.ErrorMessage);
                if (result.ErrorException != null)
                    throw result.ErrorException;
                throw new Exception(result.Content);
            }
        }
    }
}
