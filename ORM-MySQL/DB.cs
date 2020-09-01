using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ORM_MySQL.Modelo;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ORM_MySQL
{
    class DB : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Post> posts { get; set; }

        // Setea driver y connection string a usar
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Cargar connection strings directamente en el código es peligroso...
            // Solución: http://go.microsoft.com/fwlink/?LinkId=723263
            optionsBuilder.UseMySQL("server=localhost;database=red_social;user=root;password=;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<Post>()
                .HasOne<Usuario>(s => s.creador)
                .WithMany(g => g.posts)
                .HasForeignKey(s => s.creador_id);


            /*
            modelBuilder.Entity<Post>()
                .HasRequired<Usuario>(s => s.creador)
                .WithMany(g => g.posts)
                .HasForeignKey<int>(s => s.creador_id);
            */

        }

    }
}
