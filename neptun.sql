-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION pg_database_owner;

COMMENT ON SCHEMA public IS 'standard public schema';
-- public.class_nomera definition

-- Drop table

-- DROP TABLE public.class_nomera;

CREATE TABLE public.class_nomera (
	id int4 NOT NULL,
	"name" varchar(100) NOT NULL,
	CONSTRAINT class_nomera_pk PRIMARY KEY (id)
);


-- public.clientnomers definition

-- Drop table

-- DROP TABLE public.clientnomers;

CREATE TABLE public.clientnomers (
	id int4 NOT NULL,
	nomer varchar(100) NOT NULL,
	class_nomera varchar(100) NOT NULL,
	status_nomera varchar(100) NOT NULL,
	mainimagepath varchar(100) NULL,
	"cost" numeric(19, 4) NOT NULL,
	CONSTRAINT clientnomers_pk PRIMARY KEY (id)
);


-- public.clients definition

-- Drop table

-- DROP TABLE public.clients;

CREATE TABLE public.clients (
	id int4 NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	patronyc varchar(50) NOT NULL,
	data_birthday timestamp NULL,
	adress varchar(1000) NOT NULL,
	phone varchar(50) NOT NULL,
	email varchar(225) NOT NULL,
	passport_dannie varchar(1000) NOT NULL,
	data_progivaniya timestamp NULL,
	CONSTRAINT clients_pk PRIMARY KEY (id)
);


-- public.dolgnosty definition

-- Drop table

-- DROP TABLE public.dolgnosty;

CREATE TABLE public.dolgnosty (
	id int4 NOT NULL,
	name1 varchar(100) NOT NULL,
	CONSTRAINT dolgnosty_pk PRIMARY KEY (id)
);


-- public.status_nomera definition

-- Drop table

-- DROP TABLE public.status_nomera;

CREATE TABLE public.status_nomera (
	id int4 NOT NULL,
	"name" varchar(100) NOT NULL,
	CONSTRAINT status_nomera_pk PRIMARY KEY (id)
);


-- public.type_nomera definition

-- Drop table

-- DROP TABLE public.type_nomera;

CREATE TABLE public.type_nomera (
	id int4 NOT NULL,
	"name" varchar(10) NOT NULL,
	CONSTRAINT type_nomera_pk PRIMARY KEY (id)
);


-- public.zayavki definition

-- Drop table

-- DROP TABLE public.zayavki;

CREATE TABLE public.zayavki (
	id int4 NOT NULL,
	nomer varchar(100) NOT NULL,
	first_name varchar(100) NOT NULL,
	last_name varchar(100) NOT NULL,
	patronimyc varchar(100) NOT NULL,
	data_birthday timestamp NOT NULL,
	email varchar(225) NULL,
	phone varchar(50) NULL,
	categoriya_nomera varchar(100) NULL,
	"kol-vo_progivaushih" varchar(100) NULL,
	status_zaprosa varchar(100) NULL,
	data_zaezda timestamp NOT NULL,
	data_viezda timestamp NOT NULL,
	status_zayavki varchar(100) NOT NULL,
	CONSTRAINT zayavki_pk PRIMARY KEY (id)
);


-- public.nomera_otel definition

-- Drop table

-- DROP TABLE public.nomera_otel;

CREATE TABLE public.nomera_otel (
	id_nomera int4 NOT NULL,
	id_class_nomera int4 NOT NULL,
	description varchar(1000) NOT NULL,
	mainimagepeth varchar(1000) NOT NULL,
	nomer varchar(100) NOT NULL,
	"cost" numeric(19) NOT NULL,
	promegutok_zanyat datemultirange NULL,
	discount numeric(19) NULL,
	CONSTRAINT newtable_pk PRIMARY KEY (id_nomera),
	CONSTRAINT nomera_otel_fk FOREIGN KEY (id_class_nomera) REFERENCES public.class_nomera(id)
);


-- public.sotrudniki definition

-- Drop table

-- DROP TABLE public.sotrudniki;

CREATE TABLE public.sotrudniki (
	id int4 NOT NULL,
	id_dolgnosti int4 NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	patronymic varchar(50) NOT NULL,
	data_birthday timestamp NOT NULL,
	email varchar(225) NULL,
	phone varchar(20) NOT NULL,
	data_priema_na_rabotu timestamp NOT NULL,
	adress varchar(1000) NOT NULL,
	login varchar(50) NOT NULL,
	"password" varchar(50) NOT NULL,
	data_uvolneniya timestamp NULL,
	CONSTRAINT sotrudniki_pk PRIMARY KEY (id),
	CONSTRAINT sotrudniki_fk FOREIGN KEY (id_dolgnosti) REFERENCES public.dolgnosty(id)
);


-- public.zapisi definition

-- Drop table

-- DROP TABLE public.zapisi;

CREATE TABLE public.zapisi (
	id int4 NOT NULL,
	id_klienta int4 NOT NULL,
	id_nomera int4 NOT NULL,
	date_zaezda date NOT NULL,
	date_viezda date NOT NULL,
	id_menegera int4 NOT NULL,
	cost_nomera money NOT NULL,
	CONSTRAINT zapisi_pk PRIMARY KEY (id),
	CONSTRAINT zapisi_fk FOREIGN KEY (id_menegera) REFERENCES public.sotrudniki(id),
	CONSTRAINT zapisi_fk_1 FOREIGN KEY (id_klienta) REFERENCES public.clients(id)
);
