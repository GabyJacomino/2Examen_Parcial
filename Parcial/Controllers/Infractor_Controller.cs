using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Parcial.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class infractor_controller : ControllerBase
    {
        private InfractorService service;
        public infractor_controller(ParcialContext context)
        {
            service = new InfractorService(context);
        }
        [HttpPost]
        public ActionResult<Infractor> Guardar(InfractorInputModels input)
        {
            Infractor infractor = mapearInfractor(input);
            var respuesta = service.save(infractor);
            if (respuesta.Error) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Infractor);
        }
        private Infractor mapearInfractor(InfractorInputModels input)
        {
            Infractor infractor = new Infractor();

            infractor.IdInfraccion= input.IdInfraccion;
            infractor.NumeroIdentificacion = input.NumeroIdentificacion;
            infractor.TipoDocumento = input.TipoDocumento;
            infractor.CodInfraccion = input.CodInfraccion;

            return infractor;
        }
        [HttpGet]
        public ActionResult<List<Infractor>> Consultar()
        {
            var respuesta = service.Consult();
            if (respuesta.Error) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Infractores);
        }

    }
}
