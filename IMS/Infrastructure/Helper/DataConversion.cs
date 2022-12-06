using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Helper
{
    public static class DataConversion
    {
        /// <summary>
        /// 筛选出报警触发位的index集合
        /// </summary>
        /// <param name="integer">以short(对应plc word) 数组的形式表达报警 取出报警触发位</param>

        /// <returns></returns>
        private static readonly List<bool> Buffer = new List<bool>();
        private static readonly List<int> Result = new List<int>();

        public static List<int> ShortToBinaryBits(this IEnumerable<short> integer)
        {
            Buffer.Clear();
            Result.Clear();
            foreach (var item in integer)
            {
                Buffer.AddRange(ToBinaryBits(item));
            }
            for (var i = 0; i < Buffer.Count; i++)
            {
                if (Buffer[i])
                {
                    Result.Add(i);
                }
            }
            return Result;
        }
        /// <summary>
        /// 位转字
        /// 输入一个长度16的bool数组，返回一个Int16形式的字
        /// <para>高位在左，低位在右</para>
        /// </summary>
        /// <param name="bits"></param>
        /// <returns>Word</returns>
        public static short BitsToWord(bool[] bits)
        {
            short result = 0;
            for (int i = 0; i < 16; i++)
            {
                if (bits[i])
                    result |= (short)(1 << i);
            }
            return result;
        }


        /// <summary>
        /// 将Word类型转化成bit位数组   操作与PLc的报警位---标准操作
        /// </summary>
        /// <param name="integer"></param>
        /// <param name="resultSize">word-16，int-32</param>
        /// <returns></returns>
        public static bool[] ToBinaryBits(this short integer, int resultSize = 16)
        {
            bool[] result = new bool[resultSize];
            byte[] array = BitConverter.GetBytes(integer);
            //高低位转换，定制解析
            var res=array.Reverse().ToArray();
            BitArray bitArray = new BitArray(res);
            bitArray.CopyTo(result, 0);
            return result;
        }


        public static bool[] IntToBinaryBits(this int integer, int resultSize = 32)
        {
            bool[] result = new bool[resultSize];
            byte[] array = BitConverter.GetBytes(integer);
            //高低位转换，定制解析
            var res = array.Reverse().ToArray();
            BitArray bitArray = new BitArray(res);
            bitArray.CopyTo(result, 0);
            return result;
        }

        public static bool[] IntToBinaryBits64(this long integer, int resultSize = 64)
        {
            bool[] result = new bool[resultSize];
            byte[] array = BitConverter.GetBytes(integer);
            //高低位转换，定制解析
            var res = array.Reverse().ToArray();
            BitArray bitArray = new BitArray(res);
            bitArray.CopyTo(result, 0);
            return result;
        }
    }
}
