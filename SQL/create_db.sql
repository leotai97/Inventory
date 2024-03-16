
-- Inventory database 

CREATE DATABASE IF NOT EXISTS inventory_v1;

USE inventory_v1;

CREATE TABLE IF NOT EXISTS picture_location
(
 pic_loc_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
 parent_id  INT UNSIGNED,
 loc_name   VARCHAR(256),
 loc_desc   VARCHAR(1024),
 loc_file   VARCHAR(256),
 loc_x      INT,
 loc_y      INT,
 loc_w      INT,
 loc_h      INT,
 rct_color  INT,
 rct_width  TINYINT UNSIGNED,
 loc_order  INT,
 PRIMARY KEY (pic_loc_id)
);

CREATE INDEX IF NOT EXISTS picture_location_parent_ndx ON picture_location(parent_id);

--  ****

CREATE TABLE IF NOT EXISTS name_location
(
 name_loc_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
 loc_name        VARCHAR(256),
 loc_desc        VARCHAR(1024),
 PRIMARY KEY (name_loc_id)
);

--  ****

CREATE TABLE IF NOT EXISTS inventory_category
(
 inv_cat_id      INT UNSIGNED NOT NULL AUTO_INCREMENT,
 cat_name        VARCHAR(256),
 cat_desc        VARCHAR(1024),
 notes           VARCHAR(32000),
 PRIMARY KEY (inv_cat_id)
);

--  ****

CREATE TABLE IF NOT EXISTS category_property
(
 cat_prop_id   INT UNSIGNED NOT NULL AUTO_INCREMENT,
 inv_cat_id    INT UNSIGNED NOT NULL,
 property_name VARCHAR(256),
 primary_prop  TINYINT,
 PRIMARY KEY (cat_prop_id)
);

CREATE INDEX IF NOT EXISTS category_property_ndx ON category_property(inv_cat_id);

--  ****

CREATE TABLE IF NOT EXISTS inventory_item
(
 inv_item_id        INT UNSIGNED NOT NULL AUTO_INCREMENT,
 inv_cat_id         INT UNSIGNED NOT NULL,
 pic_loc_id         INT UNSIGNED,
 name_loc_id        INT UNSIGNED,
 inv_count          INT,
 est_cost           FLOAT,
 item_name          VARCHAR(512),
 item_desc          VARCHAR(1024),
 notes              VARCHAR(32000),
 item_created       DATETIME NOT NULL,
 item_changed       DATETIME,
 item_added         DATETIME,
 item_removed       DATETIME,
 PRIMARY KEY(inv_item_id)
);

CREATE INDEX IF NOT EXISTS inventory_item_ndx1 ON inventory_item (inv_cat_id);
CREATE INDEX IF NOT EXISTS inventory_item_ndx1 ON inventory_item (pic_loc_id);
CREATE INDEX IF NOT EXISTS inventory_item_ndx1 ON inventory_item (name_loc_id);

--  ****

CREATE TABLE IF NOT EXISTS inventory_item_prop_value
(
 inv_item_id     INT UNSIGNED NOT NULL,
 inv_cat_id      INT UNSIGNED NOT NULL,
 cat_prop_id     INT UNSIGNED NOT NULL,
 prop_value      FLOAT
);

CREATE INDEX IF NOT EXISTS inventory_item_prop_value_ndx ON inventory_item_prop_value (inv_item_id);

--  ****

CREATE TABLE IF NOT EXISTS purchase_history
(
 purch_hist_id   INT UNSIGNED NOT NULL AUTO_INCREMENT,
 inv_item_id     INT UNSIGNED NOT NULL,
 hist_source     VARCHAR(1024),
 hist_link       VARCHAR(1024),
 purchase_date   DATETIME NOT NULL,
 units_price     FLOAT,
 units_amount    INT,
 PRIMARY KEY(purch_hist_id)
);

CREATE INDEX IF NOT EXISTS purchase_history_ndx ON purchase_history(inv_item_id);

--  ****

CREATE TABLE IF NOT EXISTS inventory_item_file
(
 item_file_id  INT UNSIGNED NOT NULL AUTO_INCREMENT,
 inv_item_id   INT UNSIGNED NOT NULL,
 file_type     TINYINT NOT NULL, 
 file_path     VARCHAR(1024),
 file_name     VARCHAR(512),
 file_desc     VARCHAR(1024),
 file_ext      VARCHAR(6),
 PRIMARY KEY(item_file_id)
);

CREATE INDEX IF NOT EXISTS inventory_item_file_ndx ON inventory_item_file(inv_item_id);

--  ****

CREATE TABLE IF NOT EXISTS user_settings
(
 user_name     VARCHAR(36),
 app_name      VARCHAR(128),
 setting_name  VARCHAR(256),
 setting_value VARCHAR(256),
 PRIMARY KEY (user_name, app_name, setting_name)
);
-- Grants, password clear text, be sure to change it


CREATE USER IF NOT EXISTS inv_user IDENTIFIED BY 'Abc123*';


GRANT select,insert,update,delete on picture_location to inv_user;

GRANT select,insert,update,delete on name_location to inv_user;

GRANT select,insert,update,delete on inventory_category to inv_user;

GRANT select,insert,update,delete on category_property to inv_user;

GRANT select,insert,update,delete on inventory_item to inv_user;

GRANT select,insert,update,delete on inventory_item_prop_value to inv_user;

GRANT select,insert,update,delete on purchase_history to inv_user;

GRANT select,insert,update,delete on inventory_item to inv_user;

GRANT select,insert,update,delete on inventory_item_file to inv_user;

GRANT select,insert,update,delete on user_settings to inv_user;