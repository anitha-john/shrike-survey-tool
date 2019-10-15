-- Database: shrikesurvey

-- DROP DATABASE shrikesurvey;

CREATE DATABASE shrikesurvey
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
	
-- SCHEMA: surveryengine

-- DROP SCHEMA surveryengine ;

CREATE SCHEMA surveryengine
    AUTHORIZATION postgres;
	
-- Table: surveryengine.t_survey_user



-- DROP TABLE surveryengine.t_survey_user;



CREATE TABLE surveryengine.t_survey_user

(

    email_id text COLLATE pg_catalog."default" NOT NULL,

    f_name text COLLATE pg_catalog."default",

    l_name text COLLATE pg_catalog."default",

    role_id integer NOT NULL,

    pwd text COLLATE pg_catalog."default" NOT NULL,

    CONSTRAINT "T__SURVEY_USER_pkey" PRIMARY KEY (email_id)

)

WITH (

    OIDS = FALSE

)

TABLESPACE pg_default;



ALTER TABLE surveryengine.t_survey_user

    OWNER to postgres;
	
	
CREATE SEQUENCE surveryengine.t_survey_survey_id_seq

    INCREMENT 1

    START 9

    MINVALUE 1

    MAXVALUE 9223372036854775807

    CACHE 1;



ALTER SEQUENCE surveryengine.t_survey_survey_id_seq

    OWNER TO postgres;
	
	
CREATE SEQUENCE surveryengine.t_survey_results_result_id_seq

    INCREMENT 1

    START 1

    MINVALUE 1

    MAXVALUE 9223372036854775807

    CACHE 1;



ALTER SEQUENCE surveryengine.t_survey_results_result_id_seq

    OWNER TO postgres;
	
	
CREATE SEQUENCE airecon.t_questions_master_question_id_seq

    INCREMENT 1

    START 13

    MINVALUE 1

    MAXVALUE 9223372036854775807

    CACHE 1;



ALTER SEQUENCE airecon.t_questions_master_question_id_seq

    OWNER TO postgres;
	
CREATE SEQUENCE surveryengine.t_survey_questions_survey_question_id_seq

    INCREMENT 1

    START 9

    MINVALUE 1

    MAXVALUE 9223372036854775807

    CACHE 1;



ALTER SEQUENCE surveryengine.t_survey_questions_survey_question_id_seq

    OWNER TO postgres;


-- Table: surveryengine.t_survey_questions



-- DROP TABLE surveryengine.t_survey_questions;



CREATE TABLE surveryengine.t_survey_questions

(

    survey_question_id bigint NOT NULL DEFAULT nextval('surveryengine.t_survey_questions_survey_question_id_seq'::regclass),

    survey_id bigint,

    question_id bigint,

    "order" integer,

    CONSTRAINT "T_SURVEY_QUESTIONS_pkey" PRIMARY KEY (survey_question_id)

)

WITH (

    OIDS = FALSE

)

TABLESPACE pg_default;



ALTER TABLE surveryengine.t_survey_questions

    OWNER to postgres;
	
-- Table: surveryengine.t_survey



-- DROP TABLE surveryengine.t_survey;



CREATE TABLE surveryengine.t_survey

(

    survey_id bigint NOT NULL DEFAULT nextval('surveryengine.t_survey_survey_id_seq'::regclass),

    title text COLLATE pg_catalog."default",

    created_on date,

    created_by text COLLATE pg_catalog."default",

    publish boolean,

    CONSTRAINT "T_SURVEY_pkey" PRIMARY KEY (survey_id)

)

WITH (

    OIDS = FALSE

)

TABLESPACE pg_default;



ALTER TABLE surveryengine.t_survey

    OWNER to postgres;
	
-- Table: surveryengine.t_survey_results



-- DROP TABLE surveryengine.t_survey_results;



CREATE TABLE surveryengine.t_survey_results

(

    result_id bigint NOT NULL DEFAULT nextval('surveryengine.t_survey_results_result_id_seq'::regclass),

    survey_id bigint,

    question_id bigint,

    response text COLLATE pg_catalog."default",

    given_by_email text COLLATE pg_catalog."default",

    CONSTRAINT "T_SURVEY_RESULTS_pkey" PRIMARY KEY (result_id)

)

WITH (

    OIDS = FALSE

)

TABLESPACE pg_default;



ALTER TABLE surveryengine.t_survey_results

    OWNER to postgres;
	
CREATE SEQUENCE surveryengine.t_questions_master_question_id_seq

    INCREMENT 1

    START 13

    MINVALUE 1

    MAXVALUE 9223372036854775807

    CACHE 1;



ALTER SEQUENCE surveryengine.t_questions_master_question_id_seq

    OWNER TO postgres;
	
-- Table: surveryengine.t_questions_master



-- DROP TABLE surveryengine.t_questions_master;



CREATE TABLE surveryengine.t_questions_master

(

    question_id bigint NOT NULL DEFAULT nextval('surveryengine.t_questions_master_question_id_seq'::regclass),

    question_desc text COLLATE pg_catalog."default" NOT NULL,

    question_type text COLLATE pg_catalog."default" NOT NULL,

    option_values json,

    CONSTRAINT "T_QUESTIONS_MASTER_pkey" PRIMARY KEY (question_id)

)

WITH (

    OIDS = FALSE

)

TABLESPACE pg_default;



ALTER TABLE surveryengine.t_questions_master

    OWNER to postgres;
	
	

	
	
	
