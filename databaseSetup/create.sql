-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-20 04:46:38.52

CREATE SCHEMA trip;
GO

-- tables
-- Table: Client
CREATE TABLE trip.Client (
    IdClient int  NOT NULL IDENTITY,
    FirstName nvarchar(120)  NOT NULL,
    LastName nvarchar(120)  NOT NULL,
    Email nvarchar(120)  NOT NULL,
    Telephone nvarchar(120)  NOT NULL,
    Pesel nvarchar(120)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (IdClient)
);

-- Table: Client_Trip
CREATE TABLE trip.Client_Trip (
    IdClient int  NOT NULL,
    IdTrip int  NOT NULL,
    RegisteredAt datetime  NOT NULL,
    PaymentDate datetime  NULL,
    CONSTRAINT Client_Trip_pk PRIMARY KEY  (IdClient,IdTrip)
);

-- Table: Country
CREATE TABLE trip.Country (
    IdCountry int  NOT NULL IDENTITY,
    Name nvarchar(120)  NOT NULL,
    CONSTRAINT Country_pk PRIMARY KEY  (IdCountry)
);

-- Table: Country_Trip
CREATE TABLE trip.Country_Trip (
    IdCountry int  NOT NULL,
    IdTrip int  NOT NULL,
    CONSTRAINT Country_Trip_pk PRIMARY KEY  (IdCountry,IdTrip)
);

-- Table: Trip
CREATE TABLE trip.Trip (
    IdTrip int  NOT NULL IDENTITY,
    Name nvarchar(120)  NOT NULL,
    Description nvarchar(220)  NOT NULL,
    DateFrom datetime  NOT NULL,
    DateTo datetime  NOT NULL,
    MaxPeople int  NOT NULL,
    CONSTRAINT Trip_pk PRIMARY KEY  (IdTrip)
);

-- foreign keys
-- Reference: Country_Trip_Country (table: Country_Trip)
ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Country
    FOREIGN KEY (IdCountry)
    REFERENCES trip.Country (IdCountry);

-- Reference: Country_Trip_Trip (table: Country_Trip)
ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);

-- Reference: Table_5_Client (table: Client_Trip)
ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Client
    FOREIGN KEY (IdClient)
    REFERENCES trip.Client (IdClient);

-- Reference: Table_5_Trip (table: Client_Trip)
ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);

--Country
INSERT INTO trip.Country (Name)
VALUES ('France');

INSERT INTO trip.Country (Name)
VALUES ('Spain');

INSERT INTO trip.Country (Name)
VALUES ('Italy');

--Trip
INSERT INTO trip.Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('Paris Getaway', 'Spend a weekend in the City of Love', '2022-05-01', '2022-05-03', 10);

INSERT INTO trip.Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('Barcelona Adventure', 'Experience the vibrant culture of Barcelona', '2022-06-01', '2022-06-07', 20);

INSERT INTO trip.Trip (Name, Description, DateFrom, DateTo, MaxPeople)
VALUES ('Italian Escapade', 'Discover the beauty of Italy', '2022-07-01', '2022-07-10', 15);

--Client
INSERT INTO trip.Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES ('John', 'Doe', 'johndoe@example.com', '123-456-7890', '12345678901');

INSERT INTO trip.Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES ('Jane', 'Smith', 'janesmith@example.com', '987-654-3210', '98765432109');

INSERT INTO trip.Client (FirstName, LastName, Email, Telephone, Pesel)
VALUES ('Mark', 'Johnson', 'markjohnson@example.com', '555-555-5555', '55555555555');

--Client_Trip
INSERT INTO trip.Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (1, 2, '2022-05-01', '2022-04-30');

INSERT INTO trip.Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (2, 3, '2022-06-01', null);

INSERT INTO trip.Client_Trip (IdClient, IdTrip, RegisteredAt, PaymentDate)
VALUES (3, 1, '2022-07-01', '2022-06-30');

--Country_Trip
INSERT INTO trip.Country_Trip (IdCountry, IdTrip)
VALUES (1, 1);

INSERT INTO trip.Country_Trip (IdCountry, IdTrip)
VALUES (2, 2);

INSERT INTO trip.Country_Trip (IdCountry, IdTrip)
VALUES (3, 3);

