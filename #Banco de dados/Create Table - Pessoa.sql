USE [FormWebcamJs]

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='Pessoa') 
BEGIN
	CREATE TABLE [dbo].[Pessoa](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,
		[Nome] [nvarchar](50) NOT NULL,
		[DataNascimento] [datetime] NOT NULL,
		[Email] [nvarchar](50) NOT NULL,
		[Senha] [nvarchar](100) NOT NULL,
		[ImagemBase64String] [nvarchar](max) NOT NULL,
	 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END