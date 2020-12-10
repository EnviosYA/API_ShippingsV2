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
    public class TestSucursalPorEnvio
    {
        private Mock<ISucursalPorEnvioQuery> _query;
        private Mock<ISucursalPorEnvioRepository> _repository;
        private Mock<IGenerateRequest> _generate;

        [SetUp]
        public void Setup()
        {
            _query = new Mock<ISucursalPorEnvioQuery>();
            _repository = new Mock<ISucursalPorEnvioRepository>();
            _generate = new Mock<IGenerateRequest>();
        }

        [Test]
        public void SucPorEnvioValido()
        {
            //Arrange
            int id = new Random().Next(1, 100);
            _query.Setup(_ => _.GetSucEnvio(id)).Returns(new List<ResponseSucEnvioDto>());
            SucursalPorEnvioService service = new SucursalPorEnvioService(_repository.Object, _query.Object, _generate.Object);

            //Act
            var result = service.GetSucEnvio(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void SucPorEnvioInvalido()
        {
            //Arrange
            int id = new Random().Next(1, 100);
            _query.Setup(_ => _.GetSucEnvio(id)).Returns(new List<ResponseSucEnvioDto>());
            SucursalPorEnvioService service = new SucursalPorEnvioService(_repository.Object, _query.Object, _generate.Object);

            //Act
            var result = service.GetSucEnvio(id);

            //Assert
            Assert.IsEmpty(result);
            Assert.IsEmpty(result);
        }
    }
}
