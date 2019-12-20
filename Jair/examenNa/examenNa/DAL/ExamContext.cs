using examenNa.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace examenNa.DAL
{
    public class ExamContext : DbContext
    {
        public ExamContext() : base("examDataContext")
        {
        }

        public DbSet<Cobertura> Cobertura { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}