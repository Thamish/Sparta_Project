--//Delete Tables

--DROP TABLE Teams;
--DROP TABLE Positions;
--DROP TABLE PlayerTeams;
--DROP TABLE Players;

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
	positionID INT REFERENCES Positions(positionID),
	nationality VARCHAR(50),
	dateOfBirth DATE
);

CREATE TABLE PlayerTeams
(
	playerTeamsID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	playerID INT REFERENCES Players(playerID),
	teamID INT REFERENCES Teams(teamID)
);

CREATE TABLE TeamStatistics
(
	playerStatisticsID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	teamID INT REFERENCES Teams(teamID),
	matchesPlayed INT,
	wins INT,
	losses INT,
	draw INT,
	goalsScored INT,
	goalsConceded INT
);
