-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-04-20 04:46:38.52

-- foreign keys
ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Country;

ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Trip;

ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Client;

ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Trip;

-- tables
DROP TABLE trip.Client;

DROP TABLE trip.Client_Trip;

DROP TABLE trip.Country;

DROP TABLE trip.Country_Trip;

DROP TABLE trip.Trip;

DROP SCHEMA Trip;
-- End of file.

