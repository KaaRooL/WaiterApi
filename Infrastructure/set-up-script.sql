CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'waiter') THEN
        CREATE SCHEMA waiter;
    END IF;
END $EF$;

CREATE TABLE waiter.tables (
    table_id uuid NOT NULL,
    name text NOT NULL,
    is_available boolean NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_tables" PRIMARY KEY (table_id)
);

CREATE TABLE waiter.waiters (
    waiter_id uuid NOT NULL,
    name text NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_waiters" PRIMARY KEY (waiter_id)
);

CREATE TABLE waiter.orders (
    order_id uuid NOT NULL,
    "Tip" numeric NOT NULL,
    order_status text NOT NULL,
    waiter_id uuid NOT NULL,
    table_id uuid NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    aggregate_version integer NOT NULL,
    CONSTRAINT "PK_orders" PRIMARY KEY (order_id),
    CONSTRAINT "FK_orders_tables_table_id" FOREIGN KEY (table_id) REFERENCES waiter.tables (table_id) ON DELETE CASCADE,
    CONSTRAINT "FK_orders_waiters_waiter_id" FOREIGN KEY (waiter_id) REFERENCES waiter.waiters (waiter_id) ON DELETE CASCADE
);

CREATE TABLE waiter.amounts (
    amount_id uuid NOT NULL,
    value numeric NOT NULL,
    payer text NOT NULL,
    order_id uuid NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_amounts" PRIMARY KEY (amount_id),
    CONSTRAINT "FK_amounts_orders_order_id" FOREIGN KEY (order_id) REFERENCES waiter.orders (order_id) ON DELETE CASCADE
);

CREATE TABLE waiter.items (
    item_id uuid NOT NULL,
    name text NOT NULL,
    price numeric NOT NULL,
    order_id uuid NOT NULL,
    created_at_utc timestamp with time zone NOT NULL,
    created_by text NOT NULL,
    modified_at_utc timestamp with time zone NULL,
    modified_by text NULL,
    CONSTRAINT "PK_items" PRIMARY KEY (item_id),
    CONSTRAINT "FK_items_orders_order_id" FOREIGN KEY (order_id) REFERENCES waiter.orders (order_id) ON DELETE CASCADE
);

CREATE INDEX "IX_amounts_order_id" ON waiter.amounts (order_id);

CREATE INDEX "IX_items_order_id" ON waiter.items (order_id);

CREATE INDEX "IX_orders_table_id" ON waiter.orders (table_id);

CREATE INDEX "IX_orders_waiter_id" ON waiter.orders (waiter_id);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230929192039_AddDomain', '7.0.9');

COMMIT;

