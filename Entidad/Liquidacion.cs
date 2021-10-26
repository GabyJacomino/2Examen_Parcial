using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Liquidacion
    {
        [Key]
        public int idLiquidacion { get; set; }
        public decimal Desc { get; set; }
        public decimal Moratorio { get; set; }
        public decimal Interes { get; set; }
        public DateTime FechadePago { get; set; }
        public bool CalcularDiasTranscurridos(DateTime FechaInfraccion)
        {
            var dias = (FechadePago - FechaInfraccion).Days;

            if (dias >= 0)
            {
                if (dias <= 5)
                {
                    Desc = Infraccion.ValorMulta / 2;
                }
                else if (dias < 30)
                {
                    Desc = Infraccion.ValorMulta * 0.3m;
                }
                else if (dias > 30)
                {

                    Moratorio = 20 * (dias / 30);
                }
                return true;
            }
            return false;
        }
        public Infraccion Infraccion { get; set; }
        public string IdInfraccion { get; set; }
        public Infractor Infractor { get; set; }
    }
}
