using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using Conveyor_JSONRPC_API;
using Conveyor_JSONRPC_API.Types;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Conveyor_JSONRPC_API_Tests
{
    [TestClass]
    public class ServerAPITests
    {
        IPEndPoint ipEndPoint;
        TcpClient tcpClient;
        Stream dataStream;
        int rpcid;

        public ServerAPITests()
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            tcpClient = new TcpClient();
            tcpClient.Connect(ipEndPoint);
            dataStream = tcpClient.GetStream();
            rpcid = 0;
            Hello();
        }
        //[TestMethod]
        public void Hello()
        {
            rpcid++;
            string RPCHello = ServerAPI.Hello(rpcid);
            JsonRpcResult<string> Response = CallMethod<string>(RPCHello);
            if (Response.result.Equals("world"))
            {
                return;
            }
            throw (new Exception());
        }

        [TestMethod]
        public void GetPrinters()
        {
            rpcid++;
            JsonSerializerSettings val = new JsonSerializerSettings();
            val.Error = delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
            {
                args.ErrorContext.Handled = true;
            };
            string RPCGetPrinters = ServerAPI.GetPrinters(rpcid);
            JsonRpcResult<printer[]> Response = CallMethod<printer[]>(RPCGetPrinters, val);
            
            if (Response.result.Length > 0)
            {
                return;
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public job[] GetJobs()
        {
            rpcid++;
            string RPCGetJobs = ServerAPI.GetJobs(rpcid);
            JsonRpcResult<job[]> Response = CallMethod<job[]>(RPCGetJobs);
            return Response.result;
        }
        [TestMethod]
        public port[] GetPorts()
        {
            rpcid++;
            string RPCGetPorts = ServerAPI.GetPorts(rpcid);
            JsonRpcResult<port[]> Response = CallMethod<port[]>(RPCGetPorts);
            if (Response.result.Length > 0)
            {
                return Response.result;
            }
            throw (new Exception());
        }
        [TestMethod]
        public void Connect()
        {
            rpcid++;
            port[] Ports = GetPorts();
            string RPCConnect = ServerAPI.Connect(rpcid, null, null, false, Ports[0].name, null);
            JsonRpcResult<printer> Response = CallMethod<printer>(RPCConnect);
            if (Response.result.port_name.Equals(Ports[0].name))
            {
                return;
            }
            throw (new Exception());
        }

        public JsonRpcResult<T> CallMethod<T>(string JsonMethod)
        {
            return CallMethod<T>(JsonMethod, new JsonSerializerSettings());
        }
        public JsonRpcResult<T> CallMethod<T>(string JsonMethod, JsonSerializerSettings val)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(JsonMethod);
            dataStream.Write(byteArray, 0, byteArray.Length);
            byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
            int bytesRead = dataStream.Read(bytesToRead, 0, bytesToRead.Length);
            string Reply = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            return JsonConvert.DeserializeObject<JsonRpcResult<T>>(Reply, val);
        }
    }
}
