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
// limitations under the License.// Copyright 2020 Energinet DataHub A/S
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
//     source: CreateMeteringPoint/ConsumptionMeteringPointCreated.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Energinet.DataHub.MeteringPoints.IntegrationEventContracts {

  /// <summary>Holder for reflection information generated from CreateMeteringPoint/ConsumptionMeteringPointCreated.proto</summary>
  public static partial class ConsumptionMeteringPointCreatedReflection {

    #region Descriptor
    /// <summary>File descriptor for CreateMeteringPoint/ConsumptionMeteringPointCreated.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConsumptionMeteringPointCreatedReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjlDcmVhdGVNZXRlcmluZ1BvaW50L0NvbnN1bXB0aW9uTWV0ZXJpbmdQb2lu",
            "dENyZWF0ZWQucHJvdG8aH2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJv",
            "dG8iygkKH0NvbnN1bXB0aW9uTWV0ZXJpbmdQb2ludENyZWF0ZWQSGQoRbWV0",
            "ZXJpbmdfcG9pbnRfaWQYASABKAkSEwoLZ3Nybl9udW1iZXIYAiABKAkSFgoO",
            "Z3JpZF9hcmVhX2NvZGUYAyABKAkSTAoRc2V0dGxlbWVudF9tZXRob2QYBCAB",
            "KA4yMS5Db25zdW1wdGlvbk1ldGVyaW5nUG9pbnRDcmVhdGVkLlNldHRsZW1l",
            "bnRNZXRob2QSSAoPbWV0ZXJpbmdfbWV0aG9kGAUgASgOMi8uQ29uc3VtcHRp",
            "b25NZXRlcmluZ1BvaW50Q3JlYXRlZC5NZXRlcmluZ01ldGhvZBJbChltZXRl",
            "cl9yZWFkaW5nX3BlcmlvZGljaXR5GAYgASgOMjguQ29uc3VtcHRpb25NZXRl",
            "cmluZ1BvaW50Q3JlYXRlZC5NZXRlclJlYWRpbmdQZXJpb2RpY2l0eRJRChRu",
            "ZXRfc2V0dGxlbWVudF9ncm91cBgHIAEoDjIzLkNvbnN1bXB0aW9uTWV0ZXJp",
            "bmdQb2ludENyZWF0ZWQuTmV0U2V0dGxlbWVudEdyb3VwEj0KB3Byb2R1Y3QY",
            "CCABKA4yLC5Db25zdW1wdGlvbk1ldGVyaW5nUG9pbnRDcmVhdGVkLlByb2R1",
            "Y3RUeXBlEjIKDmVmZmVjdGl2ZV9kYXRlGAkgASgLMhouZ29vZ2xlLnByb3Rv",
            "YnVmLlRpbWVzdGFtcBJKChBjb25uZWN0aW9uX3N0YXRlGAogASgOMjAuQ29u",
            "c3VtcHRpb25NZXRlcmluZ1BvaW50Q3JlYXRlZC5Db25uZWN0aW9uU3RhdGUS",
            "PAoJdW5pdF90eXBlGAsgASgOMikuQ29uc3VtcHRpb25NZXRlcmluZ1BvaW50",
            "Q3JlYXRlZC5Vbml0VHlwZSJsChJOZXRTZXR0bGVtZW50R3JvdXASDAoITlNH",
            "X1pFUk8QABILCgdOU0dfT05FEAESCwoHTlNHX1RXTxACEg0KCU5TR19USFJF",
            "RRADEgsKB05TR19TSVgQBBISCg5OU0dfTklORVRZTklORRAFIocBCgtQcm9k",
            "dWN0VHlwZRINCglQVF9UQVJJRkYQABITCg9QVF9GVUVMUVVBTlRJVFkQARIS",
            "Cg5QVF9QT1dFUkFDVElWRRACEhQKEFBUX1BPV0VSUkVBQ1RJVkUQAxITCg9Q",
            "VF9FTkVSR1lBQ1RJVkUQBBIVChFQVF9FTkVSR1lSRUFDVElWRRAFIkQKEFNl",
            "dHRsZW1lbnRNZXRob2QSCwoHU01fRkxFWBAAEg8KC1NNX1BST0ZJTEVEEAES",
            "EgoOU01fTk9OUFJPRklMRUQQAiJECg5NZXRlcmluZ01ldGhvZBIPCgtNTV9Q",
            "SFlTSUNBTBAAEg4KCk1NX1ZJUlRVQUwQARIRCg1NTV9DQUxDVUxBVEVEEAIi",
            "PAoXTWV0ZXJSZWFkaW5nUGVyaW9kaWNpdHkSDgoKTVJQX0hPVVJMWRAAEhEK",
            "DU1SUF9RVUFSVEVSTFkQASIdCg9Db25uZWN0aW9uU3RhdGUSCgoGQ1NfTkVX",
            "EAAiOQoIVW5pdFR5cGUSCQoFVVRfV0gQABIKCgZVVF9LV0gQARIKCgZVVF9N",
            "V0gQAhIKCgZVVF9HV0gQA0I9qgI6RW5lcmdpbmV0LkRhdGFIdWIuTWV0ZXJp",
            "bmdQb2ludHMuSW50ZWdyYXRpb25FdmVudENvbnRyYWN0c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated), global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Parser, new[]{ "MeteringPointId", "GsrnNumber", "GridAreaCode", "SettlementMethod", "MeteringMethod", "MeterReadingPeriodicity", "NetSettlementGroup", "Product", "EffectiveDate", "ConnectionState", "UnitType" }, null, new[]{ typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState), typeof(global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType) }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///*
  /// This message is sent out when a Consumption metering point is created.
  /// </summary>
  public sealed partial class ConsumptionMeteringPointCreated : pb::IMessage<ConsumptionMeteringPointCreated>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ConsumptionMeteringPointCreated> _parser = new pb::MessageParser<ConsumptionMeteringPointCreated>(() => new ConsumptionMeteringPointCreated());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ConsumptionMeteringPointCreated> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreatedReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ConsumptionMeteringPointCreated() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ConsumptionMeteringPointCreated(ConsumptionMeteringPointCreated other) : this() {
      meteringPointId_ = other.meteringPointId_;
      gsrnNumber_ = other.gsrnNumber_;
      gridAreaCode_ = other.gridAreaCode_;
      settlementMethod_ = other.settlementMethod_;
      meteringMethod_ = other.meteringMethod_;
      meterReadingPeriodicity_ = other.meterReadingPeriodicity_;
      netSettlementGroup_ = other.netSettlementGroup_;
      product_ = other.product_;
      effectiveDate_ = other.effectiveDate_ != null ? other.effectiveDate_.Clone() : null;
      connectionState_ = other.connectionState_;
      unitType_ = other.unitType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ConsumptionMeteringPointCreated Clone() {
      return new ConsumptionMeteringPointCreated(this);
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

    /// <summary>Field number for the "settlement_method" field.</summary>
    public const int SettlementMethodFieldNumber = 4;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod settlementMethod_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod SettlementMethod {
      get { return settlementMethod_; }
      set {
        settlementMethod_ = value;
      }
    }

    /// <summary>Field number for the "metering_method" field.</summary>
    public const int MeteringMethodFieldNumber = 5;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod meteringMethod_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical;
    /// <summary>
    /// Metering method denotes how energy quantity is calculated in other domain
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod MeteringMethod {
      get { return meteringMethod_; }
      set {
        meteringMethod_ = value;
      }
    }

    /// <summary>Field number for the "meter_reading_periodicity" field.</summary>
    public const int MeterReadingPeriodicityFieldNumber = 6;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity meterReadingPeriodicity_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly;
    /// <summary>
    /// Denotes how often a energy quantity is read on a metering point
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity MeterReadingPeriodicity {
      get { return meterReadingPeriodicity_; }
      set {
        meterReadingPeriodicity_ = value;
      }
    }

    /// <summary>Field number for the "net_settlement_group" field.</summary>
    public const int NetSettlementGroupFieldNumber = 7;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup netSettlementGroup_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero;
    /// <summary>
    /// Denotes the net settlement group
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup NetSettlementGroup {
      get { return netSettlementGroup_; }
      set {
        netSettlementGroup_ = value;
      }
    }

    /// <summary>Field number for the "product" field.</summary>
    public const int ProductFieldNumber = 8;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType product_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType Product {
      get { return product_; }
      set {
        product_ = value;
      }
    }

    /// <summary>Field number for the "effective_date" field.</summary>
    public const int EffectiveDateFieldNumber = 9;
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

    /// <summary>Field number for the "connection_state" field.</summary>
    public const int ConnectionStateFieldNumber = 10;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState connectionState_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew;
    /// <summary>
    /// Denotes which connection state a metering point is created with. For a consumption metering point this is always "New"
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState ConnectionState {
      get { return connectionState_; }
      set {
        connectionState_ = value;
      }
    }

    /// <summary>Field number for the "unit_type" field.</summary>
    public const int UnitTypeFieldNumber = 11;
    private global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType unitType_ = global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh;
    /// <summary>
    /// Denotes the unit type. For a production metering point this is always a variation of watt/hour
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType UnitType {
      get { return unitType_; }
      set {
        unitType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ConsumptionMeteringPointCreated);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ConsumptionMeteringPointCreated other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MeteringPointId != other.MeteringPointId) return false;
      if (GsrnNumber != other.GsrnNumber) return false;
      if (GridAreaCode != other.GridAreaCode) return false;
      if (SettlementMethod != other.SettlementMethod) return false;
      if (MeteringMethod != other.MeteringMethod) return false;
      if (MeterReadingPeriodicity != other.MeterReadingPeriodicity) return false;
      if (NetSettlementGroup != other.NetSettlementGroup) return false;
      if (Product != other.Product) return false;
      if (!object.Equals(EffectiveDate, other.EffectiveDate)) return false;
      if (ConnectionState != other.ConnectionState) return false;
      if (UnitType != other.UnitType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MeteringPointId.Length != 0) hash ^= MeteringPointId.GetHashCode();
      if (GsrnNumber.Length != 0) hash ^= GsrnNumber.GetHashCode();
      if (GridAreaCode.Length != 0) hash ^= GridAreaCode.GetHashCode();
      if (SettlementMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex) hash ^= SettlementMethod.GetHashCode();
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical) hash ^= MeteringMethod.GetHashCode();
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) hash ^= MeterReadingPeriodicity.GetHashCode();
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) hash ^= NetSettlementGroup.GetHashCode();
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff) hash ^= Product.GetHashCode();
      if (effectiveDate_ != null) hash ^= EffectiveDate.GetHashCode();
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew) hash ^= ConnectionState.GetHashCode();
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh) hash ^= UnitType.GetHashCode();
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
      if (SettlementMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex) {
        output.WriteRawTag(32);
        output.WriteEnum((int) SettlementMethod);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        output.WriteRawTag(40);
        output.WriteEnum((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        output.WriteRawTag(48);
        output.WriteEnum((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        output.WriteRawTag(56);
        output.WriteEnum((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff) {
        output.WriteRawTag(64);
        output.WriteEnum((int) Product);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(74);
        output.WriteMessage(EffectiveDate);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew) {
        output.WriteRawTag(80);
        output.WriteEnum((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh) {
        output.WriteRawTag(88);
        output.WriteEnum((int) UnitType);
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
      if (SettlementMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex) {
        output.WriteRawTag(32);
        output.WriteEnum((int) SettlementMethod);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        output.WriteRawTag(40);
        output.WriteEnum((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        output.WriteRawTag(48);
        output.WriteEnum((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        output.WriteRawTag(56);
        output.WriteEnum((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff) {
        output.WriteRawTag(64);
        output.WriteEnum((int) Product);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(74);
        output.WriteMessage(EffectiveDate);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew) {
        output.WriteRawTag(80);
        output.WriteEnum((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh) {
        output.WriteRawTag(88);
        output.WriteEnum((int) UnitType);
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
      if (SettlementMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) SettlementMethod);
      }
      if (MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MeteringMethod);
      }
      if (MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MeterReadingPeriodicity);
      }
      if (NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) NetSettlementGroup);
      }
      if (Product != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Product);
      }
      if (effectiveDate_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EffectiveDate);
      }
      if (ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ConnectionState);
      }
      if (UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) UnitType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ConsumptionMeteringPointCreated other) {
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
      if (other.SettlementMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod.SmFlex) {
        SettlementMethod = other.SettlementMethod;
      }
      if (other.MeteringMethod != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod.MmPhysical) {
        MeteringMethod = other.MeteringMethod;
      }
      if (other.MeterReadingPeriodicity != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity.MrpHourly) {
        MeterReadingPeriodicity = other.MeterReadingPeriodicity;
      }
      if (other.NetSettlementGroup != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup.NsgZero) {
        NetSettlementGroup = other.NetSettlementGroup;
      }
      if (other.Product != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType.PtTariff) {
        Product = other.Product;
      }
      if (other.effectiveDate_ != null) {
        if (effectiveDate_ == null) {
          EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        EffectiveDate.MergeFrom(other.EffectiveDate);
      }
      if (other.ConnectionState != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState.CsNew) {
        ConnectionState = other.ConnectionState;
      }
      if (other.UnitType != global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType.UtWh) {
        UnitType = other.UnitType;
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
            SettlementMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod) input.ReadEnum();
            break;
          }
          case 40: {
            MeteringMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod) input.ReadEnum();
            break;
          }
          case 48: {
            MeterReadingPeriodicity = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity) input.ReadEnum();
            break;
          }
          case 56: {
            NetSettlementGroup = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup) input.ReadEnum();
            break;
          }
          case 64: {
            Product = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType) input.ReadEnum();
            break;
          }
          case 74: {
            if (effectiveDate_ == null) {
              EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EffectiveDate);
            break;
          }
          case 80: {
            ConnectionState = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState) input.ReadEnum();
            break;
          }
          case 88: {
            UnitType = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType) input.ReadEnum();
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
            SettlementMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.SettlementMethod) input.ReadEnum();
            break;
          }
          case 40: {
            MeteringMethod = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeteringMethod) input.ReadEnum();
            break;
          }
          case 48: {
            MeterReadingPeriodicity = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.MeterReadingPeriodicity) input.ReadEnum();
            break;
          }
          case 56: {
            NetSettlementGroup = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.NetSettlementGroup) input.ReadEnum();
            break;
          }
          case 64: {
            Product = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ProductType) input.ReadEnum();
            break;
          }
          case 74: {
            if (effectiveDate_ == null) {
              EffectiveDate = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(EffectiveDate);
            break;
          }
          case 80: {
            ConnectionState = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.ConnectionState) input.ReadEnum();
            break;
          }
          case 88: {
            UnitType = (global::Energinet.DataHub.MeteringPoints.IntegrationEventContracts.ConsumptionMeteringPointCreated.Types.UnitType) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

    #region Nested types
    /// <summary>Container for nested types declared in the ConsumptionMeteringPointCreated message type.</summary>
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

      public enum SettlementMethod {
        [pbr::OriginalName("SM_FLEX")] SmFlex = 0,
        [pbr::OriginalName("SM_PROFILED")] SmProfiled = 1,
        [pbr::OriginalName("SM_NONPROFILED")] SmNonprofiled = 2,
      }

      public enum MeteringMethod {
        [pbr::OriginalName("MM_PHYSICAL")] MmPhysical = 0,
        [pbr::OriginalName("MM_VIRTUAL")] MmVirtual = 1,
        [pbr::OriginalName("MM_CALCULATED")] MmCalculated = 2,
      }

      public enum MeterReadingPeriodicity {
        [pbr::OriginalName("MRP_HOURLY")] MrpHourly = 0,
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
