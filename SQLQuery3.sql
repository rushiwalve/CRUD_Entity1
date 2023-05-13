/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [productId]
      ,[productName]
      ,[categoryId]
      ,[categoryName]
  FROM [MVC].[dbo].[category]