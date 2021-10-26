using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Infraccion
    {
        [Key]
        public string CodInfraccion { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorMulta { get; set; }

        public ICollection<Infractor> Infractores { get; set; }
     
    }
}