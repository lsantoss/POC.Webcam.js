--====================================================================================================================================
--============================================= DROP TABLE [dbo].[Person] ============================================================
--====================================================================================================================================
USE [POC.Webcam.js.Test]
IF OBJECT_ID('dbo.Person', 'U') IS NOT NULL 
DROP TABLE dbo.Person

--====================================================================================================================================
--============================================= DROP TABLE [dbo].[ELMAH_Error] =======================================================
--====================================================================================================================================
IF OBJECT_ID('dbo.ELMAH_Error', 'U') IS NOT NULL 
DROP TABLE dbo.ELMAH_Error

--====================================================================================================================================
--============================================= DROP PROCEDURE [dbo].[ELMAH_GetErrorXml] =============================================
--====================================================================================================================================
IF OBJECT_ID('ELMAH_GetErrorXml', 'P') IS NOT NULL
DROP PROCEDURE [dbo].[ELMAH_GetErrorXml]

--====================================================================================================================================
--============================================= DROP PROCEDURE [dbo].[ELMAH_GetErrorsXml] ============================================
--====================================================================================================================================
IF OBJECT_ID('ELMAH_GetErrorsXml', 'P') IS NOT NULL
DROP PROCEDURE [dbo].[ELMAH_GetErrorsXml]

--====================================================================================================================================
--============================================= DROP PROCEDURE [dbo].[ELMAH_LogError] ================================================
--====================================================================================================================================
IF OBJECT_ID('ELMAH_LogError', 'P') IS NOT NULL
DROP PROCEDURE [dbo].[ELMAH_LogError]