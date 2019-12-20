using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using examenNa.Models;

namespace examenNa.DAL
{
    public class ExamInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ExamContext>
    {
        protected override void Seed(ExamContext context)
        {
            InitializeCobertura(context);
        }

        private void  InitializeCobertura(ExamContext context)
        {
            var lstCoberturas = new List<Cobertura>()
            {
                new Cobertura()
                {
                    NombreCobertura = "América Latina",
                    Descripcion = "Cobertura América Latina",
                    UsuarioCreacion = "admin@mail.com",
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = "admin@mail.com",
                    FechsModificacion = DateTime.Now

                },

                new Cobertura()
                {
                    NombreCobertura = "Europa",
                    Descripcion = "Cobertura Europa",
                    UsuarioCreacion = "admin@mail.com",
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = "admin@mail.com",
                    FechsModificacion = DateTime.Now

                },

                new Cobertura()
                {
                    NombreCobertura = "Asia, Oceania",
                    Descripcion = "Asia, Oceania",
                    UsuarioCreacion = "admin@mail.com",
                    FechaCreacion = DateTime.Now,
                    UsuarioModificacion = "admin@mail.com",
                    FechsModificacion = DateTime.Now

                },

            };

            foreach (var cobertura in lstCoberturas)
            {
                if (!context.Cobertura.Any(m => m.NombreCobertura == cobertura.NombreCobertura))
                {
                    context.Cobertura.Add(cobertura);
                    context.SaveChangesAsync();
                }
            }

        }

    }
}