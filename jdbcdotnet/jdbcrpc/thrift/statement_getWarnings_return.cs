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
  public partial class statement_getWarnings_return : TBase
  {
    private List<RSQLWarning> _warnings;

    public List<RSQLWarning> Warnings
    {
      get
      {
        return _warnings;
      }
      set
      {
        __isset.warnings = true;
        this._warnings = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool warnings;
    }

    public statement_getWarnings_return() {
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
            if (field.Type == TType.List) {
              {
                Warnings = new List<RSQLWarning>();
                TList _list16 = iprot.ReadListBegin();
                for( int _i17 = 0; _i17 < _list16.Count; ++_i17)
                {
                  RSQLWarning _elem18;
                  _elem18 = new RSQLWarning();
                  _elem18.Read(iprot);
                  Warnings.Add(_elem18);
                }
                iprot.ReadListEnd();
              }
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
      TStruct struc = new TStruct("statement_getWarnings_return");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Warnings != null && __isset.warnings) {
        field.Name = "warnings";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Warnings.Count));
          foreach (RSQLWarning _iter19 in Warnings)
          {
            _iter19.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("statement_getWarnings_return(");
      bool __first = true;
      if (Warnings != null && __isset.warnings) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Warnings: ");
        __sb.Append(Warnings);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}