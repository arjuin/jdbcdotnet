using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using jdbcrpc.thrift;
using System.Diagnostics;
using jdbcdotnet.threading;
using jdbcdotnet.jdbc;

namespace jdbcdotnet
{
    /// <summary>
    /// Not thread safe.
    /// </summary>
    public sealed class JDBCClient : AbstractJDBCClient
    {
        private RjdbcService.Client client;

        public JDBCClient(string server, int port)
        {
            this.client = start(server, port);
        }

        public override bool IsClosed()
        {
            return isClosed(this.client);
        }

        public void Restart(string server, int port)
        {
            if (!isClosed(this.client))
            {
                stop(this.client);
            }
            this.client = start(server, port);
        }

        public override DBConnection GetNewDBConnection(string url, Dictionary<string, string> properties = null)
        {
            return new DBConnection(this, this.client.createConnection(url, properties));
        }

        internal override void Execute(Action<RjdbcService.Client> exec)
        {
            exec(this.client);
        }

        internal override T Execute<T>(Func<RjdbcService.Client, T> exec)
        {
            return exec(this.client);
        }

        protected override void dispose()
        {
            stop(this.client);
            this.client = null;            
        }
    }
}
