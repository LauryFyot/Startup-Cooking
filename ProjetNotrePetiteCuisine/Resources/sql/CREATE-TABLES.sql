-- #########################
-- DROP TABLE IF EXISTS
-- #########################
DROP TABLE IF EXISTS DASHBOARD;
DROP TABLE IF EXISTS HAS_PRODUCT;
DROP TABLE IF EXISTS PRODUCT;
DROP TABLE IF EXISTS SUPPLIER;
DROP TABLE IF EXISTS IS_IN_CART_OF;
DROP TABLE IF EXISTS IS_IN_ORDERTYPE;
DROP TABLE IF EXISTS RECIPE;
DROP TABLE IF EXISTS ORDERTYPE;
DROP TABLE IF EXISTS ADMIN;
DROP TABLE IF EXISTS RECIPE_CREATOR;
DROP TABLE IF EXISTS CLIENT;


-- #########################
-- CREATE TABLE
-- #########################
CREATE TABLE CLIENT
  (client_id                          VARCHAR(36)                 PRIMARY KEY         NOT NULL          DEFAULT (UUID()),
  username                            VARCHAR(15)                 UNIQUE              NOT NULL,
  password                            VARCHAR(255)                                    NOT NULL,
  first_name                          VARCHAR(20)                                     NOT NULL,
  last_name                           VARCHAR(20)                                     NOT NULL,
  phone_number                        VARCHAR(12)                                     NOT NULL,
  email                               VARCHAR(255)                                    NOT NULL,
  can_be_recipe_creator               BOOLEAN                                         NOT NULL          DEFAULT 1);

CREATE TABLE ADMIN
  (admin_id                           VARCHAR(36)                 PRIMARY KEY         NOT NULL);

CREATE TABLE RECIPE_CREATOR
  (recipe_creator_id                  VARCHAR(36)                 PRIMARY KEY         NOT NULL,
  cook_balance                        INTEGER UNSIGNED                                NOT NULL          DEFAULT 0);

CREATE TABLE ORDERTYPE
  (order_id                           VARCHAR(36)                 PRIMARY KEY         NOT NULL          DEFAULT (UUID()),
  the_date                            DATETIME                                        NOT NULL          DEFAULT CURRENT_TIMESTAMP,
  address                             VARCHAR(255)                                    NOT NULL,
  city                                VARCHAR(100)                                    NOT NULL,
  postal_code                         VARCHAR(15)                                     NOT NULL,
  client_id                           VARCHAR(36)                                     NOT NULL);

CREATE TABLE RECIPE
  (recipe_id                          VARCHAR(36)                 PRIMARY KEY         NOT NULL          DEFAULT (UUID()),
  name                                VARCHAR(100)                UNIQUE              NOT NULL,
  description                         VARCHAR(500)                                    NOT NULL,
  type                                VARCHAR(20)                                     NOT NULL,
  price                               MEDIUMINT UNSIGNED                              NOT NULL          CHECK( price >= 10 and price <= 40 ),
  difficulty_level                    TINYINT UNSIGNED                                NOT NULL,
  for_nb_person                       TINYINT UNSIGNED                                NOT NULL,         
  nb_step                             TINYINT UNSIGNED                                NOT NULL,         
  nb_solded                           INTEGER UNSIGNED                                NOT NULL          DEFAULT 0,
  recipe_creator_fees                 MEDIUMINT UNSIGNED                              NOT NULL          DEFAULT 2,
  creation_date                       DATETIME                                        NOT NULL          DEFAULT CURRENT_TIMESTAMP,
  modification_date                   DATETIME                                        NOT NULL          DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  is_validated                        BOOLEAN                                         NOT NULL          DEFAULT 0, -- False by DEFAULT
  recipe_creator_id                   VARCHAR(36)                                     NOT NULL);

CREATE TABLE IS_IN_ORDERTYPE
  (order_id                           VARCHAR(36)                                     NOT NULL,
  recipe_id                           VARCHAR(36)                                     NOT NULL,
  quantity                            MEDIUMINT UNSIGNED                              NOT NULL);

CREATE TABLE IS_IN_CART_OF
  (client_id                          VARCHAR(36)                                     NOT NULL,
  recipe_id                           VARCHAR(36)                                     NOT NULL,
  quantity                            TINYINT UNSIGNED                                NOT NULL);

CREATE TABLE SUPPLIER
  (supplier_id                        VARCHAR(36)                 PRIMARY KEY         NOT NULL          DEFAULT (UUID()),
  supplier_name                       VARCHAR(15)                 UNIQUE              NOT NULL,
  phone_number                        VARCHAR(12)                                     NOT NULL);

CREATE TABLE PRODUCT
  (product_id                         VARCHAR(36)                 PRIMARY KEY         NOT NULL          DEFAULT (UUID()),
  product_name                        VARCHAR(50)                 UNIQUE              NOT NULL,
  category                            VARCHAR(20)                                     NOT NULL,
  unit                                VARCHAR(15)                                     NOT NULL,
  product_quantity                    INTEGER UNSIGNED                                NOT NULL          DEFAULT 200,
  min_quantity                        INTEGER UNSIGNED                                NOT NULL          DEFAULT 100    CHECK( min_quantity > 0),
  max_quantity                        INTEGER UNSIGNED                                NOT NULL          DEFAULT 300    CHECK( max_quantity > 0),
  supplier_id                         VARCHAR(36)                                     NOT NULL);

CREATE TABLE HAS_PRODUCT
  (product_id                         VARCHAR(36)                                     NOT NULL,
  recipe_id                           VARCHAR(36)                                     NOT NULL,
  quantity                            MEDIUMINT UNSIGNED                              NOT NULL);

