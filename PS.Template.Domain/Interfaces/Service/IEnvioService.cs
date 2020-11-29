using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface IEnvioService
    {
        public ResponseRequestDto CreateEnvioPaquetes(RequestEnvioPaquetesDto envio);

        public List<ResponseEnvioCompleto> GetEnvios(int unIdEnvio, int unIdUsuario);
    }
}
