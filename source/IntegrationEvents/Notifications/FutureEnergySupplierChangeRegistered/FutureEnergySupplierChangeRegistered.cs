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
//     source: Notifications/FutureEnergySupplierChangeRegistered/FutureEnergySupplierChangeRegistered.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace NotificationContracts {

  /// <summary>Holder for reflection information generated from Notifications/FutureEnergySupplierChangeRegistered/FutureEnergySupplierChangeRegistered.proto</summary>
  public static partial class FutureEnergySupplierChangeRegisteredReflection {

    #region Descriptor
    /// <summary>File descriptor for Notifications/FutureEnergySupplierChangeRegistered/FutureEnergySupplierChangeRegistered.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FutureEnergySupplierChangeRegisteredReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cl1Ob3RpZmljYXRpb25zL0Z1dHVyZUVuZXJneVN1cHBsaWVyQ2hhbmdlUmVn",
            "aXN0ZXJlZC9GdXR1cmVFbmVyZ3lTdXBwbGllckNoYW5nZVJlZ2lzdGVyZWQu",
            "cHJvdG8aH2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8iqAEKJEZ1",
            "dHVyZUVuZXJneVN1cHBsaWVyQ2hhbmdlUmVnaXN0ZXJlZBIaChJhY2NvdW50",
            "aW5ncG9pbnRfaWQYASABKAkSEwoLZ3Nybl9udW1iZXIYAiABKAkSGwoTZW5l",
            "cmd5X3N1cHBsaWVyX2dsbhgDIAEoCRIyCg5lZmZlY3RpdmVfZGF0ZRgEIAEo",
            "CzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXBCGKoCFU5vdGlmaWNhdGlv",
            "bkNvbnRyYWN0c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::NotificationContracts.FutureEnergySupplierChangeRegistered), global::NotificationContracts.FutureEnergySupplierChangeRegistered.Parser, new[]{ "AccountingpointId", "GsrnNumber", "EnergySupplierGln", "EffectiveDate" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FutureEnergySupplierChangeRegistered : pb::IMessage<FutureEnergySupplierChangeRegistered>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FutureEnergySupplierChangeRegistered> _parser = new pb::MessageParser<FutureEnergySupplierChangeRegistered>(() => new FutureEnergySupplierChangeRegistered());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FutureEnergySupplierChangeRegistered> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::NotificationContracts.FutureEnergySupplierChangeRegisteredReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FutureEnergySupplierChangeRegistered() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FutureEnergySupplierChangeRegistered(FutureEnergySupplierChangeRegistered other) : this() {
      accountingpointId_ = other.accountingpointId_;
      gsrnNumber_ = other.gsrnNumber_;
      energySupplierGln_ = other.energySupplierGln_;
      effectiveDate_ = other.effectiveDate_ != null ? other.effectiveDate_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FutureEnergySupplierChangeRegistered Clone() {
      return new FutureEnergySupplierChangeRegistered(this);
    }

    /// <summary>Field number for the "accountingpoint_id" field.</summary>
    public const int AccountingpointIdFieldNumber = 1;
    private string accountingpointId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string AccountingpointId {
      get { return accountingpointId_; }
      set {
        accountingpointId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "gsrn_number" field.</summary>
    public const int GsrnNumberFieldNumber = 2;
    private string gsrnNumber_ = "";
    /// <summary>
    /// Unique metering point identification
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string GsrnNumber {
      get { return gsrnNumber_; }
      set {
        gsrnNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "energy_supplier_gln" field.</summary>
    public const int EnergySupplierGlnFieldNumber = 3;
    private string energySupplierGln_ = "";
    /// <summary>
    /// Unique Energy Supplier identifcation.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string EnergySupplierGln {
      get { return energySupplierGln_; }
      set {
        energySupplierGln_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "effective_date" field.</summary>
    public const int EffectiveDateFieldNumber = 4;
    private global::Google.Protobuf.WellKnownTypes.Timestamp effectiveDate_;
    /// <summary>
    /// Date which the change of supplier goes into effect.
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
      return Equals(other as FutureEnergySupplierChangeRegistered);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FutureEnergySupplierChangeRegistered other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AccountingpointId != other.AccountingpointId) return false;
      if (GsrnNumber != other.GsrnNumber) return false;
      if (EnergySupplierGln != other.EnergySupplierGln) return false;
      if (!object.Equals(EffectiveDate, other.EffectiveDate)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (AccountingpointId.Length != 0) hash ^= AccountingpointId.GetHashCode();
      if (GsrnNumber.Length != 0) hash ^= GsrnNumber.GetHashCode();
      if (EnergySupplierGln.Length != 0) hash ^= EnergySupplierGln.GetHashCode();
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
      if (AccountingpointId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AccountingpointId);
      }
      if (GsrnNumber.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(GsrnNumber);
      }
      if (EnergySupplierGln.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(EnergySupplierGln);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(34);
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
      if (AccountingpointId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AccountingpointId);
      }
      if (GsrnNumber.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(GsrnNumber);
      }
      if (EnergySupplierGln.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(EnergySupplierGln);
      }
      if (effectiveDate_ != null) {
        output.WriteRawTag(34);
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
      if (AccountingpointId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AccountingpointId);
      }
      if (GsrnNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(GsrnNumber);
      }
      if (EnergySupplierGln.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EnergySupplierGln);
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
    public void MergeFrom(FutureEnergySupplierChangeRegistered other) {
      if (other == null) {
        return;
      }
      if (other.AccountingpointId.Length != 0) {
        AccountingpointId = other.AccountingpointId;
      }
      if (other.GsrnNumber.Length != 0) {
        GsrnNumber = other.GsrnNumber;
      }
      if (other.EnergySupplierGln.Length != 0) {
        EnergySupplierGln = other.EnergySupplierGln;
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
            AccountingpointId = input.ReadString();
            break;
          }
          case 18: {
            GsrnNumber = input.ReadString();
            break;
          }
          case 26: {
            EnergySupplierGln = input.ReadString();
            break;
          }
          case 34: {
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
            AccountingpointId = input.ReadString();
            break;
          }
          case 18: {
            GsrnNumber = input.ReadString();
            break;
          }
          case 26: {
            EnergySupplierGln = input.ReadString();
            break;
          }
          case 34: {
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

  }

  #endregion

}

#endregion Designer generated code
