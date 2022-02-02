using System;
using System.Threading.Tasks;
using TimeServer.Helpers;
using TimeServer.Logic;

namespace TimeServer
{
    class Program
    {
        private async static Task ServerMainAsync()
        {
            try
            {
                ServerLogic serverLogic = new ServerLogic();
                await serverLogic.Initialize();

                await serverLogic.StartMessageLoop();
            }
            catch (Exception ex)
            {
                await LoggingHelper.LogError(ex);
            }
        }

        private static void ServerMain()
        {
            ServerLogicSync server = new ServerLogicSync();
            server.Initialize();
            server.StartMessageLoop();
        }

        static void Main(string[] args)
        {
            ServerMain();
        }
    }
}
