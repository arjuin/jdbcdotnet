using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.jdbc
{
    public static class SQLTypes
    {
        public const int TINYINT = -6;
        public const int SMALLINT = 5;
        public const int INTEGER = 4;
        public const int BIGINT = -5;
        public const int FLOAT = 6;
        public const int DOUBLE = 8;
        public const int DECIMAL = 3;
        public const int CHAR = 1;
        public const int VARCHAR = 12;
        public const int DATE = 91;
        public const int TIME = 92;
        public const int TIMESTAMP = 93;
        public const int BINARY = -2;
        public const int VARBINARY = -3;
        public const int BOOLEAN = 16;
        public const int ARRAY = 2003;
    }
}
