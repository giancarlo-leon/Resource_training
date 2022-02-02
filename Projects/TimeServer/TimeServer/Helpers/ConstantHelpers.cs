using System;
using System.Collections.Generic;
using System.Text;

namespace TimeServer.Helpers
{
    public static class ConstantHelpers
    {
        public const string LOG_PATH = "./LOG";
        public const string DATEFORMAT_LOG = "mm_dd_yyyy_hh_mm_ss";
        public const int PORT = 1023;
        public static DateTime referenceDatetime = new DateTime(1900, 1, 1);
    }
}
