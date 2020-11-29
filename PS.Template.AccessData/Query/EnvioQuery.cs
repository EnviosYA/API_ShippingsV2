using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PS.Template.AccessData.Query
{
    public class EnvioQuery : IEnvioQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public EnvioQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            _connection = connection;
            _sqlKataCompiler = sqlKataCompiler;
        }
        public List<ResponseEnvioDto> GetEnviosQuery(int unEnvio, int unUsuario)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Envio").
                Select("Envio.idEnvio AS IdEnvio",
                        "Envio.idDireccionDestino AS IdDireccionDestino",
                        "Envio.Costo AS Costo")
                .When(unEnvio != 0, q => q.Where("Envio.idEnvio", "=", unEnvio))
                .When(unUsuario != 0, q => q.Where("Envio.idUserOrigen", "=", unUsuario))
                .Get<ResponseEnvioDto>()
                .ToList();

            return query;
        }

        public List<ResponsePaqueteDto> GetPaquetes(int unEnvio)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Paquete")
               .Select("TipoPaquete.Descripcion AS TipoPaquete",
               "Paquete.Peso AS Peso",
               "Paquete.Ancho AS Ancho",
               "Paquete.Largo AS Largo",
               "Paquete.Alto AS Alto")
               .Join("TipoPaquete", "TipoPaquete.idTipoPaquete", "Paquete.idTipoPaquete")
               .Where("Paquete.idEnvio", unEnvio)
               .Get<ResponsePaqueteDto>()
               .ToList();

            return query;
        }

        public ValorPaqueteDto ValorPaquete(int tipoPaquete)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("TipoPaquete")
                .Select("TipoPaquete.Valor")
                .Where("TipoPaquete.idTipoPaquete", tipoPaquete)
                .Get<ValorPaqueteDto>()
                .FirstOrDefault();

            return query;
        }
    }
}
