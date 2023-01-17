# WineType.tt

So that WineType does not get stale, we create a table with entries which are used to create the enum WineType

## Create the table in SSMS for WineType

```sql
USE [wines]
GO

/****** Object:  Table [dbo].[WineType]    Script Date: 1/17/2023 3:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WineType](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[TypeName] [NVARCHAR](MAX) NOT NULL,
	[Description] [NVARCHAR](MAX) NOT NULL,
 CONSTRAINT [PK_WineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```

## Populate using data below

| Name        |   Description    |
|:------------- |:-------------|
| Red | Imported red wine |
| White | Imported white wine |
| Rose | Imported rose wine |
