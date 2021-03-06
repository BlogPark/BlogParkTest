/*
   2014年8月22日18:08:15
   用户: sa
   服务器: localhost
   数据库: BlogPark
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
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
CREATE TABLE dbo.LogCategory
	(
	CategoryID int NOT NULL IDENTITY (100, 100),
	CategoryName nvarchar(50) NULL,
	IsAvailable int NULL,
	CreateTime datetime NULL,
	CreateUser int NULL,
	CreateUsername nvarchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'分类ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'CategoryID'
GO
DECLARE @v sql_variant 
SET @v = N'类别名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'CategoryName'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'IsAvailable'
GO
DECLARE @v sql_variant 
SET @v = N'创建时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'CreateTime'
GO
DECLARE @v sql_variant 
SET @v = N'创建人ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'CreateUser'
GO
DECLARE @v sql_variant 
SET @v = N'创建人名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'LogCategory', N'COLUMN', N'CreateUsername'
GO
ALTER TABLE dbo.LogCategory ADD CONSTRAINT
	PK_LogCategory PRIMARY KEY CLUSTERED 
	(
	CategoryID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LogCategory SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
