using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examenNa.Models
{
    public class Cliente : Auditoria
    {
        [Key]
        public Guid  IdCliente { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApePaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApeNaterno { get; set; }

        [ForeignKey("Plan")]
        public int IdPlan { get; set; }

        public virtual Plan Plan { get; set; }


    }
}