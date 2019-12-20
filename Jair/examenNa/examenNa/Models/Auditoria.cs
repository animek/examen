using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examenNa.Models
{
    public class Auditoria
    {

        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechsModificacion { get; set; }
    }
}