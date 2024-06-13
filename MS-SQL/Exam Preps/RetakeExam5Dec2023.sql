CREATE DATABASE RailwaysDb

--1
CREATE TABLE Passengers (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Trains (
    Id INT PRIMARY KEY IDENTITY,
    HourOfDeparture VARCHAR(5) NOT NULL,
    HourOfArrival VARCHAR(5) NOT NULL,
    DepartureTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
    ArrivalTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations (
    TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
    RailwayStationId INT NOT NULL FOREIGN KEY REFERENCES RailwayStations(Id),
    CONSTRAINT PK_TrainStation PRIMARY KEY(TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords (
    Id INT PRIMARY KEY IDENTITY,
    DateOfMaintenance DATE NOT NULL,
    Details VARCHAR(2000) NOT NULL,
    TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id)
)

CREATE TABLE Tickets (
    Id INT PRIMARY KEY IDENTITY,
    Price DECIMAL(18,2) NOT NULL,
    DateOfDeparture DATE NOT NULL,
    DateOfArrival DATE NOT NULL,
    TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
    PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

--2
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
    ('07:00', '19:00', 1, 3),
    ('08:30', '20:30', 5, 6),
    ('09:00', '21:00', 4, 8),
    ('06:45', '03:55', 27, 7),
    ('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
    (36, 1),
    (36, 4),
    (36, 31),
    (36, 57),
    (36, 7),
    (37, 13),
    (37, 54),
    (37, 60),
    (37, 16),
    (38, 10),
    (38, 50),
    (38, 52),
    (38, 22),
    (39, 68),
    (39, 3),
    (39, 31),
    (39, 19),
    (40, 41),
    (40, 7),
    (40, 52),
    (40, 13)

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
    (90.00, '2023-12-01', '2023-12-01', 36, 1),
    (115.00, '2023-08-02', '2023-08-02', 37, 2),
    (160.00, '2023-08-03', '2023-08-03', 38, 3),
    (255.00, '2023-09-01', '2023-09-02', 39, 21),
    (95.00, '2023-09-02', '2023-09-03', 40, 22)

--3
UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
    DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE
    DATEPART(MONTH, DateOfDeparture) > 10

--4
DELETE FROM TrainsRailwayStations
WHERE TrainId IN
      (SELECT Id FROM Trains WHERE DepartureTownId = 3)

DELETE FROM MaintenanceRecords
WHERE TrainId IN
      (SELECT Id FROM Trains WHERE DepartureTownId = 3)

DELETE FROM Tickets
WHERE TrainId IN
      (SELECT Id FROM Trains WHERE DepartureTownId = 3)

DELETE FROM Trains
WHERE DepartureTownId = 3

--5
SELECT DateOfDeparture, Price AS TicketPrice
FROM Tickets
ORDER BY Price,
         DateOfDeparture DESC

--6
SELECT
    [Name] AS PassengerName,
    Price AS TicketPrice,
    DateOfDeparture,
    TrainID
FROM Tickets AS t
JOIN Passengers AS p on t.PassengerId = p.Id
ORDER BY Price DESC,
         PassengerName

--7
SELECT
    t.[Name] AS Town,
    rs.[Name] AS RailwayStation
FROM RailwayStations AS rs
JOIN Towns AS t ON rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs on rs.Id = trs.RailwayStationId
WHERE
    trs.TrainId IS NULL
ORDER BY Town,
         RailwayStation

--8
SELECT TOP 3
    TrainId, HourOfDeparture, Price AS TicketPrice, [Name] AS Destination
FROM Tickets AS ti
JOIN Trains AS tr ON ti.TrainId = tr.Id
JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
WHERE Price > 50
AND CAST(tr.HourOfDeparture AS TIME) BETWEEN '8:00' AND '8:59'
ORDER BY TicketPrice

--9
SELECT
    tw.[Name] AS TownName, COUNT(p.Name) AS PassengersCount
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Trains AS tr ON t.TrainId = tr.Id
JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
WHERE Price > 76.99
GROUP BY tw.[Name]
ORDER BY tw.[Name]

--10
SELECT
    TrainId, [Name] AS DepartureTown, Details
FROM MaintenanceRecords AS mr
JOIN Trains AS t ON mr.TrainId = t.Id
JOIN Towns AS tw ON t.DepartureTownId = tw.Id
WHERE
    Details LIKE '%inspection%'
ORDER BY TrainId

--11
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
    RETURNS INT
AS
    BEGIN
        DECLARE @result INT

    SELECT
        @result = COUNT(tr.Id)
    FROM Trains AS tr
    JOIN Towns AS t1 ON tr.ArrivalTownId = t1.Id
    JOIN Towns AS t2 ON tr.DepartureTownId = t2.Id
    WHERE t1.[Name] = @name
    OR t2.[Name] = @name

        RETURN @result
        END

CREATE PROCEDURE usp_SearchByTown(@townName VARCHAR(30))
AS
SELECT
    p.[Name] AS PassengerName, DateOfDeparture, HourOfDeparture
FROM Tickets AS t
JOIN Trains AS tr ON t.TrainId = tr.Id
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
WHERE tw.[Name] = @townName
ORDER BY DateOfDeparture DESC, PassengerName