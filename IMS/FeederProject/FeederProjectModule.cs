using FeederProject.ViewModels;
using FeederProject.ViewModels.HardWorkViewModel;
using FeederProject.ViewModels.HardWorkViewModel.SimulationDialogViewModel;
using FeederProject.Views;
using FeederProject.Views.HardWorkView;
using FeederProject.Views.HardWorkView.SimulationDialogView;
using Infrastructure.Dto.Login;
using Infrastructure.Helper;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Net;

namespace FeederProject
{
    public class FeederProjectModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("CentterRegionPermission", typeof(MainFeederView));
          
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

           if(GetStationName() == "IMS101")
            {
                containerRegistry.RegisterForNavigation<RealTimeStationView, RealTimeStationViewModel>();
            }
            else
            {
                containerRegistry.RegisterForNavigation<RealTimeStationView, RealTimeStation104ViewModel>();
                containerRegistry.RegisterForNavigation<RealTimeWMSView, RealTimeWMSViewModel>();
            }
           
            containerRegistry.RegisterForNavigation<FeederView, FeederViewModel>();
            containerRegistry.RegisterForNavigation<SimulationView, SimulationViewModel>();
            containerRegistry.RegisterForNavigation<Simu_UPView, Simu_UPViewModel>();
        
           // containerRegistry.RegisterForNavigation<RealTimeProductionView, RealTimeProductionViewModel>();
           //containerRegistry.RegisterForNavigation<RealTimeVehiclesBingView, RealTimeStation104ViewModel>();

           // containerRegistry.RegisterForNavigation<RealTimeWMSView, RealTimeWMSViewModel>();
            //注册服务
            containerRegistry.Register<IBaseService, BaseService>();
        }

        private string GetStationName()
        {
            //通过设备名称区分工位信息
            string str = Dns.GetHostName();
            if (str.Contains("IMS"))
            {
                return str;
            }
            else
            {
                return "";
            }

        }
    }
}