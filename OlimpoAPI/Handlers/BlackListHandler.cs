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
            //banco agencia conta produto, posto
            
            request.Headers.TryGetValues("AGENCIA", out var agenciaValues);
            request.Headers.TryGetValues("CONTA", out var contaValues);
            request.Headers.TryGetValues("BANCO", out var bancoValues);
            request.Headers.TryGetValues("PRODUTO", out var produtoValues);
            request.Headers.TryGetValues("POSTO", out var postoValues);

            var agenciaHeader = agenciaValues?.FirstOrDefault();
            var contaHeader = agenciaValues?.FirstOrDefault();
            var bancoHeader = agenciaValues?.FirstOrDefault();
            var produtoHeader = agenciaValues?.FirstOrDefault();
            var postoHeader = agenciaValues?.FirstOrDefault();
            

            if (agenciaHeader is null || contaHeader is null || bancoHeader is null || produtoHeader is null || postoHeader is null){
                return ReturnBadRequest("Requisicao bloqueada por falta de informação");
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