CREATE DATABASE TestDB2
GO

USE [TestDB2]
Go

CREATE TABLE [dbo].[Students](
	[StudentId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
)