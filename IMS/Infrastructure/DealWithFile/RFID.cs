using Infrastructure.Dto.NewDto;

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Serilog;
using Infrastructure.Helper;

namespace Infrastructure.DealWithFile
{
    public class RFIDReadInfo
    {
        /// <summary>
        ///  ，RFID读取返回信息
        /// </summary>
        /// <param name="stationInfo">工位编码</param>
        /// <param name="rfidInfo">标签信息</param>
        public RFIDReadInfo(short stationInfo,string rfidInfo)
        {
            StationInfo=stationInfo;
            RfidInfo=rfidInfo;
        }
        public RFIDReadInfo(string message)
        {
            Message=message;
        }
        public string Message { get; set; }
        public short StationInfo { get; set; }
        public string RfidInfo { get; set; }
    }
    public static class RFID
    {

        public static RFIDReadInfo GetRFIDReadInfo(string eventName)
        {
            try
            {
                var res = AppDbContext.Db.Queryable<Io_RFID_InFo>().Where(x => x.Station == eventName).First();
                if (res != null)
                {
                    var rfid = ReadRFID(res.IpAddress, res.Port);
                    short st = Convert.ToInt16(res.StCode);
                    return new RFIDReadInfo(st, rfid);
                }
                else
                {
                    return null;
                }
               
             
            }
            catch (Exception ex)
            {
               
               Log.Error($"读取RFID数据失败,原因:{ex.Message}");
                return new RFIDReadInfo("读取RFID数据失败");
            }
           
        }

        /// <summary>
        /// 按块读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         static string ReadRFID(string ip,int port)
        {
            byte[] b = new byte[] { 0xFF, 0x06, 0x20, 0x00, 0x01, 0x00, 0x00 };
            ushort res = tool.GetCRC16(b, b.Length);

            byte ah = (byte)((res >> 8) & 0xff); ;//高8位
            byte al = (byte)(res & 0xff);//低8位
            Byte[] data = new Byte[b.Length + 2];
            b.CopyTo(data, 0);
            data[data.Length - 2] = ah;
            data[data.Length - 1] = al;

            string responseData = "";
           
           
            handleRead(ip, port, data, ref responseData);
            return responseData;
            
        }

        static bool handleRead(String server, int port, Byte[] data, ref string receiveData)
        {
            bool ret = false;
            try
            {
                TcpClient client = new TcpClient(server, port);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new Byte[256];

                Int32 bytes = stream.Read(data, 0, data.Length);
                int dataLen = 0;
                if (data.Length > 2 && data[0] == 0xFF && data[5] == 0x00)
                {
                    dataLen = data[1];
                    byte[] revData = new byte[dataLen + 3];
                    Buffer.BlockCopy(data, 0, revData, 0, revData.Length);
                    receiveData = System.Text.Encoding.Default.GetString(revData, 7, revData.Length - 9);
                    receiveData = receiveData.Split('\0')[0];
                    Console.WriteLine("Received: {0}", receiveData);
                    ret = true;
                }

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return ret;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return ret;
            }

            return ret;
        }

    }
}
