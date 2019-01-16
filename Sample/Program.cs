using jdbcdotnet;
using jdbcdotnet.jdbc;
using jdbcdotnet.threading;
using jdbcrpc.thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jdbcdotnet.extensions;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "10.223.186.149";
            int port = 9098;
            string jdbcString = "jdbc:phoenix:10.223.186.149:2181:/hbase-unsecure";
            string query = "select * from variant limit 1";

            // 1-Simple method: not thread safe, a client should be used in only one thread but can open multiple connection
            using (JDBCClient client = new JDBCClient(server, port))    // client is immediatly connected
            {
                // Open two connexion using the same tcp client for rpc calls
                using (DBConnection conn1 = client.GetNewDBConnection(jdbcString))
                {
                    bool valid = conn1.IsValid();
                }
                // usually jdbc driver implementation use a thread pool for handling connexion, so it the same      
                using (DBConnection conn2 = client.GetNewDBConnection(jdbcString))
                {
                    // Open a statement on server side
                    using (DBStatement statement = conn2.CreateStatement())
                    {
                        // Resultset is already closed on server side and everything is returned
                        var res = statement.Query(query);
                        foreach (var row in res.Rows)
                        {
                            foreach (var value in row.Values)
                            {

                            }
                        }
                    }
                }
            }

            // 2-Pooling method: client are asked and recycled on each call. It's thread safe and optimized.
            //using ()    // at this point there is no connection to server
            PooledJDBCClient manager = new PooledJDBCClient(server, port);
            {
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < 1000; ++i)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        using (var c = manager.GetNewDBConnection(jdbcString))
                        {
                            c.IsValid();    // internal client used for creating connection can be different from whose used for this call
                            using (DBStatement st = c.CreateStatement())
                            {
                                st.Execute(query);
                            }   // if statement are not released manually, they might not be released by finalizer.
                        }   // if connection are not released manually, they might not be released by finalizer.
                        // release connection should release associated statements.
                    }));
                }

                foreach (Task t in tasks)
                {
                    t.Wait();
                }
            }  // client are released at this point but connection and statement should
        }
    }
}
