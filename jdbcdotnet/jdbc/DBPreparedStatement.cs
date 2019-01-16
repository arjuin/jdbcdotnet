using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.jdbc
{
    public sealed class DBPreparedStatement : DBAbstractStatement
    {
        internal DBPreparedStatement(AbstractJDBCClient client, RStatement statement)
            : base(client, statement)
        {
        }

        public void SetParameters(List<RValueSQL> parameters)
        {
            this.client.Execute(c => c.preparedstatement_setParameters(this.statement, parameters));       
        }

        public void SetParameters(RValueSQL parameter, int position)
        {
            this.client.Execute(c => c.preparedstatement_setParameter(this.statement, parameter, position));
        }

        public void ClearParameters()
        {
            this.client.Execute(c => c.preparedstatement_clearParameters(this.statement));
        }

        public RResultSet Query()
        {
            return this.client.Execute(c => c.preparedstatement_executeQuery(this.statement));
        }

        public int Update()
        {
            return this.client.Execute(c => c.preparedstatement_executeUpdate(this.statement));
        }

        public bool Execute()
        {
            return this.client.Execute(c => c.preparedstatement_execute(this.statement));
        }

        public RResultSet Query(List<RValueSQL> parameters)
        {
            return this.client.Execute(c => c.preparedstatement_setParametersThenExecuteQuery(this.statement, parameters));
        }

        public int Update(List<RValueSQL> parameters)
        {
            return this.client.Execute(c => c.preparedstatement_setParametersThenExecuteUpdate(this.statement, parameters));
        }

        public bool Execute(List<RValueSQL> parameters)
        {
            return this.client.Execute(c => c.preparedstatement_setParametersThenExecute(this.statement, parameters));
        }

        public void AddBatch()
        {
            this.client.Execute(c => c.preparedstatement_addBatch(this.statement));
        }

        public void AddBatch(List<RValueSQL> parameters)
        {
            this.client.Execute(c => c.preparedstatement_addBatchWithParameters(this.statement, parameters));
        }

        public List<int> ExecuteBatch(List<List<RValueSQL>> parameters)
        {
            return this.client.Execute(c => c.preparedstatement_executeBatch(this.statement, parameters));
        }
    }
}
