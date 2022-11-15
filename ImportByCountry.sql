/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
	  [Country]
      ,SUM([UnitPrice]*[Quantity]*(1-[Discount]))As 'Import'
  FROM [Neptuno].[dbo].[Order Details] od 
  inner join [Neptuno].[dbo].[Orders]o on o.OrderID= od.OrderID
  Inner join [Neptuno].[dbo].[Customers] c on c.CustomerID= o.CustomerID
  GROUP BY Country
  ORDER BY Country ASC