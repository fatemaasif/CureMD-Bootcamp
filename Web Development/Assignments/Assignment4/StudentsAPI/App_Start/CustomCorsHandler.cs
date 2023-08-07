using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentsAPI
{
    public class CustomCorsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Add CORS headers to allow requests from any origin (*)
            request.Headers.Add("Access-Control-Allow-Origin", "*");
            request.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            request.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");

            if (request.Method == HttpMethod.Options)
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
