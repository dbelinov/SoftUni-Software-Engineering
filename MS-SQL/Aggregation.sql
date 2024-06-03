--1
SELECT
    COUNT(*) AS [Count]
FROM WizzardDeposits

--2
SELECT TOP 1
    MagicWandSize AS [LongestMagicWand]
FROM WizzardDeposits
ORDER BY MagicWandSize DESC

--3
SELECT
    DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

--4
SELECT TOP 2
    DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--5
SELECT
    DepositGroup, SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

--6
SELECT
    DepositGroup, SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7
SELECT
    DepositGroup, TotalSum
FROM (
    SELECT
        DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
    GROUP BY DepositGroup
     ) AS SubQuery
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

--8
SELECT
    DepositGroup, MagicWandCreator, MIN(DepositCharge)
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--9
SELECT
    AgeGroup, COUNT(*)
FROM (
        SELECT
            [AgeGroup] = (
        CASE
            WHEN Age < 11 THEN '[0-10]'
            WHEN Age < 21 THEN '[11-20]'
            WHEN Age < 31 THEN '[21-30]'
            WHEN Age < 41 THEN '[31-40]'
            WHEN Age < 51 THEN '[41-50]'
            WHEN Age < 61 THEN '[51-60]'
            ELSE '[61+]'
        END
        )
        FROM WizzardDeposits
         ) as SubQuery
GROUP BY AgeGroup

--10
SELECT
    LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

--11
SELECT
    DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC,
         IsDepositExpired

--12
SELECT SUM(Difference) AS [SumDifference]
    FROM (
        SELECT
--         FirstName AS [Host Wizard],
--         DepositAmount AS [Host Wizard Deposit],
--         LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
--         LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
        DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
    FROM WizzardDeposits
    ) AS SubQuery

--SOFTUNI DATABASE
USE SoftUni

--13
SELECT
    DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14
SELECT
    DepartmentID, MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
AND HireDate > '01-01-2000'
GROUP BY DepartmentID

--15
SELECT * INTO RichEmployees
FROM Employees
WHERE Salary > 30000

DELETE
FROM RichEmployees
WHERE ManagerID = 42

UPDATE RichEmployees
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
FROM RichEmployees
GROUP BY DepartmentID

--16
SELECT
    DepartmentID, MaxSalary
FROM (
    SELECT
        DepartmentID, MAX(Salary) AS [MaxSalary]
    FROM Employees
    GROUP BY DepartmentID
     ) AS SubQuery
WHERE MaxSalary NOT BETWEEN 30000 AND 70000

--17
SELECT
    COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--18
SELECT
    DepartmentID, ThirdHighestSalary
FROM (
    SELECT
        DepartmentID,
        MAX(Salary) AS [ThirdHighestSalary],
        DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranking
    FROM Employees
    GROUP BY DepartmentID, Salary
     ) AS SubQuery
WHERE SubQuery.Ranking = 3

--19
WITH DepartmentAverageSalaries AS (
    SELECT
        DepartmentID, AVG(Salary) AS [AverageSalary]
    FROM Employees
    GROUP BY DepartmentID
)

SELECT TOP 10
    FirstName, LastName, e.DepartmentId
FROM Employees AS e
JOIN DepartmentAverageSalaries AS das ON das.DepartmentID = e.DepartmentID
WHERE e.Salary > das.AverageSalary
ORDER BY e.DepartmentID