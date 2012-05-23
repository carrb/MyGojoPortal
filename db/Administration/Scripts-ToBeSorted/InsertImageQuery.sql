DECLARE @img AS VARBINARY(MAX)
DECLARE @imgIcon AS VARBINARY(MAX)
DECLARE @imgLarge AS VARBINARY(MAX)

SELECT @img = CAST(bulkcolumn AS VARBINARY(MAX))
FROM OPENROWSET(BULK 'C:\Projects\WebOptimized\NuWaveOven.jpg',
				SINGLE_BLOB) AS x
				
SELECT @imgIcon = CAST(bulkcolumn AS VARBINARY(MAX))
FROM OPENROWSET(BULK 'C:\Projects\WebOptimized\NuWaveOven-Icon.jpg',
				SINGLE_BLOB) AS y
				
SELECT @imgLarge = CAST(bulkcolumn AS VARBINARY(MAX))
FROM OPENROWSET(BULK 'C:\Projects\WebOptimized\NuWaveOven-Large.jpg',
				SINGLE_BLOB) AS z
				
INSERT INTO [dbo].[ProductImage]
(
	[ProductImageGUID],
	[ProductID],
	[VariantID],
	[NormalImage],
	[IconImage],
	[LargeImage],
	[MimeType]
)
VALUES
(
	NEWID(),
	310,
	467,
	@img,
	@imgIcon,
	@imgLarge,
	'image/jpeg'
)
