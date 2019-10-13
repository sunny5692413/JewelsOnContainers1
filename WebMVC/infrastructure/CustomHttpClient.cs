using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMVC.infrastructure
{

    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public  CustomHttpClient()  //create constructor for CustomHttpClient
        {
            _client = new HttpClient();//this is the one behind the scence get you back the reponse
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri); //send HTTP request message and as a part of message the method is get 
           if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        authorizationMethod,
                        authorizationToken);
            }

            var response = await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();//response can be json need to convert to a string
        }
        public Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }
    }
}
