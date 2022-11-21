
CREATE TABLE positions (
	"id" BIGSERIAL PRIMARY KEY,
	"name" VARCHAR(128) NOT NULL
);

CREATE TABLE subjects (
	"id" BIGSERIAL PRIMARY KEY,
	"name" VARCHAR(128) NOT NULL
);

CREATE TABLE locations (
	"id" BIGSERIAL PRIMARY KEY,
	country VARCHAR(32) NOT NULL,
	"state" VARCHAR(32) NOT NULL,
	city VARCHAR(64) NOT NULL,
	street VARCHAR(64) NOT NULL,
	"number" VARCHAR(8) NOT NULL,
	apartmentNumber INT,
	"floor" SMALLINT
);

CREATE TABLE employees (
	"id" BIGSERIAL PRIMARY KEY,
	firstName VARCHAR(32) NOT NULL,
	middleName VARCHAR(32),
	lastName VARCHAR(32) NOT NULL,
	phoneNumber VARCHAR(13) NOT NULL UNIQUE,
	positionID BIGINT NOT NULL REFERENCES positions("id"),
	subjectID BIGINT NOT NULL REFERENCES subjects("id"),
	homeAddressID BIGINT NOT NULL REFERENCES locations("id"),
	workplaceAddressID BIGINT NOT NULL REFERENCES locations("id"),
	hourlyRate DECIMAL(5, 2) NOT NULL,
	totalHours INT NOT NULL DEFAULT 0
);


INSERT INTO positions (
	"name"
) VALUES 
	('Jr. Lecturer'),
	('Sr. Lecturer'),
	('Lecturer Assistant')
;

INSERT INTO subjects (
	"name"
) VALUES 
	('Applied Math'),
	('C Fundamentals'),
	('Math analysis'),
	('Operating Systems');

INSERT INTO locations (
	country, "state", city, street, "number", apartmentNumber, "floor"
) VALUES 
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Universitetska', '28', NULL, 2),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 1, 1),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 2, 1),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 3, 1),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 4, 1),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 5, 2),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 6, 2),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 7, 2),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 8, 2),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 9, 3),
	('Ukraine', 'Chernivtsi region', 'Chernivtsi', 'Golovna', '234A', 10, 3)
;

INSERT INTO employees (
	firstName, middleName, lastName, phoneNumber, positionID, SubjectID, HomeAddressID, WorkplaceAddressID, hourlyRate, totalHours
) VALUES
	('Leylin', NULL, 'Farlier', '+380501234567', 2, 1, 1, 1, 30, 800),
	('David', NULL, 'Erickson', '+380501234568', 1, 2, 2, 1, 15, 670),
	('Elon', NULL, 'Musk', '+380501234569', 3, 4, 3, 1, 5, 0),
	('Henry', NULL, 'Ford', '+380501234570', 3, 3, 4, 1, 15, 700),
	('Mark', NULl, 'Livin', '+380501234571', 2, 2, 5, 1, 7.5, 120),
	('Orban', NULl, 'Krueg', '+380501234572', 1, 2, 6, 1, 17.5, 620),
	('Matsuto', NULl, 'Miho', '+380501234573', 2, 2, 7, 1, 12.5, 820),
	('Garcia', NULl, 'Uno', '+380501234574', 2, 2, 8, 1, 32.75, 1900),
	('Leon', NULl, 'Messi', '+380501234575', 1, 2, 9, 1, 13, 1350),
	('Anna', NULl, 'Wimbledon', '+380501234576', 2, 3, 10, 1, 13, 1350)
;

DROP TABLE positions, subjects, locations, employees;
