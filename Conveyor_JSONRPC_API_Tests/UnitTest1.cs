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
    public class UnitTest1
    {
        IPEndPoint ipEndPoint;
        TcpClient tcpClient;
        Stream dataStream;
        int rpcid;

        public UnitTest1()
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
            JsonRpcResult<printer[]> Response = CallMethod<printer[]>(ServerAPI.GetPrinters(rpcid));
            
            if (Response.result.Equals("world"))
            {
                return;
            }
            throw (new Exception());
        }
        
        public JsonRpcResult<T> CallMethod<T>(string JsonMethod)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(JsonMethod);
            dataStream.Write(byteArray, 0, byteArray.Length);
            //StreamWriter writer = new StreamWriter(dataStream);
            //writer.WriteLine(dataStream);
            //writer.Flush();
            //writer.Close();
            byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
            int bytesRead = dataStream.Read(bytesToRead, 0, bytesToRead.Length);
            string Reply = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            //string Reply = new StreamReader(dataStream).ReadToEnd();
            JsonSerializerSettings val = new JsonSerializerSettings();

            val.Error = delegate(object sender, ErrorEventArgs args)
            {
                args.ErrorContext.Handled = true;
            };
                
            return JsonConvert.DeserializeObject<JsonRpcResult<T>>(Reply, val);
        }
    }
}
