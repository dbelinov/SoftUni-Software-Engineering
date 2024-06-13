CREATE DATABASE Boardgames
USE Boardgames

--1
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL UNIQUE,
    AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
    Website NVARCHAR(40) NULL,
    Phone NVARCHAR(20) NULL
)

CREATE TABLE PlayersRanges (
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
    PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames (
    CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
    BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id),
    CONSTRAINT CreatorGame PRIMARY KEY (CreatorId, BoardgameId)
)

--2
INSERT INTO Boardgames (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1, 15, 7),
    ('Paris', 2016, 9.78, 7, 1, 5),
    ('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
    ('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
    ('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers (Name, AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--3
UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] = [Name] + 'V2'
WHERE YearPublished > 2019

--4
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
      (SELECT Id FROM Boardgames WHERE PublisherId IN
        (SELECT Id FROM Publishers WHERE  AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')))

DELETE FROM Boardgames
WHERE PublisherId IN
      (SELECT Id FROM Publishers WHERE  AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%'))

DELETE FROM Publishers
WHERE AddressId IN (SELECT Id FROM Addresses WHERE Town LIKE 'L%')

DELETE FROM Addresses
WHERE Town LIKE 'L%'

--5
SELECT
    [Name], Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

--6
SELECT
    bg.Id, bg.[Name], YearPublished, c.[Name] AS CategoryName
FROM Boardgames AS bg
JOIN Categories AS c ON bg.CategoryId = c.Id
WHERE c.[Name] = 'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY YearPublished DESC

--7
SELECT
    Id, CONCAT(FirstName, ' ', LastName) AS CreatorName, Email
FROM Creators
WHERE Id NOT IN (SELECT CreatorId FROM CreatorsBoardgames)
ORDER BY Id

--8
SELECT TOP 5
    bg.[Name], Rating, c.[Name] AS CategoryName
FROM Boardgames AS bg
JOIN Categories AS c ON bg.CategoryId = c.Id
JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
WHERE (Rating > 7
AND bg.[Name] LIKE '%a%')
OR (Rating > 7.5 AND PlayersMin = 2 AND PlayersMax = 5)
ORDER BY bg.[Name], Rating DESC

--9
SELECT
    CONCAT(FirstName, ' ', LastName) AS FullName, Email, MAX(Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE Email LIKE '%.com'
GROUP BY FirstName, LastName, Email
ORDER BY FullName

--10
SELECT
    LastName, CEILING(AVG(Rating)) AS AverageRating, p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p on b.PublisherId = p.Id
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY LastName, p.[Name]
ORDER BY AVG(Rating) DESC

--11
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
    BEGIN
        DECLARE @count INT

        SELECT
            @count = COUNT(BoardgameId)
        FROM CreatorsBoardgames
        WHERE CreatorId = (SELECT Id FROM Creators WHERE FirstName = @name)

        RETURN @count
    END

--12
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
    SELECT
        bg.[Name], YearPublished, Rating,
        c.[Name] AS CategoryName,
        p.[Name] AS PublisherName,
        CAST(PlayersMin AS VARCHAR) + ' people' AS MinPlayers, CAST(PlayersMax AS VARCHAR) + ' people' AS MaxPlayers
    FROM Boardgames AS bg
    JOIN Categories AS c ON bg.CategoryId = c.Id
    JOIN PlayersRanges AS pr ON bg.PlayersRangeId = pr.Id
    JOIN Publishers AS p ON bg.PublisherId = p.Id
    WHERE c.[Name] = @category
    ORDER BY PublisherName, YearPublished DESC
END