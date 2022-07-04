using CRUD_de_Alumnos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CRUD_de_Alumnos.Data
{
    public class AlumnoContext : DbContext
    {
        public DbSet<AlumnoModel> TbAlumno { get; set; }

        public AlumnoContext()
        {
            /*Necesario para iniciar sqlite en iOS*/
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AlumnoDbFonsus.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
