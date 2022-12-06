using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Model
{
   public static class TagName
    {
        #region[公共区数据]
        /// <summary>
        /// 工段号
        /// </summary>
        public const string SectionID = "SectionID";
        /// <summary>
        /// 机台编号，从1开始
        /// </summary>
        public const string MachineID = "MachineID";
        /// <summary>
        /// 1. Standby 2. Idle 3. Run 4. Down 5. Maintain 机台状态
        /// </summary>
        public const string MachineState = "MachineState";
        /// <summary>
        /// 设备循环周期
        /// </summary>
        public const string MachineCycleTime = "MachineCycleTime";
        /// <summary>
        /// 设备OK计数
        /// </summary>
        public const string CountOK = "CountOK";
        /// <summary>
        /// 设备NG计数
        /// </summary>
        public const string CountNG = "CountNG";
        /// <summary>
        /// 事件触发ID  （bool数组）根据索引 值TRUE 为触发一个事件   例：Link_Comp事件触发 将数组第0位置TRUE
        /// </summary>
        public const string EventTrigger = "EventTrigger";
        /// <summary>
        /// 每一个Bit位表示报警
        /// </summary>
        public const string AlarmCode = "AlarmCode";

        /// <summary>
        /// 心跳事件的数据存储区首地址，EAP一直写1，PLC清除后判断
        /// </summary>
        public const string HeartBeatAddress = "HeartBeatAddress";

        /// <summary>
        /// EAP控制设备（[0:Stop, 1:StandBy, 2:Run, 3:Reset]）
        /// </summary>
        public const string Command = "Command";
        #endregion

        #region[事件触发项]
        public const string SequenceID = "SequenceID";
        /// <summary>
        /// 写入PLC时间处理结果 1 pass  2 fail
        /// </summary>
        public const string ResultCode = "ResultCode";
        /// <summary>
        /// plc上传的数据  进站1 出站2
        /// </summary>
        public const string InOutState = "In/OutState";


        /// <summary>
        /// 打码等级
        /// </summary>
        public const string ACK = "ACK";

        /// <summary>
        /// 产品码
        /// </summary>
        public const string ProCode = "ProCode";


        /// <summary>
        /// 电测数据
        /// </summary>
        public const string DetectData = "DetectData";


        public const string NextStation = "NextStation";

        #endregion


    }
    public static class FileName
    {
        /// <summary>
        /// plc变量地址表
        /// </summary>
        public const string PlcAddress_CSV = "Config.csv";
        /// <summary>
        /// 配置文件XML
        /// </summary>
        public const string MESHttp_XML = "HttpConfig.xml";
    }



    public  class Debug
    {
        /// <summary>
        /// 调试  （TRUR 调试阶段  ）
        /// </summary>
        public static bool Trigger { get; set; } = true;


        public static bool ReadWritePdf { get; set; }=false;
    }
}
