using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.extensions
{
    public class RowMapper
    {
        private Dictionary<string, int> columnByIndex;

        public RowMapper(RResultSet resultSet)
        {
            this.columnByIndex = new Dictionary<string, int>();
            for (int i = 0, cnt = resultSet.Metadata.Parts.Count; i < cnt; ++i)
            {
                RResultSetMetaDataPart metadata = resultSet.Metadata.Parts[i];
                this.columnByIndex.Add(metadata.ColumnName, i);
            }
        }

        public RowMapper(IEnumerable<string> columnsInOrder)
        {
            this.columnByIndex = new Dictionary<string, int>();
            int i = 0;
            foreach (string column in columnsInOrder)
            {
                this.columnByIndex.Add(column, i++);
            }
        }

        public void SetValueTo(RRow row, string column, Action<RValue> setter)
        {
            int idx;
            if (this.columnByIndex.TryGetValue(column, out idx))
            {
                setter(row.Values[idx]);
            }
        }

        public void SetValueTo(RRow row, string column, Action<RValue> setter, Action onUnknowColumn)
        {
            int idx;
            if (this.columnByIndex.TryGetValue(column, out idx))
            {
                setter(row.Values[idx]);
            }
            else
            {
                onUnknowColumn();
            }
        }

        public RValue RetrieveValue(RRow row, string column)
        {
            int idx;
            return this.columnByIndex.TryGetValue(column, out idx) ? row.Values[idx] : null;
        }

        public bool HasColumn(string column)
        {
            return this.columnByIndex.ContainsKey(column);
        }

        public List<string> GetColumns()
        {
            return this.columnByIndex.Keys.ToList();
        }
    }
}
