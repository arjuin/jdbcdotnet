using jdbcdotnet.jdbc;
using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace jdbcdotnet
{
    public abstract class AbstractJDBCClient : IDisposable
    {
        public abstract DBConnection GetNewDBConnection(string url, Dictionary<string, string> properties = null);
        public abstract bool IsClosed();

        internal abstract void Execute(Action<RjdbcService.Client> exec);
        internal abstract T Execute<T>(Func<RjdbcService.Client, T> exec);

        protected bool isClosed(RjdbcService.Client client)
        {
            return client == null || !client.InputProtocol.Transport.IsOpen;
        }

        protected RjdbcService.Client start(string server, int port)
        {
            RjdbcService.Client client;
            TSocket socket = new TSocket(server, port);
            TProtocol protocol = new TCompactProtocol(socket);
            client = new RjdbcService.Client(protocol);
            socket.Open();
            return client;
        }

        protected void stop(RjdbcService.Client client)
        {
            if (client != null)
            {
                client.Dispose();
            }
        }

        #region IDisposable members

        protected bool isDisposed = false;

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                dispose();
                this.isDisposed = true;
            }
        }
        
        protected abstract void dispose();

        #endregion
    }
}
