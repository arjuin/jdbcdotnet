/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace jdbcrpc.thrift
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class RResultSetMetaDataPart : TBase
  {
    private string _catalogName;
    private string _columnClassName;
    private int _columnDisplaySize;
    private string _columnLabel;
    private string _columnName;
    private int _columnType;
    private string _columnTypeName;
    private int _precision;
    private int _scale;
    private string _schemaName;
    private string _tableName;
    private bool _autoIncrement;
    private bool _caseSensitive;
    private bool _currency;
    private bool _definitelyWritable;
    private int _nullable;
    private bool _readOnly;
    private bool _searchable;
    private bool _signed;
    private bool _writable;

    public string CatalogName
    {
      get
      {
        return _catalogName;
      }
      set
      {
        __isset.catalogName = true;
        this._catalogName = value;
      }
    }

    public string ColumnClassName
    {
      get
      {
        return _columnClassName;
      }
      set
      {
        __isset.columnClassName = true;
        this._columnClassName = value;
      }
    }

    public int ColumnDisplaySize
    {
      get
      {
        return _columnDisplaySize;
      }
      set
      {
        __isset.columnDisplaySize = true;
        this._columnDisplaySize = value;
      }
    }

    public string ColumnLabel
    {
      get
      {
        return _columnLabel;
      }
      set
      {
        __isset.columnLabel = true;
        this._columnLabel = value;
      }
    }

    public string ColumnName
    {
      get
      {
        return _columnName;
      }
      set
      {
        __isset.columnName = true;
        this._columnName = value;
      }
    }

    public int ColumnType
    {
      get
      {
        return _columnType;
      }
      set
      {
        __isset.columnType = true;
        this._columnType = value;
      }
    }

    public string ColumnTypeName
    {
      get
      {
        return _columnTypeName;
      }
      set
      {
        __isset.columnTypeName = true;
        this._columnTypeName = value;
      }
    }

    public int Precision
    {
      get
      {
        return _precision;
      }
      set
      {
        __isset.precision = true;
        this._precision = value;
      }
    }

    public int Scale
    {
      get
      {
        return _scale;
      }
      set
      {
        __isset.scale = true;
        this._scale = value;
      }
    }

    public string SchemaName
    {
      get
      {
        return _schemaName;
      }
      set
      {
        __isset.schemaName = true;
        this._schemaName = value;
      }
    }

    public string TableName
    {
      get
      {
        return _tableName;
      }
      set
      {
        __isset.tableName = true;
        this._tableName = value;
      }
    }

    public bool AutoIncrement
    {
      get
      {
        return _autoIncrement;
      }
      set
      {
        __isset.autoIncrement = true;
        this._autoIncrement = value;
      }
    }

    public bool CaseSensitive
    {
      get
      {
        return _caseSensitive;
      }
      set
      {
        __isset.caseSensitive = true;
        this._caseSensitive = value;
      }
    }

    public bool Currency
    {
      get
      {
        return _currency;
      }
      set
      {
        __isset.currency = true;
        this._currency = value;
      }
    }

    public bool DefinitelyWritable
    {
      get
      {
        return _definitelyWritable;
      }
      set
      {
        __isset.definitelyWritable = true;
        this._definitelyWritable = value;
      }
    }

    public int Nullable
    {
      get
      {
        return _nullable;
      }
      set
      {
        __isset.nullable = true;
        this._nullable = value;
      }
    }

    public bool ReadOnly
    {
      get
      {
        return _readOnly;
      }
      set
      {
        __isset.@readOnly = true;
        this._readOnly = value;
      }
    }

    public bool Searchable
    {
      get
      {
        return _searchable;
      }
      set
      {
        __isset.searchable = true;
        this._searchable = value;
      }
    }

    public bool Signed
    {
      get
      {
        return _signed;
      }
      set
      {
        __isset.signed = true;
        this._signed = value;
      }
    }

    public bool Writable
    {
      get
      {
        return _writable;
      }
      set
      {
        __isset.writable = true;
        this._writable = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool catalogName;
      public bool columnClassName;
      public bool columnDisplaySize;
      public bool columnLabel;
      public bool columnName;
      public bool columnType;
      public bool columnTypeName;
      public bool precision;
      public bool scale;
      public bool schemaName;
      public bool tableName;
      public bool autoIncrement;
      public bool caseSensitive;
      public bool currency;
      public bool definitelyWritable;
      public bool nullable;
      public bool @readOnly;
      public bool searchable;
      public bool signed;
      public bool writable;
    }

    public RResultSetMetaDataPart() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              CatalogName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ColumnClassName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I32) {
              ColumnDisplaySize = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              ColumnLabel = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              ColumnName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.I32) {
              ColumnType = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.String) {
              ColumnTypeName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.I32) {
              Precision = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.I32) {
              Scale = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.String) {
              SchemaName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.String) {
              TableName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Bool) {
              AutoIncrement = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.Bool) {
              CaseSensitive = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.Bool) {
              Currency = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.Bool) {
              DefinitelyWritable = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.I32) {
              Nullable = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.Bool) {
              ReadOnly = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.Bool) {
              Searchable = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.Bool) {
              Signed = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Bool) {
              Writable = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("RResultSetMetaDataPart");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (CatalogName != null && __isset.catalogName) {
        field.Name = "catalogName";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(CatalogName);
        oprot.WriteFieldEnd();
      }
      if (ColumnClassName != null && __isset.columnClassName) {
        field.Name = "columnClassName";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ColumnClassName);
        oprot.WriteFieldEnd();
      }
      if (__isset.columnDisplaySize) {
        field.Name = "columnDisplaySize";
        field.Type = TType.I32;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ColumnDisplaySize);
        oprot.WriteFieldEnd();
      }
      if (ColumnLabel != null && __isset.columnLabel) {
        field.Name = "columnLabel";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ColumnLabel);
        oprot.WriteFieldEnd();
      }
      if (ColumnName != null && __isset.columnName) {
        field.Name = "columnName";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ColumnName);
        oprot.WriteFieldEnd();
      }
      if (__isset.columnType) {
        field.Name = "columnType";
        field.Type = TType.I32;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ColumnType);
        oprot.WriteFieldEnd();
      }
      if (ColumnTypeName != null && __isset.columnTypeName) {
        field.Name = "columnTypeName";
        field.Type = TType.String;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ColumnTypeName);
        oprot.WriteFieldEnd();
      }
      if (__isset.precision) {
        field.Name = "precision";
        field.Type = TType.I32;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Precision);
        oprot.WriteFieldEnd();
      }
      if (__isset.scale) {
        field.Name = "scale";
        field.Type = TType.I32;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Scale);
        oprot.WriteFieldEnd();
      }
      if (SchemaName != null && __isset.schemaName) {
        field.Name = "schemaName";
        field.Type = TType.String;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(SchemaName);
        oprot.WriteFieldEnd();
      }
      if (TableName != null && __isset.tableName) {
        field.Name = "tableName";
        field.Type = TType.String;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TableName);
        oprot.WriteFieldEnd();
      }
      if (__isset.autoIncrement) {
        field.Name = "autoIncrement";
        field.Type = TType.Bool;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(AutoIncrement);
        oprot.WriteFieldEnd();
      }
      if (__isset.caseSensitive) {
        field.Name = "caseSensitive";
        field.Type = TType.Bool;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(CaseSensitive);
        oprot.WriteFieldEnd();
      }
      if (__isset.currency) {
        field.Name = "currency";
        field.Type = TType.Bool;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Currency);
        oprot.WriteFieldEnd();
      }
      if (__isset.definitelyWritable) {
        field.Name = "definitelyWritable";
        field.Type = TType.Bool;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(DefinitelyWritable);
        oprot.WriteFieldEnd();
      }
      if (__isset.nullable) {
        field.Name = "nullable";
        field.Type = TType.I32;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Nullable);
        oprot.WriteFieldEnd();
      }
      if (__isset.@readOnly) {
        field.Name = "readOnly";
        field.Type = TType.Bool;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(ReadOnly);
        oprot.WriteFieldEnd();
      }
      if (__isset.searchable) {
        field.Name = "searchable";
        field.Type = TType.Bool;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Searchable);
        oprot.WriteFieldEnd();
      }
      if (__isset.signed) {
        field.Name = "signed";
        field.Type = TType.Bool;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Signed);
        oprot.WriteFieldEnd();
      }
      if (__isset.writable) {
        field.Name = "writable";
        field.Type = TType.Bool;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Writable);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("RResultSetMetaDataPart(");
      bool __first = true;
      if (CatalogName != null && __isset.catalogName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CatalogName: ");
        __sb.Append(CatalogName);
      }
      if (ColumnClassName != null && __isset.columnClassName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnClassName: ");
        __sb.Append(ColumnClassName);
      }
      if (__isset.columnDisplaySize) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnDisplaySize: ");
        __sb.Append(ColumnDisplaySize);
      }
      if (ColumnLabel != null && __isset.columnLabel) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnLabel: ");
        __sb.Append(ColumnLabel);
      }
      if (ColumnName != null && __isset.columnName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnName: ");
        __sb.Append(ColumnName);
      }
      if (__isset.columnType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnType: ");
        __sb.Append(ColumnType);
      }
      if (ColumnTypeName != null && __isset.columnTypeName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ColumnTypeName: ");
        __sb.Append(ColumnTypeName);
      }
      if (__isset.precision) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Precision: ");
        __sb.Append(Precision);
      }
      if (__isset.scale) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Scale: ");
        __sb.Append(Scale);
      }
      if (SchemaName != null && __isset.schemaName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SchemaName: ");
        __sb.Append(SchemaName);
      }
      if (TableName != null && __isset.tableName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TableName: ");
        __sb.Append(TableName);
      }
      if (__isset.autoIncrement) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AutoIncrement: ");
        __sb.Append(AutoIncrement);
      }
      if (__isset.caseSensitive) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CaseSensitive: ");
        __sb.Append(CaseSensitive);
      }
      if (__isset.currency) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Currency: ");
        __sb.Append(Currency);
      }
      if (__isset.definitelyWritable) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DefinitelyWritable: ");
        __sb.Append(DefinitelyWritable);
      }
      if (__isset.nullable) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Nullable: ");
        __sb.Append(Nullable);
      }
      if (__isset.@readOnly) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ReadOnly: ");
        __sb.Append(ReadOnly);
      }
      if (__isset.searchable) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Searchable: ");
        __sb.Append(Searchable);
      }
      if (__isset.signed) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Signed: ");
        __sb.Append(Signed);
      }
      if (__isset.writable) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Writable: ");
        __sb.Append(Writable);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
