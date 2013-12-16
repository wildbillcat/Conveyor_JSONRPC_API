using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using Conveyor_JSONRPC_API;
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

        public UnitTest1()
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            tcpClient = new TcpClient();
            tcpClient.Connect(ipEndPoint);
            dataStream = tcpClient.GetStream();
        }

        [TestMethod]
        public void A_Hello()
        {
            JsonRpcResult Response = CallMethod(dataStream, tcpClient, ServerAPI.Hello(2));
            if (Response.result.Equals("world"))
            {
                return;
            }
            throw (new Exception());
        }

        [TestMethod]
        public void GetPrinters()
        {
            JsonRpcResult Response = CallMethod(dataStream, tcpClient, ServerAPI.GetPrinters(3));
            if (Response.result.Equals("world"))
            {
                return;
            }
            throw (new Exception());
        }
        
        public static JsonRpcResult CallMethod(Stream dataStream, TcpClient tcpClient, string JsonMethod)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(JsonMethod);
            dataStream.Write(byteArray, 0, byteArray.Length);
            byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
            int bytesRead = dataStream.Read(bytesToRead, 0, bytesToRead.Length);
            string Reply = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            return JsonConvert.DeserializeObject<JsonRpcResult>(Reply);
        }
    }
}
