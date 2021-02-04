USE [RepairDB]

INSERT INTO Customers (Auth, Name)
VALUES  (0, 'Tim F' ),
        (0, 'James J' ),
        (0, 'Jeroen H');

INSERT INTO Employees (Name,PayPerHour)
Values  ('Bob J', 1600 ),
        ('James E', 2700 ),
        ('Emma T', 599 ),
        ('Tim W', 4500);

INSERT INTO Statuses (StatusDescription, StatusColour)
VALUES  ('in afwachting', '#FF8888'),
        ('in behandeling', '#8888FF'),
        ('wacht op onderdelen', '#FFFF88'),
        ('klaar', '#88FF88');

INSERT INTO Orders (EmployeeId,CustomerId,StatusId,Description,StartDate,ToDo)
VALUES  (1, 1, 1, 'It won''t turn on.', '2-2-2021 12:33:00', 1);