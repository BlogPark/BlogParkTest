/*
   2014年9月10日21:58:48
   用户: sa
   服务器: .
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
CREATE TABLE dbo.WebMenuOrder
	(
	MenuID int NOT NULL IDENTITY (1, 1),
	MenuName nvarchar(50) NULL,
	ISEnable int NULL,
	PositionID int NULL,
	WebPageID int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'菜单名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'MenuName'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'ISEnable'
GO
DECLARE @v sql_variant 
SET @v = N'所属页面'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'WebPageID'
GO
ALTER TABLE dbo.WebMenuOrder ADD CONSTRAINT
	PK_WebMenuOrder PRIMARY KEY CLUSTERED 
	(
	MenuID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.WebMenuOrder SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
