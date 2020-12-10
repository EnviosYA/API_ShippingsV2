using Moq;
using NUnit.Framework;
using PS.Template.Application.Services;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.RequestApis;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.UnitTest
{
    public class TestEnvio
    {
        private Mock<IEnvioQuery> _query;
        private Mock<IEnvioRepository> _repository;
        private Mock<IGenerateRequest> _generate;

        [SetUp]
        public void Setup()
        {
            _query = new Mock<IEnvioQuery>();
            _repository = new Mock<IEnvioRepository>();
            _generate = new Mock<IGenerateRequest>();
        }

        [Test]
        public void GetEnvioValido()
        {
            //Arrange
            int idEnvio = new Random().Next(1, 100);
            int idUsuario = new Random().Next(1, 100);
            int idDireccion = new Random().Next(1, 100);
            int costo = new Random().Next(700, 2000);
            _query.Setup(_ => _.GetEnviosQuery(idEnvio, idUsuario)).Returns(new List<ResponseEnvioDto>()
            {
                    new ResponseEnvioDto()
                    {
                        IdEnvio = idEnvio,
                        IdDireccionDestino = idDireccion,
                        Costo = costo
                    },
                    new ResponseEnvioDto()
                    {
                        IdEnvio = idEnvio+1,
                        IdDireccionDestino = idDireccion+1,
                        Costo = costo+100
                    }
            });

            EnvioService service = new EnvioService(_repository.Object, _query.Object, _generate.Object);
            //Act
            var result = service.GetEnvios(idEnvio, idUsuario);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
