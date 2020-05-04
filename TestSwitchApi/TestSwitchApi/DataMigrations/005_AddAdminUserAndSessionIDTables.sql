CREATE TABLE public."AdminUsers" (
                                     "Id" SERIAL PRIMARY KEY,
                                     "Email" VARCHAR(256) NOT NULL UNIQUE,
                                     "HashedPassword" VARCHAR(128) NOT NULL,
                                     "PasswordSalt" BYTEA NOT NULL
);

CREATE TABLE public."AdminUserSessions"(
                                        "Id" VARCHAR(128) NOT NULL PRIMARY KEY,
                                        "AdminUserID" INT NOT NULL,
                                        "SessionStart" TIMESTAMP NOT NULL,
                                        "SessionEnd" TIMESTAMP NOT NULL
);

ALTER TABLE ONLY public."AdminUserSessions"
    ADD CONSTRAINT AdminUserID_fk FOREIGN KEY ("AdminUserID") REFERENCES public."AdminUsers"("Id") NOT VALID;