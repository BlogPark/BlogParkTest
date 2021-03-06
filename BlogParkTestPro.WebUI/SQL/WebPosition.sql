/*
   2014年9月10日21:52:07
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
CREATE TABLE dbo.WebPosition
	(
	PositionID int NOT NULL,
	PositionName nvarchar(50) NULL,
	ISEnable int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'位置ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPosition', N'COLUMN', N'PositionID'
GO
DECLARE @v sql_variant 
SET @v = N'网页位置'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPosition', N'COLUMN', N'PositionName'
GO
DECLARE @v sql_variant 
SET @v = N'是否启用'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'WebPosition', N'COLUMN', N'ISEnable'
GO
ALTER TABLE dbo.WebPosition ADD CONSTRAINT
	PK_WebPosition PRIMARY KEY CLUSTERED 
	(
	PositionID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.WebPosition SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
