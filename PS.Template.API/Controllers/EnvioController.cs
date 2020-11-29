using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Service;
using System;

namespace PS.Template.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _service;

        public EnvioController(IEnvioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostEnvioPaquetes(RequestEnvioPaquetesDto request)
        {
            try
            {
                return new JsonResult(_service.CreateEnvioPaquetes(request)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetEnvios([FromQuery] int envio, [FromQuery] int usuario)
        {
            try
            {
                var result = _service.GetEnvios(envio, usuario);

                if (result != null)
                {
                    return new JsonResult(result) { StatusCode = 200 };
                }
                else
                {
                    return BadRequest("No existe el envío o el usuario no tiene envíos");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
