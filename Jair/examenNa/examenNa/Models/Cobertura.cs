using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examenNa.Models
{
    public class Cobertura : Auditoria
    {
        [Key]
        public int IdCobertura { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name ="Nombre")]
        public string NombreCobertura { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}