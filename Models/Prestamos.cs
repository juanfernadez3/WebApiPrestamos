using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PrimerRegistro.Models;

namespace PrimerRegistro.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoID { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public int PersonaID { get; set; }  
        public Personas Personas { get; set; }

        public Prestamos()
        {
            PrestamoID = 0;
            Concepto = string.Empty;
            Monto = 0;
            Balance = 0;
            FechaPrestamo = DateTime.Now;
            PersonaID = 0;
        }

    }
}
