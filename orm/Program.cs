using Npgsql;
using orm.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm
{
    class Program
    {
        static void Main(string[] args)
        {

            // Construimos un objeto DB para poder realizar las consultas
            // Su ciclo de vida es hasta que finalize el using
            using (var context = new DB())
            {
                
                // Podemos consultar por usuarios y posts segun lo definido en la clase DB nuestra
                // Si se fijan no dejan de ser listas asi que respetan todas las funciones de listas que
                // comunmente usamos

                // Consultemos la cantidad de usuarios creados
                var cantUsuarios = context.usuarios.ToArray();
                Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");

                // Ahora creemos un usuario
                // Fijense que al definir el ID como autoincremental en la DB, no hace falta setearle alguno.
                var usuario = new Usuario();
                usuario.nombre = "admin";
                usuario.email = "admin@admin.com";
                
                // Lo agrego a la lista de usuarios
                context.usuarios.Add(usuario);

                // Subo los cambios a la DB
                context.SaveChanges();
                Console.WriteLine($"Usuario {usuario.nombre} creado");

                // Consulto nuevamente cantidad de usuarios
                cantUsuarios = context.usuarios.ToArray();
                Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");
                
                // Ahora quiero borrar a ese usuario
                var usuarioABorrar = context.usuarios.Single(x => x.nombre == "admin");
                context.usuarios.Remove(usuarioABorrar);
                Console.WriteLine($"Usuario {usuarioABorrar.nombre} borrado");
                context.SaveChanges();
                
                // Consulto nuevamente cantidad de usuarios
                cantUsuarios = context.usuarios.ToArray();
                Console.WriteLine($"Existen {cantUsuarios.Length} usuario(s).");

                // Agrego un usuario con posts
                var usuarioConPost = new Usuario();
                usuarioConPost.nombre = "asd123";
                usuarioConPost.email = "asd123@gmail.com";
                Post post = new Post();
                post.texto = "Hola mundo";
                usuarioConPost.posts = (List<Post>) new List<Post> { post };
                context.usuarios.Add(usuarioConPost);
                context.SaveChanges();
                Console.WriteLine($"Creado post con id {post.id}");

                // Agrego post al usuario anterior
                var nuevoPost = new Post();
                nuevoPost.texto = "Otro post mas";
                nuevoPost.creador = usuarioConPost;
                context.posts.Add(nuevoPost);
                context.SaveChanges();
                Console.WriteLine($"Creado post con id {nuevoPost.id}");

                // Consulto los post de este usuario nuevo
                var usuarioConsultaPost = context.usuarios.Single(x => x.nombre == "asd123");

                Console.WriteLine($"Post del usuario {usuarioConsultaPost.nombre}:");
                foreach (Post x in usuarioConsultaPost.posts)
                {
                    Console.WriteLine($"{x.id} - {x.texto}");
                }

                // Vacio tabla
                context.clear(context.posts);
                context.clear(context.usuarios);
                context.SaveChanges();
                Console.WriteLine("Vaciando la tabla");

            }

            // Evita que se corte la ejecucion del programa
            Console.WriteLine("Finalizo ejecucion, pulsa una tecla para continuar");
            Console.ReadLine();

        }

    }
}
