/****** Script for SelectTopNRows command from SSMS  ******/
SELECT c.[CategoryName]
      ,[ProductName]    
      ,[UnitPrice]
      ,[UnitsInStock]
      ,[Discontinued]
  FROM [Neptuno].[dbo].[Products] p inner join [Neptuno].[dbo].[Categories] c on c.CategoryId=p.CategoryID
  Where c.CategoryName IN ('Beverages','Confections','Meat/Poultry')
  ORDER BY c.CategoryName,ProductName