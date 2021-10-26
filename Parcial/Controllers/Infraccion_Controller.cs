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
    public class infraccion_controller : ControllerBase
    {
        private InfraccionService service;
        public infraccion_controller(ParcialContext context)
        {
            service = new InfraccionService(context);
        }
        [HttpPost]
        public ActionResult<Infraccion> Guardar(InfraccionInputModels input)
        {
            Infraccion infraccion = mapearInfraccion(input);
            var respuesta = service.save(infraccion);
            if (respuesta.Error) return BadRequest(respuesta.Mensaje);
            return Ok(respuesta.Infraccion);
        }
        private Infraccion mapearInfraccion(InfraccionInputModels input)
        {
            Infraccion infraccion = new Infraccion();

            infraccion.CodInfraccion = input.CodInfraccion;
            infraccion.Descripcion = input.Descripcion;
            infraccion.ValorMulta = input.ValorMulta;

            return infraccion;
        }

    }
}
