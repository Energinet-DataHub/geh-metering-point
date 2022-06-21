// Copyright 2020 Energinet DataHub A/S
//
// Licensed under the Apache License, Version 2.0 (the "License2");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CreateMeteringPoint/ProductionMeteringPointCreated.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint {

  /// <summary>Holder for reflection information generated from CreateMeteringPoint/ProductionMeteringPointCreated.proto</summary>
  public static partial class ProductionMeteringPointCreatedReflection {

    #region Descriptor
    /// <summary>File descriptor for CreateMeteringPoint/ProductionMeteringPointCreated.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProductionMeteringPointCreatedReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjhDcmVhdGVNZXRlcmluZ1BvaW50L1Byb2R1Y3Rpb25NZXRlcmluZ1BvaW50",
            "Q3JlYXRlZC5wcm90bxofZ29vZ2xlL3Byb3RvYnVmL3RpbWVzdGFtcC5wcm90",
            "byKvCAoeUHJvZHVjdGlvbk1ldGVyaW5nUG9pbnRDcmVhdGVkEhkKEW1ldGVy",
            "aW5nX3BvaW50X2lkGAEgASgJEhMKC2dzcm5fbnVtYmVyGAIgASgJEhYKDmdy",
            "aWRfYXJlYV9jb2RlGAMgASgJEkcKD21ldGVyaW5nX21ldGhvZBgEIAEoDjIu",
            "LlByb2R1Y3Rpb25NZXRlcmluZ1BvaW50Q3JlYXRlZC5NZXRlcmluZ01ldGhv",
            "ZBJaChltZXRlcl9yZWFkaW5nX3BlcmlvZGljaXR5GAUgASgOMjcuUHJvZHVj",
            "dGlvbk1ldGVyaW5nUG9pbnRDcmVhdGVkLk1ldGVyUmVhZGluZ1BlcmlvZGlj",
            "aXR5ElAKFG5ldF9zZXR0bGVtZW50X2dyb3VwGAYgASgOMjIuUHJvZHVjdGlv",
            "bk1ldGVyaW5nUG9pbnRDcmVhdGVkLk5ldFNldHRsZW1lbnRHcm91cBI8Cgdw",
            "cm9kdWN0GAcgASgOMisuUHJvZHVjdGlvbk1ldGVyaW5nUG9pbnRDcmVhdGVk",
            "LlByb2R1Y3RUeXBlEkkKEGNvbm5lY3Rpb25fc3RhdGUYCCABKA4yLy5Qcm9k",
            "dWN0aW9uTWV0ZXJpbmdQb2ludENyZWF0ZWQuQ29ubmVjdGlvblN0YXRlEjsK",
            "CXVuaXRfdHlwZRgJIAEoDjIoLlByb2R1Y3Rpb25NZXRlcmluZ1BvaW50Q3Jl",
            "YXRlZC5Vbml0VHlwZRIyCg5lZmZlY3RpdmVfRGF0ZRgKIAEoCzIaLmdvb2ds",
            "ZS5wcm90b2J1Zi5UaW1lc3RhbXAibAoSTmV0U2V0dGxlbWVudEdyb3VwEgwK",
            "CE5TR19aRVJPEAASCwoHTlNHX09ORRABEgsKB05TR19UV08QAhINCglOU0df",
            "VEhSRUUQAxILCgdOU0dfU0lYEAQSEgoOTlNHX05JTkVUWU5JTkUQBSKHAQoL",
            "UHJvZHVjdFR5cGUSDQoJUFRfVEFSSUZGEAASEwoPUFRfRlVFTFFVQU5USVRZ",
            "EAESEgoOUFRfUE9XRVJBQ1RJVkUQAhIUChBQVF9QT1dFUlJFQUNUSVZFEAMS",
            "EwoPUFRfRU5FUkdZQUNUSVZFEAQSFQoRUFRfRU5FUkdZUkVBQ1RJVkUQBSJE",
            "Cg5NZXRlcmluZ01ldGhvZBIPCgtNTV9QSFlTSUNBTBAAEg4KCk1NX1ZJUlRV",
            "QUwQARIRCg1NTV9DQUxDVUxBVEVEEAIiPAoXTWV0ZXJSZWFkaW5nUGVyaW9k",
            "aWNpdHkSDgoKTVJQX0hPVVJMWRAAEhEKDU1SUF9RVUFSVEVSTFkQASIdCg9D",
            "b25uZWN0aW9uU3RhdGUSCgoGQ1NfTkVXEAAiOQoIVW5pdFR5cGUSCQoFVVRf",
            "V0gQABIKCgZVVF9LV0gQARIKCgZVVF9NV0gQAhIKCgZVVF9HV0gQA0JJqgJG",
            "RW5lcmdpbmV0LkRhdGFIdWIuTWV0ZXJpbmdQb2ludHMuSW50ZWdyYXRpb25F",
            "dmVudHMuQ3JlYXRlTWV0ZXJpbmdQb2ludGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated), global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Parser, new[]{ "MeteringPointId", "GsrnNumber", "GridAreaCode", "MeteringMethod", "MeterReadingPeriodicity", "NetSettlementGroup", "Product", "ConnectionState", "UnitType", "EffectiveDate" }, null, new[]{ typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///*
  /// This message is sent out when a Consumption metering point is created.
  /// </summary>
  public sealed partial class ProductionMeteringPointCreated : pb::IMessage<ProductionMeteringPointCreated>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProductionMeteringPointCreated> _parser = new pb::MessageParser<ProductionMeteringPointCreated>(() => new ProductionMeteringPointCreated());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProductionMeteringPointCreated> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreatedReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProductionMeteringPointCreated() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProductionMeteringPointCreated(ProductionMeteringPointCreated other) : this() {
      meteringPointId_ = other.meteringPointId_;
      gsrnNumber_ = other.gsrnNumber_;
      gridAreaCode_ = other.gridAreaCode_;
      meteringMethod_ = other.meteringMethod_;
      meterReadingPeriodicity_ = other.meterReadingPeriodicity_;
      netSettlementGroup_ = other.netSettlementGroup_;
      product_ = other.product_;
      connectionState_ = other.connectionState_;
      unitType_ = other.unitType_;
      effectiveDate_ = other.effectiveDate_ != null ? other.effectiveDate_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProductionMeteringPointCreated Clone() {
      return new ProductionMeteringPointCreated(this);
    }

    /// <summary>Field number for the "metering_point_id" field.</summary>
    public const int MeteringPointIdFieldNumber = 1;
    private string meteringPointId_ = "";
    /// <summary>
    /// Unique identification for metering point
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MeteringPointId {
      get { return meteringPointId_; }
      set {
        meteringPointId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "gsrn_number" field.</summary>
    public const int GsrnNumberFieldNumber = 2;
    private string gsrnNumber_ = "";
    /// <summary>
    /// Business facing metering point identifier
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string GsrnNumber {
      get { return gsrnNumber_; }
      set {
        gsrnNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "grid_area_code" field.</summary>
    public const int GridAreaCodeFieldNumber = 3;
    private string gridAreaCode_ = "";
    /// <summary>
    /// Signifies which grid area a metering point belongs to
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string GridAreaCode {
      get { return gridAreaCode_; }
      set {
        gridAreaCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "metering_method" field.</summary>
    public const int MeteringMethodFieldNumber = 4;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod meteringMethod_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical;
    /// <summary>
    /// Metering method denotes where energy quantities originate
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod MeteringMethod {
      get { return meteringMethod_; }
      set {
        meteringMethod_ = value;
      }
    }

    /// <summary>Field number for the "meter_reading_periodicity" field.</summary>
    public const int MeterReadingPeriodicityFieldNumber = 5;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity meterReadingPeriodicity_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly;
    /// <summary>
    /// Denotes how often a energy quantity is read on a metering point
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity MeterReadingPeriodicity {
      get { return meterReadingPeriodicity_; }
      set {
        meterReadingPeriodicity_ = value;
      }
    }

    /// <summary>Field number for the "net_settlement_group" field.</summary>
    public const int NetSettlementGroupFieldNumber = 6;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup netSettlementGroup_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero;
    /// <summary>
    /// Denotes the net settlement group
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup NetSettlementGroup {
      get { return netSettlementGroup_; }
      set {
        netSettlementGroup_ = value;
      }
    }

    /// <summary>Field number for the "product" field.</summary>
    public const int ProductFieldNumber = 7;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType product_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff;
    /// <summary>
    /// Denotes the product type
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType Product {
      get { return product_; }
      set {
        product_ = value;
      }
    }

    /// <summary>Field number for the "connection_state" field.</summary>
    public const int ConnectionStateFieldNumber = 8;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState connectionState_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew;
    /// <summary>
    /// Denotes which connection state a metering point is created with. For a production metering point this is always "New"
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState ConnectionState {
      get { return connectionState_; }
      set {
        connectionState_ = value;
      }
    }

    /// <summary>Field number for the "unit_type" field.</summary>
    public const int UnitTypeFieldNumber = 9;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType unitType_ = global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh;
    /// <summary>
    /// Denotes the unit type. For a production metering point this is always a variation of watt/hour
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType UnitType {
      get { return unitType_; }
      set {
        unitType_ = value;
      }
    }

    /// <summary>Field number for the "effective_Date" field.</summary>
    public const int EffectiveDateFieldNumber = 10;
    private global::Google.Protobuf.WellKnownTypes.Timestamp effectiveDate_;
    /// <summary>
    /// The date on which the metering point is created
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp EffectiveDate {
      get { return effectiveDate_; }
      set {
        effectiveDate_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProductionMeteringPointCreated);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProductionMeteringPointCreated other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MeteringPointId != other.MeteringPointId) return false;
      if (GsrnNumber != other.GsrnNumber) return false;
      if (GridAreaCode != other.GridAreaCode) return false;
      if (MeteringMethod != other.MeteringMethod) return false;
      if (MeterReadingPeriodicity != other.MeterReadingPeriodicity) return false;
      if (NetSettlementGroup != other.NetSettlementGroup) return false;
      if (Product != other.Product) return false;
      if (ConnectionState != other.ConnectionState) return false;
      if (UnitType != other.UnitType) return false;
      if (!object.Equals(EffectiveDate, other.EffectiveDate)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MeteringPointId.Length != 0) hash ^= MeteringPointId.GetHashCode();
      if (GsrnNumber.Length != 0) hash ^= GsrnNumber.GetHashCode();
      if (GridAreaCode.Length != 0) hash ^= GridAreaCode.GetHashCode();
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical) hash ^= MeteringMethod.GetHashCode();
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) hash ^= MeterReadingPeriodicity.GetHashCode();
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) hash ^= NetSettlementGroup.GetHashCode();
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff) hash ^= Product.GetHashCode();
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew) hash ^= ConnectionState.GetHashCode();
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh) hash ^= UnitType.GetHashCode();
      if (effectiveDate_ != null) hash ^= EffectiveDate.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (MeteringPointId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MeteringPointId);
      }
      if (GsrnNumber.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(GsrnNumber);
      }
      if (GridAreaCode.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(GridAreaCode);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        output.WriteRawTag(32);
        output.WriteEnum((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        output.WriteRawTag(40);
        output.WriteEnum((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        output.WriteRawTag(48);
        output.WriteEnum((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff) {
        output.WriteRawTag(56);
        output.WriteEnum((int) Product);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew) {
        output.WriteRawTag(64);
        output.WriteEnum((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh) {
        output.WriteRawTag(72);
        output.WriteEnum((int) UnitType);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(EffectiveDate);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (MeteringPointId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MeteringPointId);
      }
      if (GsrnNumber.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(GsrnNumber);
      }
      if (GridAreaCode.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(GridAreaCode);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        output.WriteRawTag(32);
        output.WriteEnum((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        output.WriteRawTag(40);
        output.WriteEnum((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        output.WriteRawTag(48);
        output.WriteEnum((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff) {
        output.WriteRawTag(56);
        output.WriteEnum((int) Product);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew) {
        output.WriteRawTag(64);
        output.WriteEnum((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh) {
        output.WriteRawTag(72);
        output.WriteEnum((int) UnitType);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(82);
        output.WriteMessage(EffectiveDate);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (MeteringPointId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MeteringPointId);
      }
      if (GsrnNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(GsrnNumber);
      }
      if (GridAreaCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(GridAreaCode);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Product);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) UnitType);
      }
      if (effectiveDate_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EffectiveDate);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProductionMeteringPointCreated other) {
      if (other == null) {
        return;
      }
      if (other.MeteringPointId.Length != 0) {
        MeteringPointId = other.MeteringPointId;
      }
      if (other.GsrnNumber.Length != 0) {
        GsrnNumber = other.GsrnNumber;
      }
      if (other.GridAreaCode.Length != 0) {
        GridAreaCode = other.GridAreaCode;
      }
      if (other.MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        MeteringMethod = other.MeteringMethod;
      }
      if (other.MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        MeterReadingPeriodicity = other.MeterReadingPeriodicity;
      }
      if (other.NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        NetSettlementGroup = other.NetSettlementGroup;
      }
      if (other.Product != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType.PtTariff) {
        Product = other.Product;
      }
      if (other.ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState.CsNew) {
        ConnectionState = other.ConnectionState;
      }
      if (other.UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType.UtWh) {
        UnitType = other.UnitType;
      }
      if (other.effectiveDate_ != null) {
        if (effectiveDate_ == null) {
          EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        EffectiveDate.MergeFrom(other.EffectiveDate);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MeteringPointId = input.ReadString();
            break;
          }
          case 18: {
            GsrnNumber = input.ReadString();
            break;
          }
          case 26: {
            GridAreaCode = input.ReadString();
            break;
          }
          case 32: {
            MeteringMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod) input.ReadEnum();
            break;
          }
          case 40: {
            MeterReadingPeriodicity = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity) input.ReadEnum();
            break;
          }
          case 48: {
            NetSettlementGroup = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup) input.ReadEnum();
            break;
          }
          case 56: {
            Product = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType) input.ReadEnum();
            break;
          }
          case 64: {
            ConnectionState = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState) input.ReadEnum();
            break;
          }
          case 72: {
            UnitType = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType) input.ReadEnum();
            break;
          }
          case 82: {
            if (effectiveDate_ == null) {
              EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EffectiveDate);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            MeteringPointId = input.ReadString();
            break;
          }
          case 18: {
            GsrnNumber = input.ReadString();
            break;
          }
          case 26: {
            GridAreaCode = input.ReadString();
            break;
          }
          case 32: {
            MeteringMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeteringMethod) input.ReadEnum();
            break;
          }
          case 40: {
            MeterReadingPeriodicity = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.MeterReadingPeriodicity) input.ReadEnum();
            break;
          }
          case 48: {
            NetSettlementGroup = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.NetSettlementGroup) input.ReadEnum();
            break;
          }
          case 56: {
            Product = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ProductType) input.ReadEnum();
            break;
          }
          case 64: {
            ConnectionState = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.ConnectionState) input.ReadEnum();
            break;
          }
          case 72: {
            UnitType = (global::Energinet.DataHub.MeteringPoints.IntegrationEvents.CreateMeteringPoint.ProductionMeteringPointCreated.Types.UnitType) input.ReadEnum();
            break;
          }
          case 82: {
            if (effectiveDate_ == null) {
              EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EffectiveDate);
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the ProductionMeteringPointCreated message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static partial class Types {
      public enum NetSettlementGroup {
        [pbr::OriginalName("NSG_ZERO")] NsgZero = 0,
        [pbr::OriginalName("NSG_ONE")] NsgOne = 1,
        [pbr::OriginalName("NSG_TWO")] NsgTwo = 2,
        [pbr::OriginalName("NSG_THREE")] NsgThree = 3,
        [pbr::OriginalName("NSG_SIX")] NsgSix = 4,
        [pbr::OriginalName("NSG_NINETYNINE")] NsgNinetynine = 5,
      }

      public enum ProductType {
        [pbr::OriginalName("PT_TARIFF")] PtTariff = 0,
        [pbr::OriginalName("PT_FUELQUANTITY")] PtFuelquantity = 1,
        [pbr::OriginalName("PT_POWERACTIVE")] PtPoweractive = 2,
        [pbr::OriginalName("PT_POWERREACTIVE")] PtPowerreactive = 3,
        [pbr::OriginalName("PT_ENERGYACTIVE")] PtEnergyactive = 4,
        [pbr::OriginalName("PT_ENERGYREACTIVE")] PtEnergyreactive = 5,
      }

      public enum MeteringMethod {
        /// <summary>
        /// Has a physical meter associated with it
        /// </summary>
        [pbr::OriginalName("MM_PHYSICAL")] MmPhysical = 0,
        /// <summary>
        /// Does not have a physical meter associated with it
        /// </summary>
        [pbr::OriginalName("MM_VIRTUAL")] MmVirtual = 1,
        /// <summary>
        /// Does not have a physical meter associated with it
        /// </summary>
        [pbr::OriginalName("MM_CALCULATED")] MmCalculated = 2,
      }

      public enum MeterReadingPeriodicity {
        /// <summary>
        /// Read every hour
        /// </summary>
        [pbr::OriginalName("MRP_HOURLY")] MrpHourly = 0,
        /// <summary>
        /// Read every 15 minutes
        /// </summary>
        [pbr::OriginalName("MRP_QUARTERLY")] MrpQuarterly = 1,
      }

      public enum ConnectionState {
        /// <summary>
        /// Always created with connection state new
        /// </summary>
        [pbr::OriginalName("CS_NEW")] CsNew = 0,
      }

      public enum UnitType {
        /// <summary>
        /// Watt per hour
        /// </summary>
        [pbr::OriginalName("UT_WH")] UtWh = 0,
        /// <summary>
        /// Kilowatt per hour
        /// </summary>
        [pbr::OriginalName("UT_KWH")] UtKwh = 1,
        /// <summary>
        /// Megawatt per hour
        /// </summary>
        [pbr::OriginalName("UT_MWH")] UtMwh = 2,
        /// <summary>
        /// Gigawatt per hour
        /// </summary>
        [pbr::OriginalName("UT_GWH")] UtGwh = 3,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
