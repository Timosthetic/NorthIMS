using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Infrastructure.DealWithFile
{
    public class tool
    {
        private const string LogPath = "./RfidLog/DebugLog";
        private const double LogSaveDura_D = 5.0;
        private static ushort[] wCRCTalbeAbs = new ushort[] { 0, 0xcc01, 0xd801, 0x1400, 0xf001, 0x3c00, 0x2800, 0xe401, 0xa001, 0x6c00, 0x7800, 0xb401, 0x5000, 0x9c01, 0x8801, 0x4400 };

        public static void AddDebugLog_L0(string str)
        {
            string str4;
            DeleteLog(DateTime.Now.AddDays(-5.0));
            string path = "./RfidLog/DebugLog/" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            string s = DateTime.Now.ToString() + " --> " + str + "\r\n";
            Monitor.Enter(str4 = "./RfidLog/DebugLog");
            try
            {
                if (!Directory.Exists("./RfidLog/DebugLog"))
                {
                    Directory.CreateDirectory("./RfidLog/DebugLog");
                }
                FileStream stream = new FileStream(path, FileMode.Append);
                byte[] bytes = new UTF8Encoding().GetBytes(s);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                stream.Close();
            }
            catch
            {
            }
            finally
            {
                Monitor.Exit(str4);
            }
        }

        public static void AddDebugLog_L1(string str)
        {
            AddDebugLog_L0(str);
        }

        public static void AddDebugLog_L2(string str)
        {
        }

        public static bool ByteCmp(byte[] data1, int offset1, byte[] data2, int offset2, int len)
        {
            try
            {
                for (int i = 0; i < len; i++)
                {
                    if (data1[i + offset1] != data2[i + offset2])
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ByteToHexString(byte data)
        {
            string str = "";
            if (data < 0x10)
            {
                str = str + "0";
            }
            return (str + data.ToString("X"));
        }

        public static string ByteToHexString(byte[] data, int pos, int length)
        {
            string str = "";
            for (int i = pos; i < (pos + length); i++)
            {
                str = str + ByteToHexString(data[i]);
            }
            return str;
        }

        public static string ByteToIpString(byte[] data, int offset)
        {
            string str = "";
            if (data.Length > (offset + 4))
            {
                for (int i = 0; i < 4; i++)
                {
                    str = str + data[offset + i].ToString();
                    if (i < 3)
                    {
                        str = str + ".";
                    }
                }
            }
            return str;
        }

        public static void DeleteLog(DateTime date)
        {
            string path = "./RfidLog/DebugLog/" + date.ToString("yyyyMMdd") + ".log";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch
            {
            }
        }

        public static byte GetBCC(byte[] data, int offset, int len)
        {
            byte num = 0;
            for (int i = 0; i < len; i++)
            {
                num = (byte)(num ^ data[i + offset]);
            }
            return num;
        }

        public static bool getBit16(ref ushort reg, int bit) =>
            (0 != ((reg >> (bit & 0x1f)) & 1));

        public static ushort GetCRC16(byte[] data, int len)
        {
            ushort num = 0xffff;
            byte num3 = 0;
            for (int index = 0; index < len; index++)
            {
                num3 = data[index];
                num = (ushort)(wCRCTalbeAbs[(num3 ^ num) & 15] ^ (num >> 4));
                num = (ushort)(wCRCTalbeAbs[((num3 >> 4) ^ num) & 15] ^ (num >> 4));
            }
            return num;
        }

        public static byte[] IpStringToByte(string ip)
        {
            try
            {
                return IPAddress.Parse(ip).GetAddressBytes();
            }
            catch
            {
                return null;
            }
        }

        public static void setBit16(ref ushort reg, int bit, bool value)
        {
            if (value)
            {
                reg = (ushort)(reg | (((int)1) << bit));
            }
            else
            {
                reg = (ushort)(reg & ~(((int)1) << bit));
            }
        }

        public static byte[] addBytes(byte[] data1, byte[] data2)
        {
            byte[] data3 = new byte[data1.Length + data2.Length];
            data1.CopyTo(data3, 0);
            data2.CopyTo(data3, data1.Length);
            return data3;
        }
    }
}
