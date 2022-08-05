--====================================================================================================================================
--============================================== CREATE TABLE [dbo].[Person] =========================================================
--====================================================================================================================================
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Person') 
BEGIN
	CREATE TABLE [dbo].[Person](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Birth] [datetime] NOT NULL,
		[Email] [nvarchar](50) NOT NULL,
		[Password] [nvarchar](100) NOT NULL,
		[Image] [nvarchar](max) NOT NULL,
	 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

--====================================================================================================================================
--============================================== CREATE TABLE [dbo].[ELMAH_Error] ====================================================
--====================================================================================================================================
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name='ELMAH_Error')
BEGIN
	CREATE TABLE [dbo].[ELMAH_Error]
	(
		[ErrorId]     UNIQUEIDENTIFIER NOT NULL,
		[Application] NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[Host]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[Type]        NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[Source]      NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[Message]     NVARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[User]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
		[StatusCode]  INT NOT NULL,
		[TimeUtc]     DATETIME NOT NULL,
		[Sequence]    INT IDENTITY (1, 1) NOT NULL,
		[AllXml]      NVARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
	) 
	ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	   
	ALTER TABLE [dbo].[ELMAH_Error] WITH NOCHECK ADD 
		CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED ([ErrorId]) ON [PRIMARY] 
	
	ALTER TABLE [dbo].[ELMAH_Error] ADD 
		CONSTRAINT [DF_ELMAH_Error_ErrorId] DEFAULT (NEWID()) FOR [ErrorId]
	
	CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error] 
	(
		[Application]   ASC,
		[TimeUtc]       DESC,
		[Sequence]      DESC
	) 
	ON [PRIMARY]
END

GO

--====================================================================================================================================
--=========================================== CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml] =============================================
--====================================================================================================================================
CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
	@Application NVARCHAR(60),
	@ErrorId UNIQUEIDENTIFIER
)
AS SET NOCOUNT ON

SELECT [AllXml]
FROM [ELMAH_Error]
WHERE [ErrorId] = @ErrorId AND [Application] = @Application

GO

--====================================================================================================================================
--=========================================== CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml] ============================================
--====================================================================================================================================
CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
	@Application NVARCHAR(60),
	@PageIndex INT = 0,
	@PageSize INT = 15,
	@TotalCount INT OUTPUT
)
AS SET NOCOUNT ON

DECLARE @FirstTimeUTC DATETIME
DECLARE @FirstSequence INT
DECLARE @StartRow INT
DECLARE @StartRowIndex INT

SELECT @TotalCount = COUNT(1) 
FROM [ELMAH_Error]
WHERE [Application] = @Application

SET @StartRowIndex = @PageIndex * @PageSize + 1

IF @StartRowIndex <= @TotalCount
	BEGIN
		SET ROWCOUNT @StartRowIndex

		SELECT  
			@FirstTimeUTC = [TimeUtc],
			@FirstSequence = [Sequence]
		FROM 
			[ELMAH_Error]
		WHERE   
			[Application] = @Application
		ORDER BY 
			[TimeUtc] DESC, 
			[Sequence] DESC
	END
ELSE
	BEGIN
		SET @PageSize = 0
	END

SET ROWCOUNT @PageSize

SELECT 
	errorId     = [ErrorId], 
	application = [Application],
	host        = [Host], 
	type        = [Type],
	source      = [Source],
	message     = [Message],
	[user]      = [User],
	statusCode  = [StatusCode], 
	time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
FROM [ELMAH_Error] error
WHERE [Application] = @Application
AND [TimeUtc] <= @FirstTimeUTC
AND [Sequence] <= @FirstSequence
ORDER BY [TimeUtc] DESC, [Sequence] DESC
FOR XML AUTO

GO

--====================================================================================================================================
--============================================= CREATE PROCEDURE [dbo].[ELMAH_LogError] ==============================================
--====================================================================================================================================
CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NVARCHAR(MAX),
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS SET NOCOUNT ON

INSERT INTO [ELMAH_Error]
(
    [ErrorId],
    [Application],
    [Host],
    [Type],
    [Source],
    [Message],
    [User],
    [AllXml],
    [StatusCode],
    [TimeUtc]
)
VALUES
(
    @ErrorId,
    @Application,
    @Host,
    @Type,
    @Source,
    @Message,
    @User,
    @AllXml,
    @StatusCode,
    @TimeUtc
)