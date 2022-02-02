using System;
using System.Collections.Generic;
using System.Text;

namespace TimeServer.Helpers
{
    public class UtilHelpers
    {
        public static double CalculateTimestamp(DateTime target)
        {
            return (target - ConstantHelpers.referenceDatetime).TotalSeconds;
        }
        public static double ConvertByteArrayToDouble(byte[] b)
        {
            return BitConverter.ToDouble(b, 0);
        }
        public static byte[] ConvertDoubleToByteArray(double d)
        {
            return BitConverter.GetBytes(d);
        }
    }
}
