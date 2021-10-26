using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Infractor
    {
        public int IdInfraccion { get; set; }
        public string TipoDocumento { get; set; }

        [Key]
        public string NumeroIdentificacion { get; set; }

        public string CodInfraccion { get; set; }
        public Infraccion Infraccion { get; set; }

        public DateTime FechaInfraccion { get; set; }
        public Liquidacion Liquidacion { get; set; }
    }
}