
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

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 26364)
-- Name: Candidate; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Candidate" (
    "FirstName" character varying(128) NOT NULL,
    "LastName" character varying(128) NOT NULL,
    "Email" character varying(128) NOT NULL,
    "Id" bigint NOT NULL
);


ALTER TABLE public."Candidate" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 26378)
-- Name: Result; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Result" (
    "CandidateId" bigint NOT NULL,
    "TestId" integer,
    "TestResult" character(1)
);


ALTER TABLE public."Result" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 26369)
-- Name: Test; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Test" (
    "ModelAnswer" character(1) NOT NULL,
    "TestId" integer NOT NULL
);


ALTER TABLE public."Test" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 26372)
-- Name: candidate_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.candidate_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.candidate_id_seq OWNER TO postgres;

--
-- TOC entry 2845 (class 0 OID 0)
-- Dependencies: 204
-- Name: candidate_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.candidate_id_seq OWNED BY public."Candidate"."Id";


--
-- TOC entry 206 (class 1259 OID 26381)
-- Name: result_candidate_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Result" ALTER COLUMN "CandidateId" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.result_candidate_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2697 (class 2604 OID 26374)
-- Name: Candidate "Id"; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Candidate" ALTER COLUMN "Id" SET DEFAULT nextval('public.candidate_id_seq'::regclass);


--
-- TOC entry 2834 (class 0 OID 26364)
-- Dependencies: 202
-- Data for Name: Candidate; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Candidate" ("FirstName", "LastName", "Email", "Id") VALUES ('Peter', 'Parker', 'amazing@web.net', 1);
INSERT INTO public."Candidate" ("FirstName", "LastName", "Email", "Id") VALUES ('Faye', 'Valentine', 'myfunny@valentine.com', 2);
INSERT INTO public."Candidate" ("FirstName", "LastName", "Email", "Id") VALUES ('Bruce', 'Wayne', 'darkKnight@gotham.com', 3);


--
-- TOC entry 2837 (class 0 OID 26378)
-- Dependencies: 205
-- Data for Name: Result; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2835 (class 0 OID 26369)
-- Dependencies: 203
-- Data for Name: Test; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2846 (class 0 OID 0)
-- Dependencies: 204
-- Name: candidate_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.candidate_id_seq', 3, true);


--
-- TOC entry 2847 (class 0 OID 0)
-- Dependencies: 206
-- Name: result_candidate_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.result_candidate_id_seq', 1, false);


--
-- TOC entry 2699 (class 2606 OID 26387)
-- Name: Candidate candidate_id_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Candidate"
    ADD CONSTRAINT candidate_id_pk PRIMARY KEY ("Id");


--
-- TOC entry 2701 (class 2606 OID 26415)
-- Name: Candidate email_uc; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Candidate"
    ADD CONSTRAINT email_uc UNIQUE ("Email");


--
-- TOC entry 2703 (class 2606 OID 26395)
-- Name: Test test_id_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Test"
    ADD CONSTRAINT test_id_pk PRIMARY KEY ("TestId");


--
-- TOC entry 2704 (class 1259 OID 26393)
-- Name: fki_candidate_id_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_candidate_id_fk ON public."Result" USING btree ("CandidateId");


--
-- TOC entry 2705 (class 1259 OID 26403)
-- Name: fki_test_id_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_test_id_fk ON public."Result" USING btree ("TestId");


--
-- TOC entry 2706 (class 2606 OID 26388)
-- Name: Result candidate_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Result"
    ADD CONSTRAINT candidate_id_fk FOREIGN KEY ("CandidateId") REFERENCES public."Candidate"("Id") NOT VALID;


--
-- TOC entry 2707 (class 2606 OID 26398)
-- Name: Result test_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Result"
    ADD CONSTRAINT test_id_fk FOREIGN KEY ("TestId") REFERENCES public."Test"("TestId") NOT VALID;


-- Completed on 2020-04-16 16:16:28

--
-- PostgreSQL database dump complete
--

