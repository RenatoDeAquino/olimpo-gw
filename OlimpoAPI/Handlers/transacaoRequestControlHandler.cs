using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Net;
namespace OlimpoAPI.Handlers
{
    public class transacaoRequestControlHandler : DelegatingHandler
    {
        protected override Task <HttpResponseMessage> SendAsync (HttpRequestMessage request, CancellationToken cancelationToken)
            {
                request.Headers.TryGetValues("CHAVE_INDEPOTENTE", out var chave_idepotente_values);
                request.Headers.TryGetValues("DATA_CONTABIL", out var data_contabil_values);
                request.Headers.TryGetValues("DATA_REAL", out var data_real_values);
                request.Headers.TryGetValues("TIMEOUT_SESSION", out var timeout_session_values);
                request.Headers.TryGetValues("DEPENDENCIA", out var dependencia_values);
                request.Headers.TryGetValues("NOME_ESTACAO", out var nome_estacao_values);
                request.Headers.TryGetValues("IP", out var ip_values);

                var chave_idepotenteHeader = chave_idepotente_values?.FirstOrDefault();
                var data_contabilHeader = data_contabil_values?.FirstOrDefault();
                var data_realHeader = data_real_values?.FirstOrDefault();
                var timeout_sessionHeader = timeout_session_values?.FirstOrDefault();
                var dependenciaHeader = dependencia_values?.FirstOrDefault();
                var nome_estacaoHeader = ip_values?.FirstOrDefault();
                var ipHeader = ip_values?.FirstOrDefault();

                if (chave_idepotenteHeader is null || data_contabilHeader is null || data_realHeader is null || timeout_sessionHeader is null || dependenciaHeader is null || nome_estacaoHeader is null || ipHeader is null){
                    return ReturnBadRequest("Requisição bloqueada por falta de informação no controle de canal");
                }

                return base.SendAsync(request, cancelationToken);
            }

        private Task<HttpResponseMessage> ReturnBadRequest(string v) => 
            Task.Factory.StartNew( () => 
                new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent(v)
                }
            );
    }
}