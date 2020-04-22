 ALTER TABLE public."Tests" ADD COLUMN "Title" character varying (128);

ALTER TABLE public."Tests" ADD COLUMN  "Question" text;

ALTER TABLE public."Tests" ADD COLUMN "Input" character varying (128);

ALTER TABLE public."Tests" ADD COLUMN "ExpectedOutput" character varying (128);

ALTER TABLE public."Tests" DROP COLUMN "ModelAnswer";

ALTER TABLE public."Tests" ADD COLUMN "ModelAnswer" text;
 
ALTER TABLE IF EXISTS "Results"
RENAME TO "CandidateTests";

ALTER TABLE public."CandidateTests" ADD COLUMN "TestAnswer" character varying(1000)

ALTER TABLE ONLY public."CandidateTests" ADD COLUMN "Id" bigint NOT NULL;

CREATE SEQUENCE public.candidate_test_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER SEQUENCE public.candidate_test_id_seq OWNED BY public."CandidateTests"."Id";

ALTER TABLE ONLY public."CandidateTests" ALTER COLUMN "Id" SET DEFAULT nextval('public.candidate_test_id_seq'::regclass);

ALTER TABLE ONLY public."CandidateTests"
    ADD CONSTRAINT candidatetest_id_pk PRIMARY KEY ("Id");
    
ALTER TABLE ONLY public."CandidateTests" ALTER COLUMN "CandidateId" DROP IDENTITY;

ALTER TABLE ONLY public."CandidateTests" ADD COLUMN "StartTime" timestamp;

ALTER TABLE ONLY public."CandidateTests" ADD COLUMN "EndTime" timestamp;
    