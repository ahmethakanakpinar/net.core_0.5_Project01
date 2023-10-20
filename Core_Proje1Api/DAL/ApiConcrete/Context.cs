using Core_Proje1Api.DAL.ApiEntity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core_Proje1Api.DAL.ApiConcrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=PC309\\SQLEXPRESS;database=CoreProje1ApiDB;integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
