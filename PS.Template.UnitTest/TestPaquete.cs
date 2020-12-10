using Moq;
using NUnit.Framework;
using PS.Template.Application.Services;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.UnitTest
{
    public class TestPaquete
    {
        private Mock<IPaqueteQuery> _query;
        protected Mock<IPaqueteRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _query = new Mock<IPaqueteQuery>();
            _repository = new Mock<IPaqueteRepository>();
        }

        [Test]
        public void GetByIdValido()
        {
            //Arrange
            int id = new Random().Next(1, 5);
            _query.Setup(_ => _.GetPaquete(id)).Returns(new ResponsePaqueteDto() { 
                TipoPaquete = 3.ToString(),
                Peso = 0,
                Largo = 0,
                Ancho = 0,
                Alto = 0
            });

            PaqueteService service = new PaqueteService(_repository.Object, _query.Object);

            //Act
            var result = service.GetPaquete(id);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetByIdInvalido()
        {
            //Arrange
            int id = new Random().Next(6, 100);

            PaqueteService service = new PaqueteService(_repository.Object, _query.Object);

            //Act
            var result = service.GetPaquete(id);

            //Assert
            Assert.IsNull(result);
        }
    }
}
