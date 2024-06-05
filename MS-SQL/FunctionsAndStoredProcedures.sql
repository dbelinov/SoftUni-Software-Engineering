--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
    SELECT
       FirstName, LastName
    FROM Employees
    WHERE Salary > 35000
END

--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
AS
BEGIN
    SELECT
        FirstName, LastName
    FROM Employees
    WHERE Salary >= @salary
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3
CREATE PROCEDURE usp_GetTownsStartingWith @start VARCHAR(MAX)
AS
BEGIN
    SELECT
        [Name]
    FROM Towns
    WHERE Name LIKE CONCAT(@start, '%')
END

EXEC usp_GetTownsStartingWith 'b'

--4
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
BEGIN
    SELECT
        FirstName, LastName
    FROM Employees AS e
    JOIN Addresses AS a ON e.AddressID = a.AddressID
    JOIN Towns AS t ON a.TownID = t.TownID
    WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @salaryLevel VARCHAR(10)

    IF(@salary < 30000)
        SET @salaryLevel = 'Low'
    ELSE IF(@salary BETWEEN 30000 AND 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'

    RETURN @salaryLevel
END

SELECT
    Salary, dbo.ufn_GetSalaryLevel(Salary) AS 'Salary Level'
FROM Employees

--6
CREATE PROCEDURE usp_EmployeesBySalaryLevel @levelOfSalary VARCHAR(10)
AS
BEGIN
    SELECT
        FirstName, LastName
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'

--7 !!
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(32), @word VARCHAR(32))
RETURNS BIT
AS
BEGIN
     DECLARE @WordLength INT = LEN(@word)
     DECLARE @Iterator INT = 1

     WHILE(@Iterator <= @WordLength)
         BEGIN
             IF(CHARINDEX(SUBSTRING(@word, @Iterator, 1), @setOfLetters) = 0)
                  RETURN 0
                SET @Iterator += 1
          END
          RETURN 1
END

--9
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
    SELECT
        CONCAT_WS(' ', FirstName, LastName)
    FROM AccountHolders
END

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @amount MONEY
AS
BEGIN
    SELECT
        FirstName, LastName
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON ah.Id = a.AccountHolderId
    GROUP BY FirstName, LastName
    HAVING SUM(a.Balance) > @amount
    ORDER BY FirstName, LastName
END

--11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(10,4), @yearlyInterest FLOAT, @years INT)
RETURNS DECIMAL(10,4)
AS
BEGIN
    RETURN @sum * (POWER((1 + @yearlyInterest), @years))
END

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
    DECLARE @term INT = 5
    SELECT
        a.Id AS [Account Id],
        FirstName, LastName,
        Balance AS [Current Balance],
        dbo.ufn_CalculateFutureValue(Balance, @interestRate, @term)
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON ah.Id = a.AccountHolderId
    WHERE a.ID = @accountId