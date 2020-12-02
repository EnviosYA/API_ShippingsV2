using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Service;
using System;
using TP2.REST.Domain.DTO;

namespace PS.Template.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SucursalPorEnvioController : ControllerBase
    {
        private readonly ISucursalPorEnvioService _servicio;

        public SucursalPorEnvioController(ISucursalPorEnvioService servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public IActionResult Post(CreateSucEnvioRequestDto sucEnvio)
        {
            try
            {
                return new JsonResult(_servicio.CreateSucEnvio(sucEnvio)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(_servicio.GetSucEnvio(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(new GenericCreatedResponseDTO() { Entity = "Sucursal Por Envio", Id = "0"}) { StatusCode = 400 };
            }
        }
    }
}
