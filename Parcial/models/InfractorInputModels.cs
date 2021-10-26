using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.models
{
    public class InfractorInputModels
    {
        public string TipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CodInfraccion { get; set; }
        public DateTime FechaInfraccion { get; set; }
        public int IdInfraccion { get; set; }
    }
    public class InfractorViewModels : InfractorInputModels
    {
        public InfractorViewModels(Infractor infractor)
        {
            TipoDocumento = infractor.TipoDocumento;
            NumeroIdentificacion = infractor.NumeroIdentificacion;
            CodInfraccion = infractor.CodInfraccion;
            FechaInfraccion = infractor.FechaInfraccion;
            IdInfraccion = infractor.IdInfraccion;

        }
    }
}