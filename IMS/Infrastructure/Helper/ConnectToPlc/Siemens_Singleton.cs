using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using Infrastructure.ReadWritePlc;

namespace Infrastructure.Helper.ConnectToPlc
{
   
    public class Siemens_Singleton
    {
       
     /// <summary>
     /// 单利模式
     /// </summary>
        private static Siemens_Singleton _Singleton = null;
        SiemensS7Net conTcp = null;
        bool res=false;
        private Siemens_Singleton(SiemensPLCS siemens, string ip)
        {
            conTcp=new SiemensS7Net(siemens,ip);
        }
       
        public static Siemens_Singleton CreateInstance(SiemensPLCS siemens,string ip)
        {
            lock ("rtu")
            {
                if (_Singleton == null)
                    _Singleton = new Siemens_Singleton(siemens, ip);
                return _Singleton;
            }

        }
        public bool Connection()
        {
            try
            {
               
               res= conTcp.ConnectServer().IsSuccess;
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

       

        //public  object ReadPlcData(string tagName, string eventGroup)
        //{
        //    object result = null;
        //    foreach (var item in BasicInfoOfPlc.ReadCsv().Where(item => item.RequestTagName == tagName && item.EventGroup == eventGroup))
        //    {
        //        result = Read(item.VariableType, item.Address, Convert.ToUInt16(item.length));
        //    }
        //    return result;
        //}
        //public void WritePlcData(string tagName, string eventGroup, object datavalue)
        //{
        //    foreach (var item in BasicInfoOfPlc.ReadCsv().Where(item => item.ResponseTagName == tagName && item.EventGroup == eventGroup))
        //    {
        //        Write(item.VariableType, item.Address, datavalue);
        //    }
        //}
        ///// <summary>
        ///// 读取PLC数据 单个数值
        ///// </summary>
        ///// <param name="variableType">变量类型</param>
        /////  <param name="variableAddress">变量地址</param>
        ///// <returns></returns>
        //public  object Read(string variableType, string variableAddress, ushort length)
        //{
        //    object result = null;


           
        //    switch (variableType)
        //    {
        //        case "XBool":
        //            result = conTcp.ReadBool(variableAddress).Content;
        //            break;
        //        case "XShort":
        //            result = conTcp.ReadInt16(variableAddress).Content;
        //            break;
        //        case "XInt":
        //            result = conTcp.ReadInt32(variableAddress).Content;
        //            break;
        //        case "XFloate":
        //            result = conTcp.ReadFloat(variableAddress).Content;
        //            break;
        //        case "XString":
        //            result = conTcp.ReadString(variableAddress, length).Content;
        //            break;
        //        //case "XBoolArray":
        //        //    result = conTcp.ReadBool(variableAddress, length).Content;  不具备此功能
        //        //    break;
        //        case "XShortArray":
        //            result = conTcp.ReadInt16(variableAddress, length).Content;
        //            break;
        //        case "XRealArray":
        //            result = conTcp.ReadFloat(variableAddress, length).Content;
        //            break;
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 写入数据到plc
        ///// </summary>
        ///// <param name="variableAddress">地址</param>
        ///// <param name="dataValue">数据  </param>
        //public  void Write(string variableType, string variableAddress, object dataValue)
        //{
        //    switch (variableType)
        //    {
        //        case "XBool":
        //            conTcp.Write(variableAddress, (bool)dataValue);
        //            break;
        //        case "XShort":
        //            conTcp.Write(variableAddress, (short)dataValue);
        //            break;
        //        case "XInt":
        //            conTcp.Write(variableAddress, (int)dataValue);
        //            break;
        //        case "XFloate":
        //            conTcp.Write(variableAddress, (float)dataValue);
        //            break;
        //        case "XShortArray":
        //            conTcp.Write(variableAddress, (string)dataValue);
        //            break;
        //        case "XRealArray":
        //            conTcp.Write(variableAddress, (float[])dataValue);
        //            break;

        //    }

        //}

    }
}
