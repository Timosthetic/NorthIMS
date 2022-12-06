
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Login
{
    public interface ILoginService
    {
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="userNumber">员工账号</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        Task<ApiResponse> Logion(string  userNumber,string passWord);
    }
}
