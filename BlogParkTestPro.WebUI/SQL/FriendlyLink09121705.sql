/*
   2014年9月12日17:05:39
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
CREATE TABLE dbo.FriendlyLink
	(
	ID int NOT NULL IDENTITY (1, 1),
	LinkText nvarchar(50) NULL,
	LinkAddress nvarchar(500) NULL,
	LinkImg nvarchar(50) NULL,
	ClickCount int NULL,
	ISEnable int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'链接文本'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'FriendlyLink', N'COLUMN', N'LinkText'
GO
DECLARE @v sql_variant 
SET @v = N'链接地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'FriendlyLink', N'COLUMN', N'LinkAddress'
GO
DECLARE @v sql_variant 
SET @v = N'链接图片地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'FriendlyLink', N'COLUMN', N'LinkImg'
GO
DECLARE @v sql_variant 
SET @v = N'点击次数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'FriendlyLink', N'COLUMN', N'ClickCount'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'FriendlyLink', N'COLUMN', N'ISEnable'
GO
ALTER TABLE dbo.FriendlyLink ADD CONSTRAINT
	PK_FriendlyLink PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FriendlyLink SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.FriendlyLink', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.FriendlyLink', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.FriendlyLink', 'Object', 'CONTROL') as Contr_Per 