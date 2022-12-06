using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;


namespace Infrastructure.Helper.HTTP
{
    public class HttpRestClent
    {
        private readonly string _apiUrl;
        private readonly RestClient _client;
        public HttpRestClent(string apiUrl)
        {
            _apiUrl = apiUrl;
            _client = new RestClient();
        }
        //public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        //{
        //    var request = new RestRequest(baseRequest.Method);
        //    request.AddHeader("Content-Type", baseRequest.ContentType);
        //    if (baseRequest.Parameter != null)
        //    request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
        //    _client.BaseUrl = new Uri(_apiUrl + baseRequest.Route);
        //    var response = await _client.ExecuteAsync(request);
        //    return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        //}
        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Method);
        request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter != null)
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            _client.BaseUrl = new Uri(_apiUrl + baseRequest.Route);
        var response = await _client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
        }
}
}
