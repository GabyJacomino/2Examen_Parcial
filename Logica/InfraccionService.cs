using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class InfraccionService
    {
        private readonly ParcialContext _context;

        public InfraccionService(ParcialContext context)
        {
            _context = context;
        }
        public InfraccionLogReponse save(Infraccion infraccion)
        {
            try
            {
                if (_context.Infracciones.Find(infraccion.CodInfraccion) == null)
                {
                    _context.Infracciones.Add(infraccion);
                    _context.SaveChangesAsync();
                    return new InfraccionLogReponse(infraccion);
                }
                return new InfraccionLogReponse("Infraccion Ya registrado");
            }
            catch (Exception e)
            {
                return new InfraccionLogReponse($"Error al guardar Infraccion {e.Message}");
            }
        }
        public InfraccionConsultaResponse Consult()
        {
            try
            {
                List<Infraccion> infracciones = _context.Infracciones.ToList();
                if (infracciones != null)
                {
                    return new InfraccionConsultaResponse(infracciones);
                }
                return new InfraccionConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new InfraccionConsultaResponse($"Error al Consultar:{e.Message}"); }


        }
        public class InfraccionLogReponse
        {
            public Infraccion Infraccion { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public InfraccionLogReponse(Infraccion infraccion)
            {
                Infraccion = infraccion;
                Error = false;
            }

            public InfraccionLogReponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class InfraccionConsultaResponse
        {
            public List<Infraccion> Infracciones { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public InfraccionConsultaResponse(List<Infraccion> infracciones)
            {
                Infracciones = infracciones;
                Error = false;
            }

            public InfraccionConsultaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}