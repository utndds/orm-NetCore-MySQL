using orm.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm
{

    // Construimos nuestro propia clase DB en base a DbContext
    class DB : DbContext
    {

        // Aca se listan las colecciones por las cuales vamos a consultar
        // en este caso usuarios y posts
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Post> posts { get; set; }

        // Usamos el constructor base pasandole la referencia al string de conexion
        // El string de conexion esta definido en el App.config
        public DB() : base(nameOrConnectionString: "heroku") {

            // Esto setea que es lo que tiene que hacer EntityFramework al conectarse a la DB,
            // en este caso como no queremos que haga sus 'creaciones magicas' le decimos que nada.
            Database.SetInitializer<DB>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasRequired<Usuario>(s => s.creador)
                .WithMany(g => g.posts)
                .HasForeignKey<int>(s => s.creador_id);

        }

        // Borra todos los registros del set pasado
        public void clear(DbSet dbSet)
        {
            dbSet.RemoveRange(dbSet);
        }

    }

}
