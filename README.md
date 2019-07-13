
### Introducción y cosas a tener en cuenta

Hay muchas cosas por explicar que tratare de resumirlas en este documento.
Por empezar hay que distinguir que existen los ORM y los módulos de conexión a bases de datos, siendo que en este ejemplo estamos usando:

- **Entity Framework 6** como ORM
- **Npgsql** como módulo conector para el motor PostgreSQL
- **Npgsql.EntityFramework6** como módulo intermediario entre el ORM y el conector

Teniendo esto en cuenta, cuando naveguen por internet, se van a encontrar que el ORM EntityFramework esta divido en dos versiones, una llamada 'Core' y otra llamada '6'. Como dije antes, el ejemplo esta hecho con la version '6', aunque las dos ofrecen lo mismo cambiando algunas funcionalidades específicas.

Como definimos en la clase la idea es que ustedes diseñen las tablas de la base de datos, diseñen su modelo clases, y luego, a través del ORM lo puedan conectar funcionando como un simple "traductor" entre relacional y objetos. Pero la verdad es que los ORM, hoy en dia, estan hechos de manera tal o apuntan a hacer exactamente lo contrario. Esto significa solamente diseñar una de estas "dos caras" y que el ORM autogenere la otra, con obviamente, un montón de limitaciones.

Debido a esto, como discutimos tambien, el ORM hace mucha :sparkles::sparkles:*magia*:sparkles::sparkles: por detrás y asume muchas cosas que en un principio, al nivel que queremos programar nosotros, no estan copadas y vamos a tratar de no usarlas.
Algunos ejemplos son:

- asociar nombre de clases con nombres de tablas
- asociar nombres de columnas con nombres de atributos
- asociar el atributo id genérico con la columna primary key de un tabla.
- entre muchos otros...

> **Easter egg:**
> Al empezar a codear este ejemplo tuve problemas de conexión a la DB a través del ORM. Al principio pense que era algo que estaba haciendo mal yo, pero al probar la conexión de manera directa no habia ningun problema, solo pasaba si el ORM interferia. Luego de buscar un buen rato por Google me entero que aun diciendole al Entity Framework que no queria que se iniciase en el modo Code-First, el muchacho no tenia la mejor idea que igualmente tratar de volver a crear la base de datos, que ya estaba creada, cosa para lo cual no tenia permisos por ende me rompia la conexión... Sin palabras

Explicamos en clase la idea de Annotations que son una forma de "caracterizar" a los atributos, metodos y clases de nuestro modelo, algo usado por la mayoria de los ORM hoy en día para poder vincular las clases con las distintas tablas de la DB. Entity Framework se basa en esta idea, pero además, suma otra llamada Fluent API que no deja de ser la posibilidad de definir traducciones objeto-relacional pero una forma mas customizable para el programador.
Ambas son compatibles entre si, asi que ustedes pueden elegir si usan solo una o las dos formas al mismo tiempo, la verdad es que a mi parecer las Annotation en algun momento les van a quedar cortas de funcionalidad...


### Respecto al ejemplo

En este ejemplo ustedes tienen una solución al ejercicio dado en clase (link adjunto al final). La solución incluye un archivo .sql para la construcción de las tablas en el motor PostgreSQL, conexión funcionando del ORM a una DB de Heroku, y el mapeo objeto-relacional.

> **Disclaimer:**
> Si la conexión no funciona es porque Heroku cada X tiempo cambia las credenciales de acceso a la DB, si quieren probarlo por su cuenta pueden montarse localmente una DB PostgreSQL o crear una en la nube con Heroku.

Las instrucciones de como funciona cada parte se encuentran comentadas en el código para un mejor seguimiento, cualquier duda que tengan respecto al funcionamiento les pido por favor que creen un Issue comentandolo ya que a otros les puede servir la respuesta.


### Fuentes

[Entity Framework 6 - Tutorial](https://www.entityframeworktutorial.net/code-first/database-initialization-in-code-first.aspx)<br>
[Entity Framework - ABM](https://www.learnentityframeworkcore.com/dbcontext/adding-data)
[Consigna del ejercicio](https://docs.google.com/document/d/1giXxG78c4Hb9OO5VzccLew9QRyhyUPzAEsPS0cqPkMI/edit?usp=sharing)<br>
(y otras 20 páginas distintas más que visite pero no suman tanto)