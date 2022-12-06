using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper.HTTP
{
  public   class ApiResponse<T>
    {
        /// <summary>
        /// /错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        public ApiResponse(string message,bool status=false)
        {
            this.Message = message;
            this.Status = status;
        }
        /// <summary>
        /// 返回 
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="result">结果</param>
        public ApiResponse(bool status,object result)
        {
            this.Status = status;
            this.Result = result;
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 状态  表示是否返回成功
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public object Result { get; set; }
    }
}
