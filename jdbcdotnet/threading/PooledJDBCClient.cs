using jdbcdotnet.jdbc;
using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.threading
{
    public sealed class PooledJDBCClient : AbstractJDBCClient
    {
        private string ip;
        private int port;

        private ClientPool pool;

        public int MaxQueue
        {
            get { return this.pool.MaxQueue; }
        }

        public PooledJDBCClient(string server, int port, int maxQueue = 20)
            : base()
        {
            this.ip = server;
            this.port = port;
            this.pool = new ClientPool(() => start(this.ip, this.port), maxQueue);
        }

        public override bool IsClosed()
        {
            return this.isDisposed;
        }

        public override DBConnection GetNewDBConnection(string url, Dictionary<string, string> properties = null)
        {
            RjdbcService.Client client = this.pool.Get();
            DBConnection connection = new DBConnection(this, client.createConnection(url, properties));
            this.pool.Release(client);
            return connection;
        }

        internal override void Execute(Action<RjdbcService.Client> exec)
        {
            RjdbcService.Client client = this.pool.Get();
            exec(client);
            this.pool.Release(client);
        }

        internal override T Execute<T>(Func<RjdbcService.Client, T> exec)
        {
            RjdbcService.Client client = this.pool.Get();
            T ret = exec(client);
            this.pool.Release(client);
            return ret;
        }

        protected override void dispose()
        {
            this.pool.Dispose();
        }
    }
}
