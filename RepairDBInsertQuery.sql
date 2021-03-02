USE [RepairDB]

INSERT INTO Customers (Auth, Name)
VALUES  (0, 'Tim F' ),
        (0, 'James J' ),
        (0, 'Jeroen H');

INSERT INTO Employees (Name,PayPerHour)
Values  ('Bob J', 16 ),
        ('James E', 27 ),
        ('Emma T', 5.99 ),
        ('Tim W', 45);

INSERT INTO Status (StatusDescription, StatusColour)
VALUES  ('in afwachting', '#FF8888'),
        ('in behandeling', '#8888FF'),
        ('wacht op onderdelen', '#FFFF88'),
        ('klaar', '#88FF88');

INSERT INTO Orders (EmployeeId,CustomerId,StatusId,Description,StartDate,HoursWorked, ToDo)
VALUES  (1, 1, 1, 'It won''t turn on.', '2-2-2021 12:33:00', 1.2, 1);

INSERT INTO Parts (Name, Price)
VALUES  ('fan version 1', 9.99);

INSERT INTO OrderParts(OrderId, PartId, Amount)
VALUES  (1,1,1);