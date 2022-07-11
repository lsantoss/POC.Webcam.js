USE [master] 

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'POC.Webcam.js')
BEGIN
	CREATE DATABASE [POC.Webcam.js]
END