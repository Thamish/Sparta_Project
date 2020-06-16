--//Delete Tables
--DROP TABLE Players;
--DROP TABLE Clubs;
--DROP TABLE Positions;

--//Create Tables
CREATE TABLE Positions
(
	positionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	positionDescription VARCHAR(10) NOT NULL
);

CREATE TABLE Clubs
(
	clubID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	clubname VARCHAR(50) NOT NULL
);

CREATE TABLE Players
(
	playerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	firstName VARCHAR(50),
	lastName VARCHAR(50),
	positionId INT REFERENCES Positions(positionID),
	nationality VARCHAR(50),
	clubId INT REFERENCES Clubs(ClubID),
	dateOfBirth DATE
);
