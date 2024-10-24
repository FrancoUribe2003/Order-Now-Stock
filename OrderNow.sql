Create table Product
(
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Name NVARCHAR(255) NOT NULL,       
    Description NVARCHAR(MAX),         
    Price DECIMAL(18, 2) NOT NULL,     
    Stock INT NOT NULL                 
);

SELECT * FROM Product

INSERT INTO Product (Name, Description, Price, Stock)
VALUES ('Hamburguesa', 'Hamburguesa cl�sica con queso y tomate', 500.00, 100);

INSERT INTO Product (Name, Description, Price, Stock)
VALUES ('Milanesa', 'Milanesa de carne empanada y frita', 600.00, 50);

INSERT INTO Product (Name, Description, Price, Stock)
VALUES ('Empanadas', 'Empanadas de carne, pollo o jam�n y queso', 120.00, 200);

INSERT INTO Product (Name, Description, Price, Stock)
VALUES ('Pizza', 'Pizza grande con salsa de tomate, queso y or�gano', 800.00, 75);

INSERT INTO Product (Name, Description, Price, Stock)
VALUES ('Ensalada','Ensalada de tomate y lechuga',1200,0);

