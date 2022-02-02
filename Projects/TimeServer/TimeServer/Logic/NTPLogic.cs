using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeServer.Helpers;

namespace TimeServer.Logic
{
    public class NTPLogic
    {
        private double OperateTimestamps(double sentTimestamp, double receivedTimestamp)
        {
            return receivedTimestamp - sentTimestamp;
        }
        private async Task<double> CalculateDelay(double sentTimestamp, double receivedTimestamp)
        {
            return await Task<double>.Run(() => OperateTimestamps(sentTimestamp, receivedTimestamp));
        }
        public async Task<double> CaculatePreciseTimestamp(byte[] clientClock, double packetReceivedTimestamp)
        {
            double delayTime;

            try
            {
                delayTime = await CalculateDelay( UtilHelpers.ConvertByteArrayToDouble(clientClock), packetReceivedTimestamp);
                return UtilHelpers.CalculateTimestamp(DateTime.Now) + delayTime;
            }catch(Exception ex)
            {
                await LoggingHelper.LogError(ex, "NTPLogic: CaculatePreciseTimestamp");
                return -1;
            }
        }
    }
}
