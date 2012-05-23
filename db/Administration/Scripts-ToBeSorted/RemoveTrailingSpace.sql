/****** Script for SelectTopNRows command from SSMS  ******/
UPDATE [ResourcePartnersLive].[dbo].[Customer]
 SET FirstName = REPLACE(FirstName, CHAR(32), '')
 WHERE FirstName LIKE '% '