using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Infrastructure.Service;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Login
{
    public class BaseService : IBaseService
    {
     
            public async Task<ApiResponse> GetAlarm(DateTime start, DateTime end)
            {
                string startS = start.Date.ToString();
                string endS = end.Date.ToString("yyyy/MM/dd 23:59:59");
                object res;
                try
                {
                    if (start == end)
                    {
                        res = await AppDbContext.Db.Queryable<AlarmRecord>().Where(x => SqlFunc.Between(x.发生时间, startS, endS)).ToListAsync();
                    }
                    else
                    {
                        res = await AppDbContext.Db.Queryable<AlarmRecord>().Where(x => SqlFunc.Between(x.发生时间, start, end)).ToListAsync();
                    }
                    return new ApiResponse(true, res);
                }
                catch (Exception ex)
                {

                    return new ApiResponse("获取数据失败，原因:" + ex);
                }
            }



        #region 载具绑定信息实现
        public async Task<ApiResponse> GetVelBingAsync(string velInfo)
        {
           
            try
            {
              var res=  await AppDbContext.Db.Queryable<Io_Vehicles_Bing>().Where(x => x.vh_code == velInfo).FirstAsync();
                return new ApiResponse(true,res);
            }
            catch (Exception ex)
            {

                return new ApiResponse("获取数据失败，原因:" + ex);
            }
          
        }

        public async Task<ApiResponse> UpdateVelBingAsync(Io_Vehicles_Bing io_Vehicles_Bing)
        {
            try
            {
                var res = await AppDbContext.Db.Updateable(io_Vehicles_Bing).ExecuteCommandAsync();
                return new ApiResponse(true, res);
            }
            catch (Exception ex)
            {

                return new ApiResponse("获取数据失败，原因:" + ex);
            }
        }

        #endregion

    }
}
