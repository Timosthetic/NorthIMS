
using Infrastructure.Dto.NewDto;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Login
{
    public interface IBaseService
    {

        /// <summary>
        /// 报警数据查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<ApiResponse> GetAlarm(DateTime start, DateTime end);



        #region 载具绑定信息部分
        /// <summary>
        /// 获取此载具的绑定信息
        /// </summary>
        /// <param name="velInfo">载具Code</param>
        /// <returns></returns>
        Task<ApiResponse> GetVelBingAsync(string velInfo);

        /// <summary>
        /// 更新载具绑定信息
        /// </summary>
        /// <param name="io_Vehicles_Bing"></param>
        /// <returns></returns>
        Task<ApiResponse> UpdateVelBingAsync(Io_Vehicles_Bing io_Vehicles_Bing);    
        #endregion
    }
}
