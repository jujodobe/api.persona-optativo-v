-- public.persona definition

-- Drop table

-- DROP TABLE public.persona;

CREATE TABLE public.persona (
	id serial4 NOT NULL,
	nombre varchar(50) NOT NULL,
	apellido varchar(50) NOT NULL,
	cedula varchar(15) NULL,
	CONSTRAINT persona_pk PRIMARY KEY (id)
);