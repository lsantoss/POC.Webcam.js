USE [master] 

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'FormWebcamJs')
BEGIN
	CREATE DATABASE FormWebcamJs
END