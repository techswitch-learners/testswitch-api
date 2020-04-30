CREATE TABLE public."AdminUsers" (
                                     "Id" BIGSERIAL NOT NULL PRIMARY KEY UNIQUE,
                                     "Email" VARCHAR(256) NOT NULL UNIQUE,
                                     "HashedPassword" VARCHAR(128) NOT NULL,
                                     "PasswordSalt" VARCHAR(24) NOT NULL
);

CREATE TABLE public."AdminSessionID"(
                                        "Id" BIGSERIAL NOT NULL PRIMARY KEY UNIQUE,
                                        "AdminUserID" BIGINT NOT NULL,
                                        "SessionStart" TIMESTAMP NOT NULL,
                                        "SessionEnd" TIMESTAMP NOT NULL
);

ALTER TABLE ONLY public."AdminSessionID"
    ADD CONSTRAINT AdminUserID_fk FOREIGN KEY ("AdminUserID") REFERENCES public."AdminUsers"("Id") NOT VALID;