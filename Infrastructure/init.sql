CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'sp') THEN
        CREATE SCHEMA sp;
    END IF;
END $EF$;

CREATE TABLE sp.categories (
    category_id uuid NOT NULL,
    user_id text NOT NULL,
    name text NOT NULL,
    exercise_type text NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    aggregate_version integer NOT NULL,
    CONSTRAINT "PK_categories" PRIMARY KEY (category_id)
);

CREATE TABLE sp.users (
    user_id text NOT NULL,
    name text NOT NULL,
    email text NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_users" PRIMARY KEY (user_id)
);

CREATE TABLE sp.exercises (
    exercise_id uuid NOT NULL,
    category_id uuid NOT NULL,
    name text NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_exercises" PRIMARY KEY (exercise_id),
    CONSTRAINT "FK_exercises_categories_category_id" FOREIGN KEY (category_id) REFERENCES sp.categories (category_id) ON DELETE CASCADE
);

CREATE INDEX "IX_exercises_category_id" ON sp.exercises (category_id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230826171519_InitialMigration', '7.0.9');

COMMIT;

