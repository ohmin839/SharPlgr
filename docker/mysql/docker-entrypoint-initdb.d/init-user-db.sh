#!/bin/bash
set -e

mysql -uroot -p"$MYSQL_ROOT_PASSWORD" "$MYSQL_DATABASE" <<-EOSQL
    CREATE TABLE t_raw_word (
        id INT AUTO_INCREMENT,
        word VARCHAR(32) NOT NULL UNIQUE COLLATE utf8mb4_0900_as_cs,
        PRIMARY KEY (id)
    );

    GRANT SELECT, INSERT, UPDATE, DELETE ON $MYSQL_DATABASE.* TO '$MYSQL_USER'@'%';
EOSQL
