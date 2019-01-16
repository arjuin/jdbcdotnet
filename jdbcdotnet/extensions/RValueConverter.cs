using jdbcdotnet.helpers;
using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.extensions
{
    public static class RValueConverter
    {
        #region Primitive types

        public static string ToStringValue(this RValue value)
        {
            return value.Val.String_val;
        }

        public static long ToLong(this RValue value)
        {
            return value.Val.Bigint_val;
        }

        public static bool ToBool(this RValue value)
        {
            return value.Val.Bool_val;
        }

        public static int ToInt(this RValue value)
        {
            return value.Val.Integer_val;
        }

        public static short ToShort(this RValue value)
        {
            return value.Val.Smallint_val;
        }

        public static double ToDouble(this RValue value)
        {
            return value.Val.Double_val;
        }

        public static DateTime ToDateTime(this RValue value)
        {
            return value.Val.Bigint_val.FromEpochMsToDate();
        }

        public static object ToObjectValue(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            if (value.Val.__isset.array_val)
            {
                return value.Val.Array_val;
            }
            else if (value.Val.__isset.bigint_val)
            {
                return value.Val.Bigint_val;
            }
            else if (value.Val.__isset.binary_val)
            {
                return value.Val.Binary_val;
            }
            else if (value.Val.__isset.bool_val)
            {
                return value.Val.Bool_val;
            }
            else if (value.Val.__isset.double_val)
            {
                return value.Val.Double_val;
            }
            else if (value.Val.__isset.integer_val)
            {
                return value.Val.Integer_val;
            }
            else if (value.Val.__isset.msfromepoch_val)
            {
                return value.Val.Msfromepoch_val;
            }
            else if (value.Val.__isset.smallint_val)
            {
                return value.Val.Smallint_val;
            }
            else if (value.Val.__isset.string_val)
            {
                return value.Val.String_val;
            }
            else if (value.Val.__isset.tinyint_val)
            {
                return value.Val.Tinyint_val;
            }
            // should not occur
            else
            {
                return null;
            }
        }

        #endregion

        #region Enumerable

        public static IEnumerable<string> ToStringEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.String_val);
        }

        public static IEnumerable<long> ToLongEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Bigint_val);
        }

        public static IEnumerable<bool> ToBoolEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Bool_val);
        }

        public static IEnumerable<int> ToIntEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Integer_val);
        }

        public static IEnumerable<short> ToShortEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Smallint_val);
        }

        public static IEnumerable<double> ToDoubleEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Double_val);
        }

        public static IEnumerable<DateTime> ToDateTimeEnumerator(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Array_val.Elements.Select(e => e.Bigint_val.FromEpochMsToDate());
        }

        public static string ToStringNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.String_val;
        }

        #endregion

        #region Nullable primitives

        public static long? ToLongNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Bigint_val;
        }

        public static bool? ToBoolNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }
            return value.Val.Bool_val;
        }

        public static int? ToIntNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }
            return value.Val.Integer_val;
        }

        public static short? ToShortNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }
            return value.Val.Smallint_val;
        }

        public static double? ToDoubleNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }
            return value.Val.Double_val;
        }

        public static DateTime? ToDateTimeNullable(this RValue value)
        {
            if (value.Isnull)
            {
                return null;
            }

            return value.Val.Bigint_val.FromEpochMsToDate();
        }

        #endregion        
    }
}
