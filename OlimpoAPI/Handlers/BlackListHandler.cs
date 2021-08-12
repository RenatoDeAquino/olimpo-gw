using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OlimpoAPI.Handlers
{
    public class BlackListHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken){
            request.Headers.TryGetValues("CLIENT_ID", out var values);

            var clientId = values?.FirstOrDefault();

            if (clientId is null){
                return ReturnBadRequest("Request bloqueada por falta de informação");
            }

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> ReturnBadRequest(string message) => 
        Task.Factory.StartNew( () => 
            new HttpResponseMessage(HttpStatusCode.BadRequest) {
                Content = new StringContent(message)
            }
        );
    }
}