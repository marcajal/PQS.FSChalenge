
CREATE TABLE ORDERS (
    OrderId INT IDENTITY(1,1) NOT NULL,
    Status INT NOT NULL,
    OrderDescription NVARCHAR(255)NOT NULL,
    CreatedOn DATETIME NOT NULL,
    AuthDate DATETIME NULL
	CONSTRAINT PK_ORDER PRIMARY KEY (OrderId)
	CONSTRAINT DF_ORDER_CreatedOn DEFAULT(GETDATE())
);

GO

CREATE TABLE ORDERS_ITEMS (
    OrderItemId INT IDENTITY(1,1) NOT NULL,
    OrderId INT NOT NULL,
    ItemDescription NVARCHAR(255)NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice NUMERIC(32,2) NOT NULL
	CONSTRAINT PK_ORDER_ITEMS PRIMARY KEY NONCLUSTERED (OrderItemId)
	CONSTRAINT FK_ORDER_ITEMS_ORDERS FOREIGN KEY (OrderId) REFERENCES ORDERS(OrderId)
);

GO

CREATE CLUSTERED INDEX IX_ORDER_ITEMS_OrderId
ON ORDERS_ITEMS (OrderId)

GO

CREATE INDEX IX_ORDER_Status
ON ORDERS (Status)

GO
CREATE VIEW vORDERS_INFO AS

 SELECT O.*, 
		SUM(B.UnitPrice) UnitPrice, 
		SUM(B.Quantity) Quantity 
	FROM ORDERS O	
		INNER JOIN (SELECT	OrderId, 
							SUM(ISNULL(UnitPrice,0)) UnitPrice, 
							SUM(ISNULL(Quantity,0)) Quantity 
					FROM ORDERS_ITEMS GROUP by OrderId) B 
		ON O.OrderId=B.OrderId
    GROUP BY O.OrderId, O.Status, O.OrderDescription, O.CreatedOn, O.AuthDate

GO

INSERT INTO ORDERS (Status, OrderDescription, CreatedOn, AuthDate)
VALUES(0,'Orden Descripcion 1','20200828','20200828'),
	  (1,'Orden Descripcion 2','20200829','20200829'),
	  (-1,'Orden Descripcion 3','20200830','20200830')
GO

INSERT INTO ORDERS_ITEMS (OrderId, ItemDescription, Quantity, UnitPrice)
VALUES(1,'Item Descripcion 1',2,60),
	  (1,'Item Descripcion 2',4,50),
	  (2,'Item Descripcion 3',8,40),
	  (2,'Item Descripcion 4',16,30),
	  (3,'Item Descripcion 5',32,20),
	  (3,'Item Descripcion 6',64,10)
