using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace ts_ca_Interface
{
    public class CAFactory
    {
        private static readonly string strPath = ConfigurationManager.AppSettings["CACLASS"];

        public static InterfaceCA CreateCA()
        {
            string className = strPath + ".CAServicesEX";

            return (InterfaceCA)Assembly.Load(strPath).CreateInstance(className);
        }

    }
}
