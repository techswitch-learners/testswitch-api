
CREATE DATABASE "TestSwitch" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United Kingdom.1252' LC_CTYPE = 'English_United Kingdom.1252';

\connect "TestSwitch"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

CREATE TABLE public."Candidates" (
    "FirstName" character varying(128) NOT NULL,
    "LastName" character varying(128) NOT NULL,
    "Email" character varying(128) NOT NULL,
    "Id" bigint NOT NULL
);

CREATE TABLE public."Results" (
    "CandidateId" bigint NOT NULL,
    "TestId" integer,
    "TestResult" character(1)
);

CREATE TABLE public."Tests" (
    "ModelAnswer" character(1) NOT NULL,
    "TestId" integer NOT NULL
);

CREATE SEQUENCE public.candidate_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER SEQUENCE public.candidate_id_seq OWNED BY public."Candidates"."Id";

ALTER TABLE public."Results" ALTER COLUMN "CandidateId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.result_candidate_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


ALTER TABLE ONLY public."Candidates" ALTER COLUMN "Id" SET DEFAULT nextval('public.candidate_id_seq'::regclass);

INSERT INTO public."Candidates" ("FirstName", "LastName", "Email", "Id") VALUES ('Peter', 'Parker', 'amazing@web.net', 1);
INSERT INTO public."Candidates" ("FirstName", "LastName", "Email", "Id") VALUES ('Faye', 'Valentine', 'myfunny@valentine.com', 2);
INSERT INTO public."Candidates" ("FirstName", "LastName", "Email", "Id") VALUES ('Bruce', 'Wayne', 'darkKnight@gotham.com', 3);

SELECT pg_catalog.setval('public.candidate_id_seq', 3, true);

SELECT pg_catalog.setval('public.result_candidate_id_seq', 1, false);

ALTER TABLE ONLY public."Candidates"
    ADD CONSTRAINT candidate_id_pk PRIMARY KEY ("Id");

ALTER TABLE ONLY public."Candidates"
    ADD CONSTRAINT email_uc UNIQUE ("Email");

ALTER TABLE ONLY public."Tests"
    ADD CONSTRAINT test_id_pk PRIMARY KEY ("TestId");


CREATE INDEX fki_candidate_id_fk ON public."Results" USING btree ("CandidateId");

CREATE INDEX fki_test_id_fk ON public."Results" USING btree ("TestId");

ALTER TABLE ONLY public."Results"
    ADD CONSTRAINT candidate_id_fk FOREIGN KEY ("CandidateId") REFERENCES public."Candidates"("Id") NOT VALID;


ALTER TABLE ONLY public."Results"
    ADD CONSTRAINT test_id_fk FOREIGN KEY ("TestId") REFERENCES public."Tests"("TestId") NOT VALID;
