using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class ResponseGETEnviosDTO
    {
        public int Status { get; set; }
        public string Mensaje { get; set; }

        public ResponseGETEnviosDTO(int status, string mensaje)
        {
            this.Status = status;
            this.Mensaje = mensaje;
        }

    }
}
