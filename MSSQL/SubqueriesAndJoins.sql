--1
USE SoftUni
GO

SELECT TOP(5)
    EmployeeID, JobTitle, a.AddressID, AddressText
FROM Employees AS e
JOIN Addresses AS a
    ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--2
SELECT TOP(50)
    FirstName, LastName, [Name] AS 'Town', AddressText
FROM Employees AS e
JOIN Addresses AS a
    ON e.AddressID = a.AddressID
JOIN Towns AS t
    ON a.TownID = t.TownID
ORDER BY FirstName,
         LastName

--3
SELECT
    EmployeeID, FirstName, LastName, [Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
WHERE [Name] = 'Sales'
ORDER BY EmployeeID

--4
SELECT TOP(5)
    EmployeeID, FirstName, Salary, [Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID

--5
SELECT TOP(3)
    EmployeeID, FirstName
FROM Employees
WHERE
    EmployeeID NOT IN (SELECT DISTINCT EmployeeID FROM EmployeesProjects)
ORDER BY EmployeeID

--6
SELECT
    FirstName, LastName, HireDate, [Name] AS 'DeptName'
FROM Employees AS e
JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
AND [Name] = 'Sales' OR [Name] = 'Finance'
ORDER BY HireDate

--7
SELECT TOP(5)
    e.EmployeeID, FirstName, [Name] AS 'ProjectName'
FROM Employees AS e
JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
    ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID IN (SELECT EmployeeID FROM EmployeesProjects)
AND StartDate > '2002-08-13'
AND EndDate IS NULL
ORDER BY EmployeeID

--8 !!!!
SELECT
    e.EmployeeID, FirstName,
    [ProjectName] =
        CASE
WHEN DATEPART(YEAR, StartDate) > 2004
    THEN NULL
ELSE [Name]
        END
FROM Employees AS e
JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
    ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--9 !!
SELECT
    e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName AS 'ManagerName'
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE
    e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--10
SELECT TOP(50)
    emp.EmployeeID, CONCAT_WS(' ', emp.FirstName, emp.LastName), CONCAT_WS(' ', mng.FirstName, mng.LastName), [Name] AS 'DepartmentName'
FROM Employees AS emp
JOIN Employees AS mng ON emp.ManagerID = mng.EmployeeID
JOIN Departments AS d ON emp.DepartmentID = d.DepartmentID
ORDER BY EmployeeID

--11
SELECT TOP(1)
    AVG(Salary) MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary

--12
USE Geography
GO

SELECT
    c.CountryCode, MountainRange, PeakName, Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE c.CountryCode = 'BG'
AND Elevation > 2835
ORDER BY Elevation DESC

--13
SELECT
    c.CountryCode, COUNT(MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode

--14
SELECT TOP(5)
    CountryName, RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE ContinentCode = 'AF'
ORDER BY CountryName

--15 !!!!!!!!!!!!
SELECT [ContinentCode]
	  ,[CurrencyCode]
	  ,[CurrencyUsage]
FROM
	(
			SELECT *,
				DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY CurrencyUsage DESC)
			AS [CurrencyRank]
			FROM
		 (
		     SELECT
		    	 [ContinentCode]
		    	 ,[CurrencyCode]
		    	 ,COUNT(*) AS CurrencyUsage
		    FROM Countries
		    GROUP BY [ContinentCode], [CurrencyCode]
		    HAVING COUNT(*) > 1
		)
			AS [CurrencyUsageSubquery]
	)
	AS [CurrencyRankingSubquery]
	WHERE [CurrencyRank] = 1

--16
SELECT COUNT(*) AS 'Count'
FROM Countries
WHERE CountryCode NOT IN
      (SELECT DISTINCT CountryCode FROM MountainsCountries)

--17
SELECT TOP(5)
    CountryName, MAX(Elevation) AS 'HighestPeakElevation', MAX(Length) AS 'LongestRiverLength'
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC,
         LongestRiverLength DESC,
         CountryName