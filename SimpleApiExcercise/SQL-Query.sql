--Create DB
CREATE DATABASE apiexcercise

--Create all tables
CREATE TABLE Customers (
  customer_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  customer_name VARCHAR(50) NOT NULL  
);

CREATE TABLE Orders (
  order_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  customer_id INT NOT NULL,
  order_date DATE NOT NULL,  
  FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

CREATE TABLE Shipments (
  shipment_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  order_id INT NOT NULL,
  shipment_date DATE NOT NULL,  
  FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);


--Insert dummy data into tables including foreign keys
INSERT INTO Customers (customer_name)
VALUES ('Nafiza Nusrat'),
       ('Khalid Hossain'),
       ('Abu Zaman');

INSERT INTO Orders (customer_id, order_date)
VALUES (1, '2023-04-22'),
       (1, '2023-04-23'),
       (2, '2023-04-21'),
       (3, '2023-04-20');

INSERT INTO Shipments (order_id, shipment_date)
VALUES (1, '2023-04-23'),
       (2, '2023-04-24'),
       (3, '2023-04-22'),
       (4, '2023-04-21');

	   	   