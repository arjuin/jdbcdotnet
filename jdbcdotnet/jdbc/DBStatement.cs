using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.jdbc
{
    public sealed class DBStatement : DBAbstractStatement
    {
        internal DBStatement(AbstractJDBCClient client, RStatement statement)
            : base(client, statement)
        {
        }

        public RResultSet Query(string sql)
        {
            return this.client.Execute(c => c.statement_executeQuery(this.statement, sql));
        }

        public int Update(string sql)
        {
            return this.client.Execute(c => c.statement_executeUpdate(this.statement, sql));
        }

        public bool Execute(string sql)
        {
            return this.client.Execute(c => c.statement_execute(this.statement, sql));
        }

        public RResultSet GetResultSet()
        {
            return this.client.Execute(c => c.statement_getResultSet(this.statement));
        }

        public void AddBatch(string sql)
        {
            this.client.Execute(c => c.statement_addBatch(this.statement, sql));
        }

        public void AddBatches(List<string> sql)
        {
            this.client.Execute(c => c.statement_addBatches(this.statement, sql));
        }
    }
}
