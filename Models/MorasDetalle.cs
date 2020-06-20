using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerRegistro.Models
{
    public class MorasDetalle
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese El Id de la Mora")]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "Ingrese El Id del prestamo")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Ingrese Valor de la Mora")]
        public decimal Valor { get; set; }

        public MorasDetalle()
        {
            Id = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }
    }
}
