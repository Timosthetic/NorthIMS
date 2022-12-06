using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Windows;
using IMS.StyleControl;
using Infrastructure.Helper.ConnectToPlc;
using Infrastructure.DialogHelper.Login;
using MaterialDesignThemes.Wpf;
using Infrastructure.DialogHelper;
using Prism.Ioc;
using Prism.Events;
using Infrastructure.Event;
using Prism.Regions;
using System.Threading.Tasks;
using Infrastructure.Helper;
using Prism.Modularity;
using Infrastructure.Dto.NewDto;
using Serilog;
using System.Net;

namespace IMS.ViewModels
{
    public class MainWindowViewModel : BindableBase, ICloseWindows, IConfigureService
    {
        private readonly IDialogHostService _dialogHostService;
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;
      
        IEventAggregator _ea;
       
        public MainWindowViewModel(IContainerExtension container, IModuleManager moduleManager, IContainerProvider containerProvider, IEventAggregator ea, IRegionManager regionManager)
        {
           
            _dialogHostService = container.Resolve<IDialogHostService>();
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            _ea=ea;
            Task.Run(async () =>
            {
                while (true)
                {
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    await Task.Delay(1000);
                }
            });
            try
            {
                if (!string.IsNullOrEmpty(GetStationName()))
                {
                    Station =  GetStationName();
                }
            }
            catch (Exception ex)
            {

                Log.Error($"获取硬件工位信息失败，原因：{ex.Message}");
            }

        }
        private string Station;

        private string GetStationName()
        {
            //通过设备名称区分工位信息
            string str = Dns.GetHostName();
            if (str.Contains("ST"))
            {
                return str;
            }
            else
            {
                return "";
            }

        }


        private string _Version="IMS_V1.1.2-分配RGV任务前判断目标工位是否已经占位";
        /// <summary>
        /// 
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { SetProperty(ref _Version, value); }
        }

        private string _time;
        /// <summary>
        /// 
        /// </summary>
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

       



        private DelegateCommand _LoginOutCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand LoginOutCommand => _LoginOutCommand ?? (_LoginOutCommand = new DelegateCommand(() =>
        {
           
            App.LoginOut(_containerProvider);
            _regionManager.RequestNavigate("CentterRegionPermission", "");
        }));


        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private DelegateCommand<string> _windowBtnCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> WindowBtnCommand => _windowBtnCommand ?? (_windowBtnCommand = new DelegateCommand<string>(WindowBtn));
        private void WindowBtn(string parameter)
        {


            switch (parameter)
            {
                case "Max":
                    Max();
                    break;
                case "Min":
                    MinWindow?.Invoke();
                    break;
                case "Clo":
                    CloseProject();
                    break;
                case "Nol":
                    Nol();
                    break;
                default:
                    break;

            }
        }


        private void CloseProject()
        {
            if (MessageBox.Show("是否要关闭系统程序？", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
              var res=  AppDbContext.Db.Queryable<StaffLogin>().Where(x => x.Station == Station).First();
                if(res != null)
                {
                    res.IsLogin=false;
                    res.StaffName = "";
                    res.StaffNum = "";
                    res.ProcessName = "";
                    res.ProductName = "";
                    res.ProcessStatus = false;
                    AppDbContext.Db.Updateable(res).ExecuteCommandAsync();
                }
                Close?.Invoke(); 
            }
            else
            {
                ;

            }
           
        }
        private DelegateCommand _ShowCommand;
        /// <summary>
        /// 
        /// </summary>
        public  DelegateCommand ShowCommand => _ShowCommand ?? (_ShowCommand = new DelegateCommand(async () =>
        {
            var resDialog = await _dialogHostService.ShowDialog("LoginView", null);
        }));


        private PackIconKind _icon=PackIconKind.WindowRestore;
        /// <summary>
        /// 
        /// </summary>
        public PackIconKind Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }



        private void Nol()
        {
            NolWindow?.Invoke();
            Icon = PackIconKind.WindowMaximize;
            
        }

        private void Max()
        {

            MaxWindow?.Invoke();
            Icon = PackIconKind.WindowRestore;

        }

        private Visibility _maxVis = Visibility.Visible;
        /// <summary>
        /// 最大化
        /// </summary>
        public Visibility MaxVis
        {
            get { return _maxVis; }
            set { SetProperty(ref _maxVis, value); }
        }

        private Visibility _nolVis = Visibility.Collapsed;



        /// <summary>
        /// 初始状态
        /// </summary>
        public Visibility NolVis
        {
            get { return _nolVis; }
            set { SetProperty(ref _nolVis, value); }
        }

        public Action Close { get; set; }
        public Action MinWindow { get; set; }
        public Action MaxWindow { get; set; }
        public Action NolWindow { get; set; }

        public bool CanClose()
        {
            return true;
        }

        public void Configure()
        {
           
        }
    }
}
