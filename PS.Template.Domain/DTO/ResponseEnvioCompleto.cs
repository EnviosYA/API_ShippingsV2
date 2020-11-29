using System.Collections.Generic;

namespace PS.Template.Domain.DTO
{
    public class ResponseEnvioCompleto
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string NombreLocalidad { get; set; }
        public int CpLocalidad { get; set; }
        public string NombreProvincia { get; set; }
        public List<ResponsePaqueteDto> Paquetes { get; set; }
        public int Costo { get; set; }
    }
}
