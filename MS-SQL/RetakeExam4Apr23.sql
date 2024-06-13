CREATE DATABASE Accounting
USE Accounting

--1
CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(20) NOT NULL,
    StreetNumber INT NULL,
    PostCode INT NOT NULL,
    City VARCHAR(25) NOT NULL,
    CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Vendors (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(25) NOT NULL,
    NumberVAT NVARCHAR(15) NOT NULL,
    AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(35) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(Id)
)

CREATE TABLE Invoices (
    Id INT PRIMARY KEY IDENTITY,
    Number INT NOT NULL UNIQUE,
    IssueDate DATETIME2 NOT NULL,
    DueDate DATETIME2 NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Currency VARCHAR(5) NOT NULL,
    ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id)
)

CREATE TABLE ProductsClients (
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
    ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
    CONSTRAINT PK_ProductClient PRIMARY KEY(ProductId, ClientId)
)

--2
INSERT INTO Products (Name, Price, CategoryId, VendorId)
VALUES
    ('SCANIA Oil Filter XD01', 78.69, 1, 1),
    ('MAN Air Filter XD01', 97.38, 1, 5),
    ('DAF Light Bulb 05FG87', 55.00, 2, 13),
    ('ADR Shoes 47-47.5', 49.85, 3, 5),
    ('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
    (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
    (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
    (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

--3
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE DATEPART(MONTH, IssueDate) = 11
AND DATEPART(YEAR, IssueDate) = 2022

UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'

--4
DELETE FROM ProductsClients
WHERE ClientId IN
      (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%')

DELETE FROM Invoices
WHERE ClientId IN
      (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%')

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%'

--5
SELECT
    Number, Currency
FROM Invoices
ORDER BY Amount DESC, DueDate

--6
SELECT
    p.Id, p.[Name], Price, c.[Name] AS CategoryName
FROM Products AS p
JOIN Categories AS c on p.CategoryId = c.Id
WHERE CategoryId = 3 OR CategoryId = 5
ORDER BY Price DESC

--7
SELECT
    cl.Id, cl.[Name] AS Client,
    CONCAT(StreetName, ' ', StreetNumber, ', ', City, ', ', PostCode, ', ', c.[Name]) AS Address
FROM Clients AS cl
JOIN Addresses AS a on cl.AddressId = a.Id
JOIN Countries AS c on a.CountryId = c.Id
WHERE cl.Id NOT IN
      (SELECT ClientId FROM ProductsClients)
ORDER BY Client

--8
SELECT TOP 7
    Number, Amount, [Name] AS Client
FROM Invoices AS i
JOIN Clients AS c on c.Id = i.ClientId
WHERE (IssueDate < '2023-01-01'
AND Currency = 'EUR')
OR (Amount > 500 AND NumberVAT LIKE 'DE%')
ORDER BY Number, Amount DESC

--9
SELECT
    Client, Price, [VAT Number]
FROM
    (
        SELECT
            c.[Name] AS Client, MAX(Price) AS Price, NumberVAT AS 'VAT Number'
        FROM Clients AS c
        JOIN ProductsClients AS pc on c.Id = pc.ClientId
        JOIN Products AS p on pc.ProductId = p.Id
        GROUP BY c.[Name], NumberVAT
    ) AS subq
WHERE Client NOT LIKE '%KG'
ORDER BY Price DESC

--10
SELECT
    c.[Name] AS Client, FLOOR(AVG(Price)) AS 'Average Price'
FROM Clients AS c
LEFT JOIN ProductsClients AS pc on c.Id = pc.ClientId
JOIN Products AS p ON pc.ProductId = p.Id
JOIN Vendors AS v on v.Id = p.VendorId
WHERE v.NumberVAT LIKE '%FR%'
AND c.Id IN (SELECT ClientId FROM ProductsClients)
GROUP BY c.[Name]
ORDER BY CAST(ROUND(AVG(Price), 0) AS INT), Client DESC

--11
CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
    DECLARE @count INT

    SELECT
        @count = COUNT(ClientId)
    FROM ProductsClients AS pc
    JOIN Products AS p on pc.ProductId = p.Id
    WHERE p.[Name] = @name

    RETURN @count
END

--12
CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(10))
AS
SELECT
    v.[Name] AS Vendor,
    NumberVAT AS VAT,
    CONCAT(StreetName, ' ', StreetNumber) AS 'Street Info',
    CONCAT(City, ' ', PostCode) AS 'City Info'
FROM Vendors AS v
JOIN Addresses AS a on a.Id = v.AddressId
JOIN Countries AS c on a.CountryId = c.Id
WHERE c.[Name] = @country
ORDER BY Vendor, City