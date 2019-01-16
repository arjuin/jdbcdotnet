using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.extensions
{
    public static class RResultSetExtension
    {
        public static RowMapper GetRowMapper(this RResultSet resultSet)
        {
            return new RowMapper(resultSet);
        }
    }
}
