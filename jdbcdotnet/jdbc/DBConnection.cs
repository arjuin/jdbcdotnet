using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.jdbc
{
    public class DBConnection : IDisposable
    {
        protected AbstractJDBCClient client;
        protected RConnection connection;

        internal RConnection Conn { get { return this.connection; } }

        public bool AutoCommit
        {
            get { return this.client.Execute(c => c.connection_getAutoCommit(this.connection)); }
            set { this.client.Execute(c => c.connection_setAutoCommit(this.connection, value)); }
        }

        public int TransactionIsolation
        {
            get { return this.client.Execute(c => c.connection_getTransactionIsolation(this.connection)); }
        }

        public bool ReadOnly
        {
            get { return this.client.Execute(c => c.connection_getReadOnly(this.connection)); }
        }

        internal DBConnection(AbstractJDBCClient client, RConnection connection)
        {
            this.client = client;
            this.connection = connection;
        }

        public DBStatement CreateStatement()
        {
            return new DBStatement(this.client, this.client.Execute(c => c.createStatement(this.connection)));
        }

        public DBPreparedStatement PrepareStatement(string sql)
        {
            return new DBPreparedStatement(this.client, this.client.Execute(c => c.prepareStatement(this.connection, sql)));
        }

        //public DBCallStatement PrepareCall(string sql)
        //{
        //    return new DBCallStatement(this.client, this.client.Execute(c => c.prepareStatement(this.connection, sql)));
        //}

        public void Commit()
        {
            this.client.Execute(c => c.connection_commit(this.connection));
        }

        public void Rollback()
        {
            this.client.Execute(c => c.connection_rollback(this.connection));
        }

        public RStaticMetaData GetMetadata()
        {
            return this.client.Execute(c => c.connection_getstaticmetadata(this.connection));
        }

        public bool IsValid(int timeoutms = 1000)
        {
            return this.client.Execute(c => c.connection_isvalid(this.connection, timeoutms));
        }

        public string GetCatalog()
        {
            return this.client.Execute(c => c.connection_getCatalog(this.connection));
        }

        public string GetSchema()
        {
            return this.client.Execute(c => c.connection_getSchema(this.connection));
        }

        public string GetCatalogSeparator()
        {
            return this.client.Execute(c => c.connection_getCatalogSeparator(this.connection));
        }

        public string GetCatalogTerm()
        {
            return this.client.Execute(c => c.connection_getCatalogSeparator(this.connection));
        }

        public RResultSet GetSchemas(string catalog, string schemaPattern)
        {
            return this.client.Execute(c => c.connection_getSchemas(this.connection, catalog, schemaPattern));
        }

        public RResultSet GetColumns(string catalog, string schemaPattern, string tableNamePattern, string columnNamePattern)
        {
            return this.client.Execute(c => c.connection_getColumns(this.connection, catalog, schemaPattern, tableNamePattern, columnNamePattern));
        }

        public RResultSet GetTables(string catalog, string schemaPattern, string tableNamePattern, List<string> types)
        {
            return this.client.Execute(c => c.connection_getTables(this.connection, catalog, schemaPattern, tableNamePattern, types));
        }

        public string GetSQLKeywords()
        {
            return this.client.Execute(c => c.connection_getSQLKeywords(this.connection));
        }

        public RResultSet GetTablesTypes()
        {
            return this.client.Execute(c => c.connection_getTableTypes(this.connection));
        }

        public RResultSet GetTablesTypeInfo()
        {
            return this.client.Execute(c => c.connection_getTypeInfo(this.connection));
        }

        private void close()
        {
            if (this.client != null && this.connection != null && !this.client.IsClosed())
            {
                this.client.Execute(c => c.closeConnection(this.connection));
                this.client = null;
                this.connection = null;
            }
        }

        #region IDisposable members
        
        private bool isDisposed = false;

        ~DBConnection()
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
