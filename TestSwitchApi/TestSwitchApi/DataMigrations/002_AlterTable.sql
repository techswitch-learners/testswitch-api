ALTER TABLE public."Tests"
  ADD COLUMN "Title" character varying (128),
  ADD COLUMN  "Question" text,
  ADD COLUMN "Input" character varying (128),
  ADD COLUMN "ExpectedOutput" character varying (128);

ALTER TABLE public."Tests" DROP COLUMN "ModelAnswer";

ALTER TABLE public."Tests" ADD COLUMN "ModelAnswer" text;
 
ALTER TABLE IF EXISTS "Results"
RENAME TO "CandidateTests";

ALTER TABLE public."CandidateTests" ADD COLUMN "TestAnswer" text;

ALTER TABLE public."CandidateTests"
    ALTER COLUMN "TestId" SET NOT NULL;
ALTER TABLE public."CandidateTests"
    ADD PRIMARY KEY ("CandidateId", "TestId");
    
ALTER TABLE ONLY public."CandidateTests" ALTER COLUMN "CandidateId" DROP IDENTITY;

ALTER TABLE ONLY public."CandidateTests" ADD COLUMN "StartTime" timestamp;

ALTER TABLE ONLY public."CandidateTests" ADD COLUMN "EndTime" timestamp;
    