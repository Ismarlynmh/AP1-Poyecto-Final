using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP1PoyectoFinal.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string MarcaProducto { get; set; }
        public int Inventario { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public decimal PrecioDeCompra { get; set; }
        public DateTime FechaIngreso { get; set; }

        [ForeignKey("Suplidores")]
        public int SuplidorId { get; set; }
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuariosId { get; set; }

        public Productos()
        {
            ProductoId = 0;
            NombreProducto = string.Empty;
            MarcaProducto = string.Empty;
            Inventario = 0;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
            SuplidorId = 0;
            CategoriaId = 0;
            PrecioDeCompra = 0;
            PrecioDeVenta = 0;

        }
    }
}
