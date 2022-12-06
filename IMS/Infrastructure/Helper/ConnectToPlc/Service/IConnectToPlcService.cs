using HslCommunication.Profinet.Siemens;
using Infrastructure.Helper.HTTP;
using Infrastructure.Service;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper.ConnectToPlc.Service
{
    public interface IConnectToPlcService
    {
        Task<ApiResponse> ConToPlcAsync(string ip, int port, SiemensPLCS siemensPLCS = SiemensPLCS.S1500);



      
    }
}
