using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class LiquidacionService
    {

        private readonly ParcialContext _context;

        public LiquidacionService(ParcialContext context)
        {
            _context = context;
        }
        public LiquidacionLogReponse save(Liquidacion liquidacion)
        {
            try
            {
                if (_context.Liquidaciones.Find(liquidacion.idLiquidacion) == null)
                {
                    _context.Liquidaciones.Add(liquidacion);
                    _context.SaveChangesAsync();
                    return new LiquidacionLogReponse(liquidacion);
                }
                return new LiquidacionLogReponse("Liquidacion Ya registrado");
            }
            catch (Exception e)
            {
                return new LiquidacionLogReponse($"Error al guardar Liquidacion {e.Message}");
            }
        }
        public LiquidacionConsultaResponse Consult()
        {
            try
            {
                List<Liquidacion> liquidaciones = _context.Liquidaciones.ToList();
                if (liquidaciones != null)
                {
                    return new LiquidacionConsultaResponse(liquidaciones);
                }
                return new LiquidacionConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new LiquidacionConsultaResponse($"Error al Consultar:{e.Message}"); }


        }
        public class LiquidacionLogReponse
        {
            public Liquidacion Liquidacion { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public LiquidacionLogReponse(Liquidacion liquidacion)
            {
                Liquidacion = liquidacion;
                Error = false;
            }

            public LiquidacionLogReponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class LiquidacionConsultaResponse
        {
            public List<Liquidacion> Liquidaciones { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public LiquidacionConsultaResponse(List<Liquidacion> liquidaciones)
            {
                Liquidaciones = liquidaciones;
                Error = false;
            }

            public LiquidacionConsultaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}