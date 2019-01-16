using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.jdbc
{
    public abstract class DBAbstractStatement : IDisposable
    {
        protected AbstractJDBCClient client;
        protected RStatement statement;

        internal RStatement Connection { get { return this.statement; } }

        public int QueryTimeout
        {
            get { return this.client.Execute(c => c.statement_getQueryTimeout(this.statement)); }
            set { this.client.Execute(c => c.statement_setQueryTimeout(this.statement, value)); }
        }

        public int MaxRows
        {
            get { return this.client.Execute(c => c.statement_getMaxRows(this.statement)); }
            set { this.client.Execute(c => c.statement_setMaxRows(this.statement, value)); }
        }

        internal DBAbstractStatement(AbstractJDBCClient client, RStatement statement)
        {
            this.client = client;
            this.statement = statement;
        }

        public int GetResultSetType()
        {
            return this.client.Execute(c => c.statement_getResultSetType(this.statement));
        }

        public int GetUpdateCount()
        {
            return this.client.Execute(c => c.statement_getUpdateCount(this.statement));
        }

        public List<RSQLWarning> GetWarnings()
        {
            return this.client.Execute(c => c.statement_getWarnings(this.statement).Warnings);
        }

        public void ClearWarnings()
        {
            this.client.Execute(c => c.statement_clearWarnings(this.statement));
        }

        public void Cancel()
        {
            this.client.Execute(c => c.statement_cancel(this.statement));
        }

        public List<int> ExecuteBatch()
        {
            return this.client.Execute(c => c.statement_executeBatch(this.statement));
        }

        public void ClearBatch()
        {
            this.client.Execute(c => c.statement_clearBatch(this.statement));
        }

        private void close()
        {
            if (this.client != null && this.statement != null && !this.client.IsClosed())
            {
                this.client.Execute(c => c.statement_close(this.statement));
                this.client = null;
                this.statement = null;
            }
        }

        #region IDisposable members

        private bool isDisposed = false;

        ~DBAbstractStatement()
        {
            //TODO: fix finalizing bug before decommenting
            //dispose(false);
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    
                }

                // Try to close the connection remotely if not already closed when object is destroyed.
                try
                {
                    this.close();
                }
                catch (ObjectDisposedException)
                {
                    // inhibate
                }

                this.isDisposed = true;
            }
        }

        #endregion
    }
}
