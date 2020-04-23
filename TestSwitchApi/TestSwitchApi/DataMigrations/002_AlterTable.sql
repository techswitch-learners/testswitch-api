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
    