using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP1PoyectoFinal.Entidades
{
    public class Empleados
    { 
		[Key]
		public int EmpleadoId { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Cedula { get; set; }
		public string Telefono { get; set; }
		public string Celular { get; set; }
		public string Direccion { get; set; }
		public string Email { get; set; }
		public string Cargo { get; set; }
		public decimal Sueldo { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public DateTime FechaIngreso { get; set; }

		public Empleados()
		{
			EmpleadoId = 0;
			Nombres = string.Empty;
			Apellidos = string.Empty;
			Cedula = string.Empty;
			Telefono = string.Empty;
			Celular = string.Empty;
			Direccion = string.Empty;
			Email = string.Empty;
			Cargo = string.Empty;
			Sueldo = 0;
			FechaNacimiento = DateTime.Now;
			FechaIngreso = DateTime.Now;

		}
	}
}
