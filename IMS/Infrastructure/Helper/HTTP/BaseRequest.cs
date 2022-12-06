using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper.HTTP
{
  public   class BaseRequest
    {
        /// <summary>
        /// 路由
        /// </summary>
        public Method Method { get; set; }
        public string Route { get; set; }

        public string ContentType { get; set; }
        public object Parameter { get; set; }
    }
}
