-- CREATE TABLE sodas
-- (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(55) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     price DECIMAL(10,2) NOT NULL,
--     PRIMARY KEY(id)
-- );
CREATE TABLE users (
    id VARCHAR(225) NOT NULL,
    username VARCHAR(20) NOT NULL,
    email VARCHAR(225) NOT NULL,
    hash VARCHAR(225) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY email (email)
);

CREATE TABLE userburgers (
id int NOT NULL AUTO_INCREMENT,
burgerId int NOT NULL,
userId VARCHAR(225) NOT NULL,
PRIMARY KEY (id),
INDEX (userId),
FOREIGN KEY (userId)
REFERENCES users(id)
ON DELETE CASCADE,

FOREIGN KEY (burgerId)
REFERENCES burgers(id)
ON DELETE CASCADE,
)

-- INSERT INTO burgers (name, description, price) 
-- VALUES ("Double Burger","Two burgers in one", 6.99);

-- SELECT * FROM burgers

-- ALTER TABLE burgers MODIFY COLUMN price DECIMAL(10,2);

-- UPDATE burgers SET 
-- price = 7.99, 
-- name = "The Plain Jane with Cheese",
-- description = "Burger on a bun with cheese"
-- WHERE id = 1;

-- DELETE FROM burgers WHERE id = 1;