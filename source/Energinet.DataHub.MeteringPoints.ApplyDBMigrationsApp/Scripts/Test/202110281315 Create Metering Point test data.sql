GO
INSERT [dbo].[MeteringPoints] ([Id], [GsrnNumber], [StreetName], [PostCode], [CityName], [CountryCode], [ConnectionState_PhysicalState], [MeteringPointSubType], [MeterReadingOccurrence], [TypeOfMeteringPoint], [MaximumCurrent], [MaximumPower], [MeteringGridArea], [PowerPlant], [LocationDescription], [ProductType], [ParentRelatedMeteringPoint], [UnitType], [EffectiveDate], [MeterNumber], [ConnectionState_EffectiveDate], [StreetCode], [CitySubDivision], [Floor], [Room], [BuildingNumber], [MunicipalityCode], [IsActualAddress], [GeoInfoReference], [Capacity]) VALUES (N'e4e88496-1bfd-456d-afcc-3aa9ddd4ef72', N'571313180400013469', N'Test Road 1', N'8000', N'Aarhus', N'DK', N'New', N'Physical', N'Hourly', N'Exchange', 0, 0, N'10a9e0e7-3906-4dc0-8cbd-a5c042a5c484', NULL, N'', N'EnergyActive', NULL, N'KWh', CAST(N'2021-05-05T22:00:00.0000000' AS DateTime2), N'12345678910', NULL, N'9999', N'Aarhus', N'', N'', N'145K', 124, 0, NULL, NULL)
GO
INSERT [dbo].[ExchangeMeteringPoints] ([Id], [ToGrid], [FromGrid]) VALUES (N'e4e88496-1bfd-456d-afcc-3aa9ddd4ef72', N'10a9e0e7-3906-4dc0-8cbd-a5c042a5c484', N'10a9e0e7-3906-4dc0-8cbd-a5c042a5c484')
GO