CREATE TABLE DASHBOARD -- Only one row in the Table DASHBOARD
  (dashboard_id                       TINYINT                     PRIMARY KEY         NOT NULL          DEFAULT 0      CHECK( dashboard_id = 0 ),
  best_recipe_creator_id_of_week      VARCHAR(36)                 UNIQUE,
  first_recipe_id                     VARCHAR(36)                 UNIQUE,
  second_recipe_id                    VARCHAR(36)                 UNIQUE,
  third_recipe_id                     VARCHAR(36)                 UNIQUE,
  fourth_recipe_id                    VARCHAR(36)                 UNIQUE,
  fifth_recipe_id                     VARCHAR(36)                 UNIQUE,
  best_recipe_creator_id              VARCHAR(36)                 UNIQUE,
  first_recipe_id_of_best_rc          VARCHAR(36)                 UNIQUE,
  second_recipe_id_of_best_rc         VARCHAR(36)                 UNIQUE,
  third_recipe_id_of_best_rc          VARCHAR(36)                 UNIQUE,
  fourth_recipe_id_of_best_rc         VARCHAR(36)                 UNIQUE,
  fifth_recipe_id_of_best_rc          VARCHAR(36)                 UNIQUE);

-- #########################
-- CONSTRAINT ALTER TABLE
-- #########################
-- ADMIN
ALTER TABLE ADMIN
  ADD CONSTRAINT fk_admin_id FOREIGN KEY (admin_id) REFERENCES CLIENT(client_id) ON DELETE CASCADE ON UPDATE CASCADE;

-- RECIPE_CREATOR
ALTER TABLE RECIPE_CREATOR
  ADD CONSTRAINT fk_recipe_creator_id FOREIGN KEY (recipe_creator_id) REFERENCES CLIENT(client_id) ON DELETE CASCADE ON UPDATE CASCADE;

-- ORDER
ALTER TABLE ORDERTYPE
  ADD CONSTRAINT fk_order_client_id FOREIGN KEY (client_id) REFERENCES CLIENT(client_id) ON DELETE CASCADE ON UPDATE CASCADE;

-- IS_IN_ORDER
ALTER TABLE IS_IN_ORDERTYPE
  ADD CONSTRAINT fk_is_in_order_order_id FOREIGN KEY (order_id) REFERENCES ORDERTYPE(order_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE IS_IN_ORDERTYPE
  ADD CONSTRAINT fk_is_in_order_recipe_id FOREIGN KEY (recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE IS_IN_ORDERTYPE
  ADD CONSTRAINT pk_is_in_order PRIMARY KEY (order_id, recipe_id);

-- IS_IN_CART_OF
ALTER TABLE IS_IN_CART_OF
  ADD CONSTRAINT fk_is_in_cart_of_client_id FOREIGN KEY (client_id) REFERENCES CLIENT(client_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE IS_IN_CART_OF
  ADD CONSTRAINT fk_is_in_cart_of_recipe_id FOREIGN KEY (recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE IS_IN_CART_OF
  ADD CONSTRAINT pk_is_in_cart_of PRIMARY KEY (client_id, recipe_id);

-- RECIPE
ALTER TABLE RECIPE
  ADD CONSTRAINT fk_recipe_recipe_creator_id FOREIGN KEY (recipe_creator_id) REFERENCES RECIPE_CREATOR(recipe_creator_id) ON DELETE CASCADE ON UPDATE CASCADE;

-- PRODUCT
ALTER TABLE PRODUCT
  ADD CONSTRAINT fk_product_supplier_id FOREIGN KEY (supplier_id) REFERENCES SUPPLIER(supplier_id) ON DELETE CASCADE ON UPDATE CASCADE;

-- HAS_PRODUCT
ALTER TABLE HAS_PRODUCT
  ADD CONSTRAINT fk_has_product_product_id FOREIGN KEY (product_id) REFERENCES PRODUCT(product_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HAS_PRODUCT
  ADD CONSTRAINT fk_has_product_recipe_id FOREIGN KEY (recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HAS_PRODUCT
  ADD CONSTRAINT pk_has_product PRIMARY KEY (product_id, recipe_id);

-- DASHBOARD
ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_best_recipe_creator_id_of_week FOREIGN KEY (best_recipe_creator_id_of_week) REFERENCES RECIPE_CREATOR(recipe_creator_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_first_recipe_id FOREIGN KEY (first_recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_second_recipe_id FOREIGN KEY (second_recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_third_recipe_id FOREIGN KEY (third_recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_fourth_recipe_id FOREIGN KEY (fourth_recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_fifth_recipe_id FOREIGN KEY (fifth_recipe_id) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_best_recipe_creator_id FOREIGN KEY (best_recipe_creator_id) REFERENCES RECIPE_CREATOR(recipe_creator_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_first_recipe_id_of_best_rc FOREIGN KEY (first_recipe_id_of_best_rc) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_second_recipe_id_of_best_rc FOREIGN KEY (first_recipe_id_of_best_rc) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_third_recipe_id_of_best_rc FOREIGN KEY (first_recipe_id_of_best_rc) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_fourth_recipe_id_of_best_rc FOREIGN KEY (first_recipe_id_of_best_rc) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

ALTER TABLE DASHBOARD
  ADD CONSTRAINT fk_fifth_recipe_id_of_best_rc FOREIGN KEY (first_recipe_id_of_best_rc) REFERENCES RECIPE(recipe_id) ON DELETE SET NULL ON UPDATE CASCADE;

-- #########################
-- CREATE the UNIQUE DASHBOARD
-- #########################
INSERT INTO DASHBOARD(dashboard_id) VALUES(DEFAULT) ON DUPLICATE KEY UPDATE dashboard_id = dashboard_id;
