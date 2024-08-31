create database Task2SQL;

CREATE TABLE Task2SQL.dbo.Products(
id INT PRIMARY KEY IDENTITY, 
name NVARCHAR(255) NOT NULL);

CREATE TABLE Task2SQL.dbo.Category(
id INT PRIMARY KEY IDENTITY,
name NVARCHAR(255) NOT NULL);

CREATE TABLE Task2SQL.dbo.ProductCategory(
productId INT NOT NULL,
categoryId INT NOT NULL,
FOREIGN KEY(productId) REFERENCES Products(id) ON DELETE CASCADE,
FOREIGN KEY(categoryId) REFERENCES Category(id) ON DELETE CASCADE);

CREATE UNIQUE INDEX product_category ON Task2SQL.dbo.ProductCategory(productId, categoryId);

--ID начинается с 4х у обоих таблиц, не стал убирать каретку обратно
INSERT INTO Task2SQL.dbo.Products VALUES(N'Борщ'), (N'Цезарь'), (N'Летний'), (N'Молоко');
INSERT INTO Task2SQL.dbo.Category VALUES(N'Супы'), (N'Салаты'), (N'Каши');

select * from Task2SQL.dbo.Products p;
select * from Task2SQL.dbo.Category c;

INSERT INTO Task2SQL.dbo.ProductCategory VALUES(4, 4), (5, 5), (6, 5);

SELECT p.name AS "Название продукта", c.name AS "Название категории" FROM Task2SQL.dbo.Products AS p
LEFT JOIN Task2SQL.dbo.ProductCategory AS pc ON p.id = pc.productId
LEFT JOIN Task2SQL.dbo.Category AS c ON c.id = pc.categoryId;
