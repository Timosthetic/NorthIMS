using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Dto;
using Infrastructure.Dto.Login;
using Infrastructure.Dto.NewDto;
using Infrastructure.Event;
using Infrastructure.Helper;
using Infrastructure.Helper.ConnectToPlc;
using Infrastructure.Helper.ConnectToSerilaPort;
using Infrastructure.Service;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Serilog;

namespace Infrastructure.DialogHelper.Login
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        
     private readonly ILoginService _loginService;
        private readonly IRegionManager _regionManager;
        IEventAggregator _ea;
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();


        public LoginViewModel(ILoginService login, IEventAggregator ea, IRegionManager regionManager)
        {
            _regionManager=regionManager;
          
            _loginService=login;

            _ea = ea;
            UserNumber = ConfigurationHelper.ReadSetting("UserNum");

        }
       


        bool Result;
        private DelegateCommand _ExecuteCommand;
        /// <summary>
        /// 登录
        /// </summary>
        public DelegateCommand ExecuteCommand => _ExecuteCommand ?? (_ExecuteCommand = new DelegateCommand( async() =>
        {

           
                if (string.IsNullOrEmpty(UserNumber) || string.IsNullOrEmpty(PassWord)) { return; }

           await Task.Run( () =>
            {

                try
                {
                    // AppDbContext.CreateTable(false, 50, typeof(StaffLogin), typeof(dt_Trace_Track), typeof(DeviceStopDate), typeof(kanBan_WorkingHours));
                  // AppDbContext.CreateTable(false, 50, typeof(WMS_TaskQueues));


                    AppDbContext.Db.Open();

                  
                    Result = true;
                }
                catch (Exception ex)
                {
                    Result= false;
                    BoundMessageQueue.Enqueue(ex.ToString());
                }
               
               
            });

            if (Result)
            {

               
               

                var res = await _loginService.Logion(UserNumber, PassWord);

                if (res.Status)
                {

                    var Info = (User)res.Result;
                   
                   
                    ConfigurationHelper.AddUpdateAppSettings("UserNum", UserNumber);
                    ConfigurationHelper.AddUpdateAppSettings("UserName", Info.姓名);
                      ConfigurationHelper.AddUpdateAppSettings("Permission", SelectIndex.ToString()); 

                    GetUserInfo();
                    RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                   
                 
                }
                else
                {
                    BoundMessageQueue.Enqueue(res.Message.ToString());
                }
            }
           

           
                

          
        }));

        private void GetUserInfo()
        {

            Log.Error($"{Thread.CurrentThread.ManagedThreadId}--{SelectIndex}");
            switch (SelectIndex)
            {
                case 0:
                    _regionManager.RequestNavigate("CentterRegionPermission", "AssemblerView");
                    break;
                case 1:

                    _regionManager.RequestNavigate("CentterRegionPermission", "MainFeederView");
                    _regionManager.RegisterViewWithRegion("FeederContentRegion", "RealTimeStationView");
                    break;
                case 2:
                    _regionManager.RequestNavigate("CentterRegionPermission", "AdministratorView");
                    break;
                default:
                    break;
            }

        }

        #region Files


   


        private string _userNumber;
        /// <summary>
        /// 
        /// </summary>
        public string UserNumber
        {
            get { return _userNumber; }
            set { SetProperty(ref _userNumber, value); }
        }
        private string _passWord="1234";
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }
        }
        private int _selectIndex=Convert.ToInt32(ConfigurationHelper.ReadSetting("Permission"));
        /// <summary>
        /// 权限选项
        /// </summary>
        public int SelectIndex
        {
            get { return _selectIndex; }
            set { SetProperty(ref _selectIndex, value); }
        }

        #endregion
        #region DialogConfig
        public string Title { get; set; } = "Kstopa";

        public event Action<IDialogResult> RequestClose;
       
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
        void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
        #endregion

    }
}
