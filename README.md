# DapperInAsyncWay
 
 # Get the NuGet Package
 https://www.nuget.org/packages/Dapper/
 Install this package via visual studio
 
 # Pattern Used
 Used Repository pattern
 Dependency injuction
 For connection establishment System.Data.SqlClient
 
 # SQL Table Structure
 
 USE [DapperTest]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 17-02-2020 2.53.53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](10) NULL,
	[LastName] [nchar](10) NULL,
	[DateOfBirth] [datetime] NULL
) ON [PRIMARY]
GO

# Insert data into table
insert into Employee (FirstName, LastName, DateOfBirth) values ('Pooja', 'Padamwar',xx-xx-xxxx);

 
