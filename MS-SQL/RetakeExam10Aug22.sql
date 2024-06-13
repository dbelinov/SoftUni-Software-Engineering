CREATE DATABASE NationalTouristSitesOfBulgaria
USE NationalTouristSitesOfBulgaria

--1
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Locations (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    Municipality VARCHAR(50) NULL,
    Province VARCHAR(50) NULL
)

CREATE TABLE Sites (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id),
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    Establishment VARCHAR(15) NULL
)

CREATE TABLE Tourists (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    Age INT NOT NULL
                      CHECK (Age BETWEEN 0 AND 120),
    PhoneNumber VARCHAR(20) NOT NULL,
    Nationality VARCHAR(30) NOT NULL,
    Reward VARCHAR(20) NULL
)

CREATE TABLE SitesTourists (
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
    SiteId INT NOT NULL FOREIGN KEY REFERENCES Sites(Id),
    CONSTRAINT TouristsSites PRIMARY KEY (TouristId, SiteId)
)

CREATE TABLE BonusPrizes (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes (
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
    BonusPrizeId INT NOT NULL FOREIGN KEY REFERENCES BonusPrizes(Id),
    CONSTRAINT TouristBonus PRIMARY KEY (TouristId, BonusPrizeId)
)

--2
INSERT INTO Tourists (Name, Age, PhoneNumber, Nationality, Reward)
VALUES
    ('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
    ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
    ('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
    ('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
    ('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites (Name, LocationId, CategoryId, Establishment)
VALUES
    ('Ustra fortress', 90, 7, 'X'),
    ('Karlanovo Pyramids', 65, 7, NULL),
    ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
    ('Sinite Kamani Natural Park', 17, 1, NULL),
    ('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--3
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--4
DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

--5
SELECT
    [Name], Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

--6
SELECT
    s.[Name] AS Site, l.[Name] AS Location, Establishment, c.[Name] AS Category
FROM Sites AS s
JOIN Categories AS c ON s.CategoryId = c.Id
JOIN Locations AS l ON s.LocationId = l.Id
ORDER BY Category DESC, Location, Site

--7
SELECT
    Province, Municipality, l.[Name] AS Location, COUNT(s.Id) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY Province, Municipality, l.[Name]
ORDER BY CountOfSites DESC, Location

--8
SELECT
    s.[Name] AS Site, l.[Name] AS Location, Municipality, Province, Establishment
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.Name NOT LIKE 'B%'
AND l.Name NOT LIKE 'M%'
AND l.Name NOT LIKE 'D%'
AND (Establishment LIKE '%BC%')
ORDER BY Site

--9
SELECT
    t.[Name], Age, PhoneNumber, Nationality, (
        CASE
            WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
            ELSE bp.[Name]
        END
    ) AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes tbp ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes bp ON tbp.BonusPrizeId = bp.Id
ORDER BY t.[Name]

--10
SELECT
    RIGHT(t.[Name], LEN(t.[Name]) - CHARINDEX(' ', t.[Name])) AS LastName, Nationality, Age, PhoneNumber
FROM Tourists AS t
JOIN SitesTourists AS st ON t.Id = st.TouristId
JOIN Sites AS s ON st.SiteId = s.Id
JOIN Categories AS c on s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
GROUP BY t.[Name], t.[Name], t.[Name], Nationality, Age, PhoneNumber
ORDER BY LastName

--11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @count INT

    SELECT
        @count = COUNT(TouristId)
    FROM SitesTourists AS st
    JOIN Sites AS s on st.SiteId = s.Id
    WHERE s.[Name] = @Site

    RETURN @count
END

--12
CREATE PROCEDURE usp_AnnualRewardLottery
    @TouristName NVARCHAR(100)
AS
BEGIN
    -- Declare a variable to store the count of sites visited
    DECLARE @SitesVisited INT;

    -- Get the count of sites visited by the tourist
    SELECT @SitesVisited = COUNT(TouristId)
    FROM SitesTourists AS st
    JOIN Tourists AS t on st.TouristId = t.Id

    WHERE t.[Name] = @TouristName;

    -- Update the reward based on the count of sites visited
    IF @SitesVisited >= 100
    BEGIN
        UPDATE Tourists
        SET Reward = 'Gold badge'
        WHERE Name = @TouristName;
    END
    ELSE IF @SitesVisited >= 50
    BEGIN
        UPDATE Tourists
        SET Reward = 'Silver badge'
        WHERE Name = @TouristName;
    END
    ELSE IF @SitesVisited >= 25
    BEGIN
        UPDATE Tourists
        SET Reward = 'Bronze badge'
        WHERE Name = @TouristName;
    END
    ELSE
    BEGIN
        UPDATE Tourists
        SET Reward = NULL
        WHERE Name = @TouristName;
    END

    -- Select the tourist name and their reward
    SELECT Name, Reward
    FROM Tourists
    WHERE Name = @TouristName;
END;
