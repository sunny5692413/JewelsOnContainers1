using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMVC.infrastructure
{
    public interface IHttpClient  //end of the pipe before micro services
    {
        Task<string> GetStringAsync(string uri,   
            string authorizationToken = null,
            string authorizationMethod = "Bearer");  // asyncs return are tasks of sth,return is a string , API path give the URL that need to post
        Task<HttpResponseMessage> PostAsync<T>(string uri,
            T item,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");//submitting a body of message,could be posting anything, so make it <t>,T item is send to micro service
        Task<HttpResponseMessage> PutAsync<T>(string uri,
            T item,
            string authorizationToken = null,
            string authorizationMethod = "Bearer"); //edit object
        Task<HttpResponseMessage> DeleteAsync(string uri,
            string authorizationToken = null,
            string authorizationMethod = "Bearer");
    }
}
