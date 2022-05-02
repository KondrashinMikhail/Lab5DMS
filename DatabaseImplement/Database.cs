using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false) optionsBuilder.UseSqlServer(
                @"Data Source=LAPTOP-87RD5TMK\SQLEXPRESS1;Initial Catalog=Database;Integrated Security=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Cure> Cures { get; set; }
        public virtual DbSet<DiseaseStory> DiseaseStories { get; set; }
    }
}
