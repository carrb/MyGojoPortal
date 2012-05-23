-- SQL Server/Instances Services Status
--
-- 

SET NOCOUNT ON

/* ------------------------------------------ Inital Setup -----------------------------------------------------*/
CREATE TABLE #RegResult
(
	ResultValue NVARCHAR(4)
)

CREATE TABLE #ServicesServiceStatus			/*Create temp tables*/
( 
	 RowID INT IDENTITY(1,1)
	,SERVERNAME NVARCHAR(128) 
	,SERVICENAME NVARCHAR(128)
	,ServiceStatus VARCHAR(128)
	,StatusDateTime DATETIME DEFAULT (GETDATE())
	,PhysicalSrverName NVARCHAR(128)
)

DECLARE 
		 @ChkInstanceName NVARCHAR(128)				/*Stores SQL Instance Name*/
		,@ChkSrvName NVARCHAR(128)					/*Stores Server Name*/
		,@TrueSrvName NVARCHAR(128)					/*Stores where code name needed */
		,@SQLSrv NVARCHAR(128)						/*Stores server name*/
		,@PhysicalSrvName NVARCHAR(128)				/*Stores physical name*/
		,@FTS NVARCHAR(128)							/*Stores Full Text Search Service name*/
		,@RS NVARCHAR(128)							/*Stores Reporting Service name*/
		,@SQLAgent NVARCHAR(128)					/*Stores SQL Agent Service name*/
		,@OLAP NVARCHAR(128)						/*Stores Analysis Service name*/ 
		,@REGKEY NVARCHAR(128)						/*Stores Registry Key information*/


SET @PhysicalSrvName = CAST(SERVERPROPERTY('MachineName') AS VARCHAR(128)) 
SET @ChkSrvName = CAST(SERVERPROPERTY('INSTANCENAME') AS VARCHAR(128)) 
SET @ChkInstanceName = @@SERVERNAME

IF @ChkSrvName IS NULL								/*Detect default or named instance*/
	BEGIN 
		SET @TrueSrvName = 'MSQLSERVER'
		SELECT @OLAP = 'MSSQLServerOLAPService' 	/*Setting up proper service name*/
		SELECT @FTS = 'MSFTESQL' 
		SELECT @RS = 'ReportServer' 
		SELECT @SQLAgent = 'SQLSERVERAGENT'
		SELECT @SQLSrv = 'MSSQLSERVER'
	END 
ELSE
	BEGIN
		SET @TrueSrvName =  CAST(SERVERPROPERTY('INSTANCENAME') AS VARCHAR(128)) 
		SET @SQLSrv = '$'+@ChkSrvName
	 	SELECT @OLAP = 'MSOLAP' + @SQLSrv	/*Setting up proper service name*/
		SELECT @FTS = 'MSFTESQL' + @SQLSrv 
		SELECT @RS = 'ReportServer' + @SQLSrv
		SELECT @SQLAgent = 'SQLAgent' + @SQLSrv
		SELECT @SQLSrv = 'MSSQL' + @SQLSrv
	END 


/* ---------------------------------- SQL Server Service Section ----------------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\'+@SQLSrv

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of SQL Sever service*/
	EXEC xp_servicecontrol N'QUERYSTATE',@SQLSrv
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'MS SQL Server Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'MS SQL Server Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* ---------------------------------- SQL Server Agent Service Section -----------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\'+@SQLAgent

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of SQL Agent service*/
	EXEC xp_servicecontrol N'QUERYSTATE',@SQLAgent
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'SQL Server Agent Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'SQL Server Agent Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY	
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END


/* ---------------------------------- SQL Browser Service Section ----------------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\SQLBrowser'

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of SQL Browser Service*/
	EXEC master.dbo.xp_servicecontrol N'QUERYSTATE',N'sqlbrowser'
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'SQL Browser Service - Instance Independent' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'SQL Browser Service - Instance Independent' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* ---------------------------------- Integration Service Section ----------------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\MsDtsServer'

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of Intergration Service*/
	EXEC master.dbo.xp_servicecontrol N'QUERYSTATE',N'MsDtsServer'
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Intergration Service - Instance Independent' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Intergration Service - Instance Independent' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* ---------------------------------- Reporting Service Section ------------------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\'+@RS

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of Reporting service*/
	EXEC master.dbo.xp_servicecontrol N'QUERYSTATE',@RS
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Reporting Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Reporting Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* ---------------------------------- Analysis Service Section -------------------------------------------------*/
IF @ChkSrvName IS NULL								/*Detect default or named instance*/
	BEGIN 
	SET @OLAP = 'MSSQLServerOLAPService'
	END
ELSE	
	BEGIN
	SET @OLAP = 'MSOLAP'+'$'+@ChkSrvName
	SET @REGKEY = 'System\CurrentControlSet\Services\'+@OLAP
END

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of Analysis service*/
	EXEC master.dbo.xp_servicecontrol N'QUERYSTATE',@OLAP
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Analysis Services' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Analysis Services' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* ---------------------------------- Full Text Search Service Section -----------------------------------------*/

SET @REGKEY = 'System\CurrentControlSet\Services\'+@FTS

INSERT #RegResult ( ResultValue ) EXEC master.sys.xp_regread @rootkey='HKEY_LOCAL_MACHINE', @key=@REGKEY

IF (SELECT ResultValue FROM #RegResult) = 1 
BEGIN
	INSERT #ServicesServiceStatus (ServiceStatus)		/*Detecting staus of Full Text Search service*/
	EXEC master.dbo.xp_servicecontrol N'QUERYSTATE',@FTS
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Full Text Search Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END
ELSE 
BEGIN
	INSERT INTO #ServicesServiceStatus (ServiceStatus) VALUES ('NOT INSTALLED')
	UPDATE #ServicesServiceStatus SET SERVICENAME = 'Full Text Search Service' WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET SERVERNAME = @TrueSrvName WHERE RowID = @@IDENTITY
	UPDATE #ServicesServiceStatus SET PhysicalSrverName = @PhysicalSrvName WHERE RowID = @@IDENTITY
	TRUNCATE TABLE #RegResult
END

/* -------------------------------------------------------------------------------------------------------------*/
SELECT   PhysicalSrverName AS 'Physical Server Name'    /*Display finding*/
		,SERVERNAME AS 'SQL Instance Name'
		,SERVICENAME AS 'SQL Server Services'
		,ServiceStatus AS 'Current Service Service Status'
		,StatusDateTime AS 'Date/Time Service Status Checked'
FROM #ServicesServiceStatus

/* -------------------------------------------------------------------------------------------------------------*/
DROP TABLE #ServicesServiceStatus				/*Perform cleanup*/
DROP TABLE #RegResult

