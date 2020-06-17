--//Insert data into tables
INSERT INTO Positions VALUES
('GoalKeeper'),
('Defender'),
('Midfielder'),
('Forward');

INSERT INTO Teams VALUES
('Arsenal'),
('Chelsea'),
('Liverpool'),
('Manchester City'),
('Manchester United');

INSERT INTO Players VALUES
('Bernd','Leno',1,'Germany','1992/03/04'),
('Héctor','Bellerin',2,'Spain','1995/03/19'),
('Shkodran','Mustafi',2,'Germany','1992/04/17'),
('David','Luiz',2,'Brazil','1987/04/22'),
('Bukayo','Saka',2,'England','2001/09/05'),
('Mesut','Özil',3,'Germany','1988/10/15'),
('Lucas','Torreira',3,'Uruguay','1996/02/11'),
('Nicolas','Pépé',3,'Cote D''lvoire','1995/05/29'),
('Granit','Xhaka',3,'Switzerland','1992/09/27'),
('Gabriel','Martinelli',3,'Brazil','2001/06/18'),
('Alexandre','Lacazette',4,'France','1991/05/28'),
('Willy','Caballero',1,'Argentina','1995/05/29'),
('Kurt','Zouma',2,'France','1994/10/27'),
('Andreas','Christensen',2,'Denmark','1996/04/10'),
('Reece','James',2,'England','1999/12/08'),
('César','Azpilicueta',2,'Spain','1989/08/28'),
('Jorginho','',3,'Italy','1991/12/20'),
('N''Golo','Kanté',3,'France','1991/03/29'),
('Mateo','Kovacic',3,'Croatia','1994/05/06'),
('Willian','',4,'Brazil','1988/08/09'),
('Pedro','',4,'Spain','1987/07/28'),
('Olivier','Giroud',4,'France','1986/09/30');

INSERT INTO PlayerTeams VALUES
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1),
(9,1),
(10,1),
(11,2),
(12,2),
(13,2),
(14,2),
(15,2),
(16,2),
(17,2),
(18,2),
(19,2),
(20,2),
(21,2),
(22,2);

INSERT INTO TeamStatistics VALUES
(1,1066,574,219,253,1885,1049),
(2,1067,572,232,259,1821,1041),
(3,1068,556,248,247,1840,1067),
(4,876,409,268,196,1442,1006),
(5,1068,660,174,226,2033,959);