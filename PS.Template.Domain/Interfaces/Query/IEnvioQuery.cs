using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IEnvioQuery
    {
        public ValorPaqueteDto ValorPaquete(int tipoPaquete);

        public List<ResponseEnvioDto> GetEnviosQuery(int unEnvio, int unUsuario);

        public List<ResponsePaqueteDto> GetPaquetes(int unEnvio);
    }
}
