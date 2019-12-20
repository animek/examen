using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examenNa.Models
{
    public class Plan : Auditoria
    {
        [Key]
        public int IdPlanes { get; set; }
        [ForeignKey("Cobertura")]
        public int IdCobertura { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        public virtual Cobertura Cobertura { get; set; }

    }
}