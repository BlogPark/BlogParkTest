/*
   2014年9月12日16:47:05
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
CREATE TABLE dbo.ParkNews
	(
	NewsID int NOT NULL IDENTITY (1, 1),
	NewsTitle nvarchar(100) NULL,
	ReleaseTime datetime NULL,
	ReleaseUserName nvarchar(50) NULL,
	NewsContext text NULL,
	SupportCount int NULL,
	AgainstCount int NULL,
	AlwaysTop int NULL,
	EditerRecommend int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'新闻ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'NewsID'
GO
DECLARE @v sql_variant 
SET @v = N'新闻标题'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'NewsTitle'
GO
DECLARE @v sql_variant 
SET @v = N'发布时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'ReleaseTime'
GO
DECLARE @v sql_variant 
SET @v = N'发布者名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'ReleaseUserName'
GO
DECLARE @v sql_variant 
SET @v = N'新闻内容'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'NewsContext'
GO
DECLARE @v sql_variant 
SET @v = N'支持数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'SupportCount'
GO
DECLARE @v sql_variant 
SET @v = N'反对数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'AgainstCount'
GO
DECLARE @v sql_variant 
SET @v = N'是否置顶'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'AlwaysTop'
GO
DECLARE @v sql_variant 
SET @v = N'是否编辑推荐'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'ParkNews', N'COLUMN', N'EditerRecommend'
GO
ALTER TABLE dbo.ParkNews ADD CONSTRAINT
	PK_ParkNews PRIMARY KEY CLUSTERED 
	(
	NewsID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ParkNews SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ParkNews', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ParkNews', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ParkNews', 'Object', 'CONTROL') as Contr_Per 