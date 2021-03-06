/*
   2014年8月26日15:17:58
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
CREATE TABLE dbo.BlogArticles
	(
	ID int NOT NULL IDENTITY (1, 1),
	Title nvarchar(300) NULL,
	CreaterID int NULL,
	CreaterName nvarchar(100) NULL,
	ArticleTags nvarchar(600) NULL,
	UserCategoryID int NULL,
	BlogContent text NULL,
	CreateTime datetime NULL,
	BrowseCount int NULL,
	ReviewCount int NULL,
	RecommendCount int NULL,
	OppositionCount int NULL,
	Statenum int NULL,
	LastUpdateTime datetime NULL,
	LogCategotyFatherID INT NULL,
	LogCategorySubID INT  NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'标题'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'Title'
GO
DECLARE @v sql_variant 
SET @v = N'创建人ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'CreaterID'
GO
DECLARE @v sql_variant 
SET @v = N'文章标签'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ArticleTags'
GO
DECLARE @v sql_variant 
SET @v = N'用户自定义分类ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'UserCategoryID'
GO
DECLARE @v sql_variant 
SET @v = N'博文内容'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'BlogContent'
GO
DECLARE @v sql_variant 
SET @v = N'创建时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'CreateTime'
GO
DECLARE @v sql_variant 
SET @v = N'浏览次数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'BrowseCount'
GO
DECLARE @v sql_variant 
SET @v = N'评论数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ReviewCount'
GO
DECLARE @v sql_variant 
SET @v = N'推荐数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'RecommendCount'
GO
DECLARE @v sql_variant 
SET @v = N'反对数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'OppositionCount'
GO
DECLARE @v sql_variant 
SET @v = N'文档状态（10 正常 20 删除  30 待发表）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'Statenum'
GO
DECLARE @v sql_variant 
SET @v = N'最后操作时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'LastUpdateTime'
GO
DECLARE @v sql_variant 
SET @v = N'博文主类别'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'LogCategotyFatherID'
GO
DECLARE @v sql_variant 
SET @v = N'博文子类别'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'LogCategorySubID'
GO
ALTER TABLE dbo.BlogArticles ADD CONSTRAINT
	PK_BlogArticles PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BlogArticles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'CONTROL') as Contr_Per 