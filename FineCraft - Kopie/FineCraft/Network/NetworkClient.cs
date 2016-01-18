using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Net;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace FineCraft.Network
{
    public class NetworkClient
    {

        public NetworkClient(Func<TcpClient> client)
        {
            formatterReceive = new AwesomeFormatter();
            formatterSend = new AwesomeFormatter();
            connect = client;
            Reconnect();
            handlers = new CDictionary<string, Action<object>>();
        }
        Func<TcpClient> connect;
        public bool Reconnect()
        {
            if (client == null || IsConnectionLost)
            {
                try
                {
                    client = connect();
                    nsRead = client.GetStream();
                    nsWrite = new AwesomeWriteBuffer(nsRead);
                    IsConnectionLost = false;
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        TcpClient client;

        public bool IsConnectionLost { get; private set; }
        public event Action<NetworkClient> ConnectionLost;
        void connectionLost()
        {
            //if (Application.ProductName == "Server")
            //    Console.WriteLine("---lost connection---");

            bool recover = !IsConnectionLost && ConnectionLost != null;
            IsConnectionLost = true;
            HelpfulStuff.Try(() => client.Close());
            HelpfulStuff.Try(() => nsRead.Close());
            HelpfulStuff.Try(() => nsRead.Dispose());
            HelpfulStuff.Try(() => nsWrite.Dispose());
            HelpfulStuff.Try(() => handlers.Clear());

            if (recover)
                new Thread(() => ConnectionLost(this)).Start();
        }

        Stream nsRead;
        Stream nsWrite;
        AwesomeFormatter formatterReceive;
        AwesomeFormatter formatterSend;

        public T ReceiveOne<T>() where T : class
        {
            try
            {
                return formatterReceive.Deserialize(nsRead) as T;
            }
            catch (SerializationException e)
            {
                throw e;
            }
            catch
            {
                connectionLost();
                return null;
            }
        }
        public void Run()
        {
            new Thread(receive).Start();
        }
        void receive()
        {
            TcpClient client = this.client;
            if (client == null)
            {
                connectionLost();
                return;
            }
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            Thread.CurrentThread.IsBackground = true;
            object o;
            while (client.Connected)
            {
                o = ReceiveOne<object>();
                if (o == null) return;
                //TODO-rem
                if (Application.ProductName == "Server")
                    Console.WriteLine(">> " + o.GetType().Name + " : " + o.ToString());
                //TODO-rem
                Type t = o.GetType();
                while (t.BaseType.Name != "AwesomeSerializable")
                    t = t.BaseType;
                string s = t.FullName;
                if (!handlers.ContainsKey(s) && client.Connected)
                    throw new Exception("Handler \"" + s + "\" not registered.");
                handlers[s](o);
            }
        }

        CDictionary<string, Action<object>> handlers;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Send(AwesomeSerializable o)
        {
            //TODO-rem
            if (Application.ProductName == "Server")
                Console.WriteLine("<< " + o.GetType().Name + " : " + o.ToString());
            //TODO-rem
            if (IsConnectionLost) return;
            try
            {
                formatterSend.Serialize(nsWrite, o);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            catch
            {
                connectionLost();
            }
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Register<T>(Action<T> handler) where T : AwesomeSerializable
        {
            handlers[typeof(T).FullName] = o => handler(o as T);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Register<T>(Action<NetworkClient, T> handler) where T : AwesomeSerializable
        {
            handlers[typeof(T).FullName] = o => handler(this, o as T);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Unregister<T>()
        {
            string s = typeof(T).FullName;
            if (!handlers.ContainsKey(s))
                throw new Exception("Handler \"" + s + "\" not registered.");
            handlers.Remove(s);
        }

        public void Disconnect()
        {
            connectionLost();
        }
    }
}
