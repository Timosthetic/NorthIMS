using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Profinet.Inovance;
using Infrastructure.Model;

namespace Infrastructure.Helper.ConnectToPlc
{
   public  class InovanceH5UTcp_Singleton
    {
        /// <summary>
        /// 单利模式
        /// </summary>
        private static InovanceH5UTcp_Singleton _Singleton = null;
        InovanceH5UTcp conTcp = null;
        bool res = false;
        private InovanceH5UTcp_Singleton( string ip,int port)
        {
            conTcp = new InovanceH5UTcp(ip, port);
        }

        public static InovanceH5UTcp_Singleton CreateInstance(string ip, int port)
        {
            lock ("rtu")
            {
                if (_Singleton == null)
                    _Singleton = new InovanceH5UTcp_Singleton(ip, port);
                return _Singleton;
            }

        }
        public bool Connection()
        {
            try
            {

                res = conTcp.ConnectServer().IsSuccess;
            }
            catch
            {
                return false;
            }
            return res;
        }
        public void Dispose()
        {
            if (res)
            {
                conTcp.Dispose();
            }
        }
        /// <summary>
        /// 读取PLC数据 单个数值
        /// </summary>
        /// <param name="variableType">变量类型</param>
        ///  <param name="variableAddress">变量地址</param>
        /// <returns></returns>
        public object Read(string variableType, string variableAddress, ushort length)
        {
            object result = null;
            switch (variableType)
            {
                case "XBool":
                    result = conTcp.ReadBool(variableAddress).Content;
                    break;
                case "XShort":
                    result = conTcp.ReadInt16(variableAddress).Content;
                    break;
                case "XInt":
                    result = conTcp.ReadInt32(variableAddress).Content;
                    break;
                case "XFloate":
                    result = conTcp.ReadFloat(variableAddress).Content;
                    break;
                case "XString":
                    result = conTcp.ReadString(variableAddress, length).Content;
                    break;
                case "XBoolArray":
                    result = conTcp.ReadBool(variableAddress, length).Content;
                    break;
                case "XShortArray":
                    result = conTcp.ReadInt16(variableAddress, length).Content;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 写入数据到plc
        /// </summary>
        /// <param name="variableAddress">地址</param>
        /// <param name="dataValue">数据  </param>
        public void Write(string variableType, string variableAddress, object dataValue)
        {
            switch (variableType)
            {
                case "XBool":
                    conTcp.Write(variableAddress, (bool)dataValue);
                    break;
                case "XShort":
                    conTcp.Write(variableAddress, (short)dataValue);
                    break;
                case "XInt":
                    conTcp.Write(variableAddress, (int)dataValue);
                    break;
                case "XFloate":
                    conTcp.Write(variableAddress, (float)dataValue);
                    break;
                case "XShortArray":
                    conTcp.Write(variableAddress, (string)dataValue);
                    break;

            }

        }
    }
}
