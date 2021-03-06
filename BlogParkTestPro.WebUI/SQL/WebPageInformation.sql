/*
   2014年9月10日17:26:03
   用户: sa
   服务器: localhost
   数据库: BlogPark
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
USE BlogPark
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.WebPageInformation
	(
	WebPageID int NOT NULL IDENTITY (1, 1),
	WebPageName nvarchar(50) NULL,
	BelongModularID int NULL,
	ISEnable int NULL,
	WebAction nvarchar(50) NULL,
	WebController nvarchar(50) NULL,
	WebAddress nvarchar(300) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'页面ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'WebPageID'
GO
DECLARE @v sql_variant 
SET @v = N'页面名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'WebPageName'
GO
DECLARE @v sql_variant 
SET @v = N'所属模块ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'BelongModularID'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用（0 不用 1 启用）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'ISEnable'
GO
DECLARE @v sql_variant 
SET @v = N'Action名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'WebAction'
GO
DECLARE @v sql_variant 
SET @v = N'Controller名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'WebController'
GO
DECLARE @v sql_variant 
SET @v = N'页面地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPageInformation', N'COLUMN', N'WebAddress'
GO
ALTER TABLE dbo.WebPageInformation ADD CONSTRAINT
	PK_WebPageInformation PRIMARY KEY CLUSTERED 
	(
	WebPageID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.WebPageInformation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
