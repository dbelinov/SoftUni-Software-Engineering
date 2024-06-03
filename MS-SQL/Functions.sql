--1
SELECT
    FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

--2
SELECT
    FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT
    FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--4
SELECT
    FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT
    Name
FROM Towns
WHERE LEN(Name) IN (5,6)
ORDER BY Name

--6
SELECT
    TownID, Name
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

--7
SELECT
    TownID, Name
FROM Towns
WHERE LEFT(Name, 1) NOT IN ('R', 'B', 'D')
ORDER BY Name

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS (
    SELECT
        FirstName, LastName
    FROM Employees
    WHERE DATEPART(YEAR, HireDate) > 2000
    )

--9
SELECT
    FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10
SELECT
    EmployeeID, FirstName, LastName, Salary,
    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS 'Rank'
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11 !!!
SELECT
    EmployeeID, FirstName, LastName, Salary, Rank
    FROM (
        SELECT EmployeeID, FirstName, LastName, Salary,
        DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS 'Rank'
        FROM Employees
        ) AS SubQuery
WHERE Rank = 2
AND Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Geography
USE Geography

--12
SELECT
    CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13 !!!!
SELECT
    PeakName, RiverName,
    LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName)-1), RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

--Diablo
USE Diablo

--14
SELECT TOP 50
    [Name], FORMAT(Start, 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY Start, [Name]

--15
SELECT
    Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS 'Email Provider'
FROM Users
ORDER BY [Email Provider], Username

--16
SELECT
    Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17
SELECT
    [Name] AS Game,
    [Part of the Day] = CASE
        WHEN DATEPART(HOUR, Start) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
        ELSE 'Evening'
    END,
    [Duration2] = CASE
        WHEN Duration <= 3 THEN 'Extra Short'
        WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
        WHEN Duration > 6 THEN 'Long'
        ELSE 'Extra Long'
    END
FROM Games
ORDER BY Name, Duration2, [Part of the Day]