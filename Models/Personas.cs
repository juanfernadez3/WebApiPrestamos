using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerRegistro.Models
{
    public class Personas
    {
        [Key]
        public int PersonaID { get; set; }

        [Required(ErrorMessage ="El Nombre es Obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es Obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La Cédula es Obligatoria.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "La Dirección es Obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimineto es Obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        public Personas()
        {
            PersonaID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
        }
    }
}
