using jdbcrpc.thrift;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.threading
{
    internal sealed class ClientPool : IDisposable
    {
        private ConcurrentQueue<RjdbcService.Client> queue;
        private Func<RjdbcService.Client> itemBuilder;

        public int MaxQueue { get; set; }

        public ClientPool(Func<RjdbcService.Client> itemBuilder, int maxQueue)
        {
            this.MaxQueue = maxQueue;
            this.queue = new ConcurrentQueue<RjdbcService.Client>();
            this.itemBuilder = itemBuilder;
        }

        public void Empty()
        {
            for (int i = 0; i < this.queue.Count; i++)
            {
                RjdbcService.Client client;
                if (this.queue.TryDequeue(out client))
                {
                    client.Dispose();
                }
            }
        }

        public RjdbcService.Client Get()
        {
            if (this.isDisposed)
            {
                throw new InvalidOperationException("Connection pool is disposed");
            }

            RjdbcService.Client client;
            if (!this.queue.TryDequeue(out client) || !client.InputProtocol.Transport.IsOpen)
            {
                client = itemBuilder();
            }
            return client;
        }

        public void Release(RjdbcService.Client client)
        {
            if (this.isDisposed)
            {
                throw new InvalidOperationException("Connection pool is disposed");
            }

            if (this.queue.Count < this.MaxQueue && client != null && client.InputProtocol.Transport.IsOpen)
            {
                this.queue.Enqueue(client);
            }
        }

        #region IDisposable members

        private bool isDisposed = false;

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.Empty();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
