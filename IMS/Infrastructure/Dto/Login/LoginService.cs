using Infrastructure.Helper;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto.Login
{
    public class LoginService : ILoginService
    {
        public async Task<ApiResponse> Logion(string userNumber, string passWord)
        {
            try
            {
                var res = await AppDbContext.Db.Queryable<User>().Where(x => x.员工号 == userNumber && x.密码 == passWord).FirstAsync();
                if(res!= null)
                {
                    return new ApiResponse(true, res);
                }
                else
                {
                    return new ApiResponse("登录失败：账号或密码错误");
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse($"登录失败原因:{ex.ToString()}");
            }
        }
    }
}
