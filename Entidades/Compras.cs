using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Ismarlin_Proyecto.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime FechaDeCompra { get; set; }
        
        public double ITBIS { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("CompraId")]
        public List<ComprasDetalle> Detalle { get; set; }

        [ForeignKey("Usuarios")]
        public int UsuariosId { get; set; }

        public Compras()
        {
            CompraId = 0;
            SuplidorId = 0;
            FechaDeCompra = DateTime.Now;
            
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            UsuariosId = 0;
            this.Detalle = new List<ComprasDetalle>();
        }
    }
}
