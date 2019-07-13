CREATE TABLE usuarios(
	usuario_id serial PRIMARY KEY,
	nombre VARCHAR (50) UNIQUE NOT NULL,
	email VARCHAR (355) UNIQUE NOT NULL
);

CREATE TABLE posts(
	post_id serial PRIMARY KEY,
	texto VARCHAR (500) NOT NULL,
	usuario_id int,
	CONSTRAINT usuario_post_usuario_id FOREIGN KEY (usuario_id)
	REFERENCES usuarios (usuario_id) MATCH SIMPLE
	ON UPDATE NO ACTION ON DELETE NO ACTION
);