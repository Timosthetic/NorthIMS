using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HslCommunication.Profinet.Siemens;
using Infrastructure.ReadWritePlc;

namespace Infrastructure.Helper.ConnectToPlc
{
    public class ConToPlc
    {
      public  static Siemens_Singleton siemens_Singleton;
        public static InovanceH5UTcp_Singleton inovance;
        public static OmronFinsNet_Singleton omronFinsNet;
      
      
        public static bool ToPlc(string Ip, int port,ConnectionType connectionType= ConnectionType.Simens,SiemensPLCS siemensPLCS=SiemensPLCS.S1500)
        {
            bool result = false;
            Connection = connectionType;
         
            try
            {
                switch (connectionType)
                {
                    case ConnectionType.Simens:
                       siemens_Singleton = Siemens_Singleton.CreateInstance(siemensPLCS, Ip);
                        result = siemens_Singleton.Connection();
                        ;
                        break;
                    case ConnectionType.Inovance:
                         inovance = InovanceH5UTcp_Singleton.CreateInstance(Ip, port);
                        result = inovance.Connection();
                        break;
                    case ConnectionType.Omron:
                         omronFinsNet = OmronFinsNet_Singleton.CreateInstance(Ip, port);
                        result = omronFinsNet.Connection();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return result;
        }
       
        public static void DisposeToPlc(ConnectionType connectionType = ConnectionType.Simens)
        {
            try
            {
                switch (connectionType)
                {
                    case ConnectionType.Simens:
                        
                         siemens_Singleton.Dispose();
                       
                        break;
                    case ConnectionType.Inovance:
                       
                        inovance.Dispose();
                        break;
                    case ConnectionType.Omron:
                       
                        omronFinsNet.Dispose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static ConnectionType Connection= ConnectionType.Simens;
    }
    public enum ConnectionType
    {
        Simens=1,
        Inovance=2,
        Omron=3,
    }
}
