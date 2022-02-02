using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeServer.Helpers;
using System.Net;
using System.Net.Sockets;

namespace TimeServer.Logic
{
    public class ServerLogicSync
    {
        private Socket _socket;
        private EndPoint _ep;

        public void Initialize()
        {
            try
            {

                _ep = new IPEndPoint(IPAddress.Any, ConstantHelpers.PORT);

                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
                _socket.Bind(_ep);
            }
            catch (Exception ex)
            {
                Task.Run(()=> LoggingHelper.LogError(ex, "Server Logic: Initialize"));
            }

        }

        private byte[] CreateResponse(byte[] request)
        {
            double preciseTimestamp = -1;
            try
            {
                NTPLogic ntp = new NTPLogic();
                double currentTimestamp = UtilHelpers.CalculateTimestamp(DateTime.Now);
                preciseTimestamp = Task.Run(()=> ntp.CaculatePreciseTimestamp(request, currentTimestamp)).Result;


            }
            catch (Exception ex)
            {
                Task.Run(() => LoggingHelper.LogError(ex, "Server Logic: CreateResponse"));
            }
            return UtilHelpers.ConvertDoubleToByteArray(preciseTimestamp);
        }

        public void StartMessageLoop()
        {

            SocketReceiveMessageFromResult res;
            while (true)
            {

                try
                {
                    byte[] _buffer_recv;
                    ArraySegment<byte> _buffer_recv_segment;


                    _buffer_recv = new byte[4096];
                    _buffer_recv_segment = new ArraySegment<byte>(_buffer_recv);


                    res = Task.Run(()=>_socket.ReceiveMessageFromAsync(_buffer_recv_segment, SocketFlags.None, _ep)).Result;

                    if (res.ReceivedBytes > 0)
                    {
                        var responseThread = new Thread(async () =>
                        {

                            byte[] response = CreateResponse(_buffer_recv_segment.Array);
                            await SendTo(res.RemoteEndPoint, response);
                        });
                        responseThread.Start();
                    }

                }
                catch (ObjectDisposedException esx)
                {
                    Console.Write(esx.Message);
                }
                catch (Exception ex)
                {

                    Task.Run(() => LoggingHelper.LogError(ex, "Server Logic: StartMessageLoop"));
                }

            }
        }

        private async Task SendTo(EndPoint recipient, byte[] data)
        {
            var s = new ArraySegment<byte>(data);
            await _socket.SendToAsync(s, SocketFlags.None, recipient);
        }
    }
}
