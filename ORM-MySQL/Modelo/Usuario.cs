﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM_MySQL.Modelo
{
    // Asociación con tabla usuarios
    [Table("usuarios")]
    class Usuario
    {

        // Marca que este atributo es la primary key
        [Key]
        // Define que se debe relacionar con la columna usuario_id de la tabla
        [Column("usuario_id")]
        public int id { get; set; }

        // Define que se debe relacionar con la columna nombre de la tabla
        [Column("nombre")]
        public string nombre { get; set; }

        // Define que se debe relacionar con la columna email de la tabla
        [Column("email")]
        public string email { get; set; }

        // Relacion contra muchos posts
        // Relacion hecha con Fluent API en DB.cs
        public List<Post> posts { get; set; }

    }

}
