using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PrimerRegistro.Models;

namespace PrimerRegistro.Models
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "Usted Debe Seleccionar una facha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese el Total de Mora")]
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalle { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MorasDetalle = new List<MorasDetalle>();
        }
    }
}
