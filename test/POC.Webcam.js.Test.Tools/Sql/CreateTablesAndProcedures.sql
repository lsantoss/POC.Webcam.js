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