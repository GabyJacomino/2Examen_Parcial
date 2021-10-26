using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.models
{
    public class InfraccionInputModels
    {
        public string CodInfraccion { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorMulta { get; set; }
    }

    public class InfraccionViewModels : InfraccionInputModels
    {
        public InfraccionViewModels(Infraccion infraccion)
        {
            CodInfraccion = infraccion.CodInfraccion;
            Descripcion = infraccion.Descripcion;
            ValorMulta = infraccion.ValorMulta;
        }
    }
}
