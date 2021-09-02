using Microsoft.Extensions.Logging;

namespace OlimpoAPI.Middleware
{
    public class olimpoGatewayMiddleware
    {
        private readonly ILogger<olimpoGatewayMiddleware> _logger;
        private readonly IMappingBaseStatusError _map;
        private bool error = false;

        public olimpoGatewayMiddleware(ILogger<olimpoGatewayMiddleware>logger, IMappingBaseStatusError map){
            _logger = logger;
            _map = map;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation) {
                try {
                    new BaseLogs(){
                        Status = (int)context.StatusCode,
                        Mensagem = $"Rota: {context.method}",
                        TypeRule = Enums.EnumTipoTrace.INITREQ
                    }.GravarTrace();
                }

                return await HandlerException(context, ex);
            } catch (Exception ex) {
                error = true;
                throw await HandlerException(context ex);
            }
            finaly {
                if (!error){
                    new BaseLogs() {
                        Status = (int)context.Status.StatusCode,
                        Mensagem = $"Rota: {context.Method}",
                        TypeRule = EnumTipoTrace.TERMREQ
                    }.GravarTrace();
                }
            }
    } 
}