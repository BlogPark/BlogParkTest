/*
   2014年9月10日22:06:14
   用户: sa
   服务器: .
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
ALTER TABLE dbo.WebMenuOrder ADD
	ActionName nvarchar(50) NULL,
	ControllerName nvarchar(50) NULL,
	GotoAddress nvarchar(200) NULL
GO
DECLARE @v sql_variant 
SET @v = N'Action名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'ActionName'
GO
DECLARE @v sql_variant 
SET @v = N'Controller名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'ControllerName'
GO
DECLARE @v sql_variant 
SET @v = N'目标地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebMenuOrder', N'COLUMN', N'GotoAddress'
GO
ALTER TABLE dbo.WebMenuOrder SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.WebMenuOrder', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.WebMenuOrder', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.WebMenuOrder', 'Object', 'CONTROL') as Contr_Per 