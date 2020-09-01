using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_MySQL.Modelo
{
    // Asociación con tabla posts
    [Table("posts")]
    class Post
    {

        // Marca que este atributo es la primary key
        [Key]
        // Define que se debe relacionar con la columna post_id de la tabla
        [Column("post_id")]
        public int id { get; set; }

        // Define que se debe relacionar con la columna texto de la tabla
        [Column("texto")]
        public string texto { get; set; }

        [Column("usuario_id")]
        // Esta seria la FK a usuario
        public int creador_id { get; set; }

        // Este es el objeto usuario al que se relaciona el post
        // Relacion hecha con Fluent API en DB.cs
        public Usuario creador { get; set; }

    }

}
