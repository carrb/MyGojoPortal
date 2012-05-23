--Create and add a FILEGROUP that CONTAINS the FILESTREAM
ALTER DATABASE ResourcePartnersDevelopment
ADD FILEGROUP FileStreamGroupResourcePartnersDevelopment
CONTAINS FILESTREAM
GO

ALTER DATABASE ResourcePartnersDevelopment
ADD FILE
(
	NAME = 'ProductImages',
	FILENAME = 'H:\SqlFileStreamData\ProductImages.ndf'
)
TO FILEGROUP FileStreamGroupResourcePartnersDevelopment
GO

	