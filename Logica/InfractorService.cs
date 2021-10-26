using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class InfractorService
    {
        private readonly ParcialContext _context;

        public InfractorService(ParcialContext context)
        {
            _context = context;
        }
        public InfractorLogReponse save(Infractor infractor)
        {
            try
            {
                if (_context.Infractores.Find(infractor.NumeroIdentificacion) == null)
                {
                    _context.Infractores.Add(infractor);
                    _context.SaveChangesAsync();
                    return new InfractorLogReponse(infractor);
                }
                return new InfractorLogReponse("Infractor Ya registrado");
            }
            catch (Exception e)
            {
                return new InfractorLogReponse($"Error al guardar Infractor {e.Message}");
            }
        }
        public InfractorConsultaResponse Consult()
        {
            try
            {
                List<Infractor> infractores = _context.Infractores.ToList();
                if (infractores != null)
                {
                    return new InfractorConsultaResponse(infractores);
                }
                return new InfractorConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new InfractorConsultaResponse($"Error al Consultar:{e.Message}"); }


        }
        public class InfractorLogReponse
        {
            public Infractor Infractor { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public InfractorLogReponse(Infractor infractor)
            {
                Infractor = infractor;
                Error = false;
            }

            public InfractorLogReponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
        public class InfractorConsultaResponse
        {
            public List<Infractor> Infractores { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public InfractorConsultaResponse(List<Infractor> infractores)
            {
                Infractores = infractores;
                Error = false;
            }

            public InfractorConsultaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}