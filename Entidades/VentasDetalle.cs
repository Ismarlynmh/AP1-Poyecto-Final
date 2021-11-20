using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Ismarlin_Proyecto.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int VentaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public VentasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            VentaId = 0;
            Cantidad = 0;
            Precio = 0;
        }
    }
}
