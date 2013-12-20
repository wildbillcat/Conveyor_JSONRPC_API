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

        [TestMethod]
        public void ParseInvalid()
        {
            string JSON = @"{object:sillyness}";
            JsonReplyType Reply = ConveyorJsonReplyParser.ReplyType(JSON);
            if (Reply != JsonReplyType.Invalid)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ParseError()
        {
            string JSON = "{\"jsonrpc\" : \"2.0\", \"id\": 5, \"error\": {\"message\": \"uncaught exception\", \"code\": -32000, \"data\": {\"args\": [\"COM3:9153:45077\"], \"name\": \"UnknownPortError\"}}}";
            JsonReplyType Reply = ConveyorJsonReplyParser.ReplyType(JSON);
            if (Reply != JsonReplyType.Error)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ParseMethod()
        {
            string JSON = "{\"params\": {\"displayName\": \"The Replicator 2\", \"name\": \"23C1:B015:7523733353635171E0D1\", \"printerType\": \"The Replicator 2\", \"profile_name\": \"Replicator2\", \"hasHeatedPlatform\": false, \"toolhead_target_temperature\": [0], \"build_volume\": [285, 153, 155], \"state\": \"IDLE\", \"driver_name\": \"s3g\", \"port_name\": \"COM3:9153:45077\", \"temperature\": {\"heated_platforms\": [], \"tools\": {\"0\": 104}}, \"uniqueName\": \"23C1:B015:7523733353635171E0D1\", \"canPrintToFile\": true, \"machineNames\": [\"TheReplicator2\"], \"numberOfToolheads\": 1, \"firmware_version\": 705, \"canPrint\": true}, \"jsonrpc\": \"2.0\", \"method\": \"machine_state_changed\"}";
            JsonReplyType Reply = ConveyorJsonReplyParser.ReplyType(JSON);
            if (Reply != JsonReplyType.Method)
            {
                Assert.Fail();
            }
            Console.WriteLine(ConveyorJsonReplyParser.GetMethodName(JSON));
        }

        [TestMethod]
        public void ParseResult()
        {
            string JSON = "{\"jsonrpc\": \"2.0\", \"result\": [{\"machine_name\": \"23C1:B015:7523733353635171E0D1\", \"failure\": null, \"profile_name\": \"Replicator2\", \"port_name\": \"COM3:9153:45077\", \"id\": 1, \"name\": \"Mr_Jaws\", \"state\": \"STOPPED\", \"driver_name\": \"s3g\", \"progress\": {\"progress\": 9, \"name\": \"print\"}, \"type\": \"PRINT_JOB\", \"conclusion\": \"CANCELED\"}], \"id\": 3}"; 
            JsonReplyType Reply = ConveyorJsonReplyParser.ReplyType(JSON);
            if (Reply != JsonReplyType.Result)
            {
                Assert.Fail();
            }
            Console.WriteLine(ConveyorJsonReplyParser.GetResultID(JSON));
        }

        [TestMethod]
        public void PortAttached()
        {
            string JSON = "{\"params\": {\"name\": \"COM3:9153:45077\", \"vid\": 9153, \"pid\": 45077, \"label\": \"Replicator 2\", \"driver_profiles\": {\"s3g\": [\"Replicator2X\", \"Replicator2\"]}, \"iserial\": \"7523733353635171E0D1\", \"path\": \"COM3\", \"type\": \"SERIAL\"}, \"jsonrpc\": \"2.0\", \"method\": \"port_attached\"}";
            JsonReplyType Reply = ConveyorJsonReplyParser.ReplyType(JSON);
            if (Reply != JsonReplyType.Method)
            {
                Assert.Fail();
            }
            if (!ConveyorJsonReplyParser.GetMethodName(JSON).Equals("port_attached"))
            {
                Assert.Fail();
            }
            port Port = ClientAPI.Port_Attached(JSON);
            Console.WriteLine(Port.name);
        }
    }
}
