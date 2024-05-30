--1
CREATE TABLE Passports (
    [PassportID] INT PRIMARY KEY IDENTITY(101,1),
    [PassportNumber] VARCHAR(32) NOT NULL
)

INSERT INTO Passports(PassportNumber)
VALUES ('N34FG21B'),
       ('K65LO4R7'),
       ('ZE657QP2')

CREATE TABLE Persons (
    [PersonID] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(32) NOT NULL,
    [Salary] DECIMAL(8,2) NOT NULL,
    [PassportID] INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Roberto', 43300, 102),
       ('Tom', 56100, 103),
       ('Yana', 60200, 101)

--2
CREATE TABLE Manufacturers (
    [ManufacturerID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(32) NOT NULL,
    [EstablishedOn] DATETIME2 NOT NULL
)

INSERT INTO Manufacturers([Name], [EstablishedOn])
VALUES ('BMW', '07-03-1916'),
       ('Tesla', '01-01-2003'),
       ('Lada', '01-05-1966')

CREATE TABLE Models(
    [ModelID] INT PRIMARY KEY IDENTITY(101,1),
    [Name] VARCHAR(32) NOT NULL,
    [ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models([Name], [ManufacturerID])
VALUES ('X1', 1),
       ('i6', 1),
       ('Model S', 2),
       ('Model X', 2),
       ('Model 3', 2),
       ('Nova', 3)

--3
CREATE TABLE Students (
    [StudentID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(64) NOT NULL
)

INSERT INTO Students(Name)
VALUES ('Mila'),
       ('Toni'),
       ('Ron')

CREATE TABLE Exams (
    [ExamID] INT PRIMARY KEY IDENTITY(101,1),
    [Name] VARCHAR(64) NOT NULL
)

INSERT INTO Exams(Name)
VALUES ('SpringMVC'),
       ('Neo4j'),
       ('Oracle 11g')

CREATE TABLE StudentsExams (
    [StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
    [ExamID] INT FOREIGN KEY REFERENCES Exams(ExamID),
    CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES (1, 101),
       (1, 102),
       (2, 101),
       (3, 103),
       (2, 102),
       (2, 103)

--4
CREATE TABLE Teachers (
    [TeacherID] INT PRIMARY KEY IDENTITY(101,1),
    [Name] VARCHAR(32) NOT NULL,
    [ManagerID] INT NULL
)

ALTER TABLE Teachers
ADD FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)

INSERT INTO Teachers(Name, ManagerID)
VALUES ('John', NULL),
       ('Maya', 106),
       ('Silvia', 106),
       ('Ted', 105),
       ('Mark', 101),
       ('Greta', 101)

--5
CREATE TABLE ItemTypes(
    [ItemTypeID] INT PRIMARY KEY,
    [Name] VARCHAR(64) NOT NULL
)

CREATE TABLE Items(
    [ItemID] INT PRIMARY KEY,
    [Name] VARCHAR(64) NOT NULL,
    [ItemTypeID] INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
    [CityID] INT PRIMARY KEY,
    [Name] VARCHAR(64) NOT NULL
)

CREATE TABLE Customers(
    [CustomerID] INT PRIMARY KEY,
    [Name] VARCHAR(64) NOT NULL,
    [Birthday] DATETIME2,
    [CityID] INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
    [OrderID] INT PRIMARY KEY,
    [CustomerID] INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
    [OrderID] INT FOREIGN KEY REFERENCES Orders(OrderID),
    [ItemID] INT FOREIGN KEY REFERENCES Items(ItemID),
    CONSTRAINT PK_OrdersItems PRIMARY KEY(OrderID, ItemID)
)

--6
CREATE TABLE Majors(
    [MajorID] INT PRIMARY KEY,
    [Name] VARCHAR(64)
)

CREATE TABLE Subjects(
    [SubjectID] INT PRIMARY KEY,
    [SubjectName] VARCHAR(32)
)

CREATE TABLE Students(
    [StudentID] INT PRIMARY KEY,
    [StudentNumber] INT NOT NULL,
    [StudentName] VARCHAR(64) NOT NULL,
    [MajorID] INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
    [PaymentID] INT PRIMARY KEY,
    [PaymentDate] DATETIME2 NOT NULL,
    [PaymentAmount] DECIMAL(8,2) NOT NULL,
    [StudentID] INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
    [StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
    [SubjectID] INT FOREIGN KEY REFERENCES Subjects(SubjectID),
    CONSTRAINT PK_StudentsSubjects PRIMARY KEY(StudentID, SubjectID)
)

USE Geography
GO

SELECT MountainRange, PeakName, Elevation FROM Peaks
JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC