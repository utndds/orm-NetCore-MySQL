
### Introducción y cosas a tener en cuenta

Hay muchas cosas por explicar que tratare de resumirlas en este documento.

Primero el proyecto es una aplicación consola hecha con .NET Core (si el proyecto de ustedes es .NET Framework difiere en los paquetes a instalar y por ende en algunos métodos y configuraciones). Tienen la opción de migrar su proyecto a .NET Core creando un proyecto nuevo y copiando/pegando clases...

Tambien hay que distinguir que existen los ORM y los módulos de conexión a bases de datos, siendo que en este ejemplo (.NET Core) estamos usando los paquetes Nugget:

- **Microsoft.EntityFrameworkCore** como ORM
- **MySql.Data.EntityFrameworkCore** como módulo conector entre el ORM y el motor MySQL

Como definimos en la clase la idea es que ustedes diseñen las tablas de la base de datos, diseñen su modelo clases, y luego, a través del ORM lo puedan conectar funcionando como un simple "traductor" entre relacional y objetos. Pero la verdad es que los ORM, hoy en dia, estan hechos de manera tal o apuntan a hacer exactamente lo contrario. Esto significa solamente diseñar una de estas "dos caras" y que el ORM autogenere la otra, con obviamente, un montón de limitaciones.

Debido a esto, como discutimos tambien, el ORM hace mucha :sparkles::sparkles:*magia*:sparkles::sparkles: por detrás y asume muchas cosas que en un principio, al nivel que queremos programar nosotros, no estan copadas y vamos a tratar de no usarlas.
Algunos ejemplos son:

- asociar nombre de clases con nombres de tablas
- asociar nombres de columnas con nombres de atributos
- asociar el atributo id genérico con la columna primary key de un tabla.
- entre muchos otros...

Explicamos en clase la idea de Annotations que son una forma de "caracterizar" a los atributos, metodos y clases de nuestro modelo, algo usado por la mayoria de los ORM hoy en día para poder vincular las clases con las distintas tablas de la DB. Entity Framework se basa en esta idea, pero además, suma otra llamada Fluent API que no deja de ser la posibilidad de definir traducciones objeto-relacional pero una forma mas customizable para el programador.
Ambas son compatibles entre si, asi que ustedes pueden elegir si usan solo una o las dos formas al mismo tiempo, la verdad es que a mi parecer las Annotation en algun momento les van a quedar cortas de funcionalidad...


### Respecto al ejemplo

Para que funcione tienen que montar un servidor de DB motor MySQL (se recomienda el uso de XAMPP) y conectarlo al programa escribiendo las credenciales correspondientes en el archivo DB.cs

Las instrucciones de como funciona cada parte se encuentran comentadas en el código para un mejor seguimiento, cualquier duda que tengan respecto al funcionamiento les pido por favor que creen un Issue comentandolo ya que a otros les puede servir la respuesta.


### Fuentes

- Para proyecto .NET Framework
[Guia de Entity Framework Core](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
[Entity Framework 6 con MySQL](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html)<br>

- Para proyecto .NET Core
[Guia de Entity Framework Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
[Entity Framework Core con MySQL](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html)<br>
