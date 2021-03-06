/*
   2014年8月27日16:09:11
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
CREATE TABLE dbo.EssayCategory
	(
	ID int NOT NULL IDENTITY (1, 1),
	EssayCategoryName nvarchar(100) NULL,
	MemberID int NULL,
	IsUsed int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EssayCategory', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'分类名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EssayCategory', N'COLUMN', N'EssayCategoryName'
GO
DECLARE @v sql_variant 
SET @v = N'会员ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EssayCategory', N'COLUMN', N'MemberID'
GO
DECLARE @v sql_variant 
SET @v = N'是否在用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'EssayCategory', N'COLUMN', N'IsUsed'
GO
ALTER TABLE dbo.EssayCategory ADD CONSTRAINT
	PK_EssayCategory PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.EssayCategory SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.EssayCategory', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EssayCategory', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EssayCategory', 'Object', 'CONTROL') as Contr_Per 