using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdbcdotnet.helpers;
using jdbcrpc.thrift;
using jdbcdotnet.jdbc;
using System.Collections;
using System.Reflection;

namespace jdbcdotnet.extensions
{
    public static class RValueSQLFactory
    {
        private static RValueSQL createValue(int sqlType, RawVal rawVal)
        {
            return new RValueSQL() { SqlType = sqlType, Val = rawVal };
        }

        #region Primitive types

        public static RValueSQL ToRValueSQL(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return ToRValueSQLNull();
            }

            RawVal rawVal = new RawVal() { String_val = value };
            return createValue(SQLTypes.VARCHAR, rawVal);
        }

        public static RValueSQL ToRValueSQL(this long value)
        {
            RawVal rawVal = new RawVal() { Bigint_val = value };
            return createValue(SQLTypes.BIGINT, rawVal);
        }

        public static RValueSQL ToRValueSQL(this bool value)
        {
            RawVal rawVal = new RawVal() { Bool_val = value };
            return createValue(SQLTypes.BOOLEAN, rawVal);
        }

        public static RValueSQL ToRValueSQL(this int value)
        {
            RawVal rawVal = new RawVal() { Integer_val = value };
            return createValue(SQLTypes.INTEGER, rawVal);
        }

        public static RValueSQL ToRValueSQL(this short value)
        {
            RawVal rawVal = new RawVal() { Smallint_val = value };
            return createValue(SQLTypes.SMALLINT, rawVal);
        }

        public static RValueSQL ToRValueSQL(this double value)
        {
            RawVal rawVal = new RawVal() { Double_val = value };
            return createValue(SQLTypes.DOUBLE, rawVal);
        }

        public static RValueSQL ToRValueSQL(this DateTime value)
        {
            RawVal rawVal = new RawVal() { Bigint_val = value.ToEpochMs() };
            return createValue(SQLTypes.TIMESTAMP, rawVal);
        }

        #endregion

        #region Nullable primitives

        public static RValueSQL ToRValueSQL(this long? value)
        {
            return value.HasValue ? value.Value.ToRValueSQL() : ToRValueSQLNull();
        }

        public static RValueSQL ToRValueSQL(this bool? value)
        {
            return value.HasValue ? value.Value.ToRValueSQL() : ToRValueSQLNull();
        }

        public static RValueSQL ToRValueSQL(this int? value)
        {
            return value.HasValue ? value.Value.ToRValueSQL() : ToRValueSQLNull();
        }

        public static RValueSQL ToRValueSQL(this short? value)
        {
            return value.HasValue ? value.Value.ToRValueSQL() : ToRValueSQLNull();
        }

        public static RValueSQL ToRValueSQL(this double? value)
        {
            return value.HasValue ? value.Value.ToRValueSQL() : ToRValueSQLNull();
        }

        #endregion

        #region Array

        private static RValueSQL createArray(int sqlType, List<RawVal> values)
        {
            ArrayVal arrayVal = new ArrayVal() { SqlType = sqlType, Elements = values };

            RawVal rawVal = new RawVal() { Array_val = arrayVal };
            return createValue(SQLTypes.ARRAY, rawVal);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<string> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (string v in values)
            {
                elements.Add(new RawVal() { String_val = v });
            }
            return createArray(SQLTypes.VARCHAR, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<long> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (long v in values)
            {
                elements.Add(new RawVal() { Bigint_val = v });
            }
            return createArray(SQLTypes.BIGINT, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<bool> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (bool v in values)
            {
                elements.Add(new RawVal() { Bool_val = v });
            }
            return createArray(SQLTypes.BOOLEAN, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<int> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (int v in values)
            {
                elements.Add(new RawVal() { Integer_val = v });
            }
            return createArray(SQLTypes.INTEGER, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<short> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (short v in values)
            {
                elements.Add(new RawVal() { Smallint_val = v });
            }
            return createArray(SQLTypes.SMALLINT, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<double> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (double v in values)
            {
                elements.Add(new RawVal() { Double_val = v });
            }
            return createArray(SQLTypes.DOUBLE, elements);
        }

        public static RValueSQL ToRValueSQL(this IEnumerable<DateTime> values)
        {
            List<RawVal> elements = new List<RawVal>();
            foreach (DateTime v in values)
            {
                elements.Add(new RawVal() { Bigint_val = v.ToEpochMs() });
            }
            return createArray(SQLTypes.TIMESTAMP, elements);
        }

        #endregion

        #region Special types

        public static RValueSQL ToRValueSQLNull()
        {
            return new RValueSQL() { Isnull = true };
        }

        #endregion

        #region Dynamic

        public static RValueSQL ToRValueSQLDynamic(this object value)
        {
            return value == null ? ToRValueSQLNull() : typeof(RValueSQLFactory)
                .GetMethod("ToRValueSQL", new Type[] { value.GetType() })
                .Invoke(null, new object[] { value }) as RValueSQL;
        }

        #endregion

        #region Flow methods

        public static RValueSQL ToRValueSQLOrNull<T>(this T? value, Func<T, RValueSQL> ifNotNull) where T : struct
        {
            return value.HasValue ? ifNotNull(value.Value) : ToRValueSQLNull();
        }

        public static RValueSQL ToRValueSQLOrNull<T>(this T value, Func<T, RValueSQL> ifNotNull) where T : class
        {
            return value != null ? ifNotNull(value) : ToRValueSQLNull();
        }

        #endregion
    }
}
