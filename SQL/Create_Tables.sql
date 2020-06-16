--//Delete Tables
--DROP TABLE Players;
--DROP TABLE Teams;
--DROP TABLE Positions;
--DROP TABLE PlayerTeams;

--//Create Tables
CREATE TABLE Positions
(
	positionID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	positionDescription VARCHAR(10) NOT NULL
);

CREATE TABLE Teams
(
	teamID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	teamName VARCHAR(50) NOT NULL
);

CREATE TABLE Players
(
	playerID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	firstName VARCHAR(50),
	lastName VARCHAR(50),
	positionId INT REFERENCES Positions(positionID),
	nationality VARCHAR(50),
	dateOfBirth DATE
);

CREATE TABLE PlayerTeams
(
	playerID INT PRIMARY KEY REFERENCES Players(playerID),
	teamID INT REFERENCES Teams(teamID)
)
