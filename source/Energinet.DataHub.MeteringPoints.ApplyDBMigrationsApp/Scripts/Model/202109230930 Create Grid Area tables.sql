CREATE TABLE [dbo].[GridAreas]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [RecordId] INT IDENTITY(1,1) NOT NULL,
    [Code] NVARCHAR(3) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [PriceAreaCode] NVARCHAR(5) NOT NULL

    CONSTRAINT [PK_GridAreas] PRIMARY KEY NONCLUSTERED ([Id])
)

CREATE UNIQUE CLUSTERED INDEX CIX_GridArea ON GridAreas([RecordId])
CREATE UNIQUE INDEX CIX_GridAreas_Code ON GridAreas([Code])

CREATE TABLE [dbo].[GridAreaLinks]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [RecordId] INT IDENTITY(1,1) NOT NULL,

    [GridAreaId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_GridAreaLinks] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [FK_GridAreaLinks_GridAreas] FOREIGN KEY ([GridAreaId]) REFERENCES [GridAreas]([Id])
)

CREATE UNIQUE CLUSTERED INDEX CIX_GridAreaLink ON GridAreaLinks([RecordId])
