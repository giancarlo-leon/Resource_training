using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeServer.Helpers;


namespace TimeServer.Logic
{
    public class ServerLogic
    {
        private Socket _socket;
        private EndPoint _ep;

        public async Task Initialize()
        {
            try
            {
                
                _ep = new IPEndPoint(IPAddress.Any, ConstantHelpers.PORT);

                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
                _socket.Bind(_ep);
            }catch(Exception ex)
            {
                await LoggingHelper.LogError(ex, "Server Logic: Initialize");
            }
            
        }

        private async Task<byte[]> CreateResponse(byte[] request)
        {
            double preciseTimestamp = -1;
            try
            {
                NTPLogic ntp = new NTPLogic();
                double currentTimestamp = UtilHelpers.CalculateTimestamp(DateTime.Now);
                preciseTimestamp = await ntp.CaculatePreciseTimestamp(request, currentTimestamp);
                

            }catch(Exception ex)
            {
                await LoggingHelper.LogError(ex, "Server Logic: CreateResponse");
            }
            return UtilHelpers.ConvertDoubleToByteArray(preciseTimestamp);
        }

        public async Task StartMessageLoop()
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


                        res = await _socket.ReceiveMessageFromAsync(_buffer_recv_segment, SocketFlags.None, _ep);
                   
                    if (res.ReceivedBytes > 0)
                        {
                            var responseThread = new Thread(async() =>
                            {
                                
                                byte[] response = await CreateResponse(_buffer_recv_segment.Array);
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
                    
                        await LoggingHelper.LogError(ex, "Server Logic: StartMessageLoop");
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
