using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP1PoyectoFinal.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }
    }
}
