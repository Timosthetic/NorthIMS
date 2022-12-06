using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using System.Windows.Controls;
using System.Text;
using Serilog.Sinks.RichTextBox.Themes;
using Serilog.Events;
using Serilog.Core;
using System.Threading;
using Serilog.Debugging;
using System.Diagnostics;
using Infrastructure.DialogHelper;
using AutoMapper;
using Infrastructure.Extensions;
using IMS.Views;
using HslCommunication;
using SqlSugar;
using Infrastructure.Helper;
using Infrastructure.DialogHelper.Login;
using Prism.Services.Dialogs;
using System;
using Infrastructure.Helper.ConnectToPlc;
using Infrastructure.Dto.Login;
using IMS.Views.AdminViews;
using IMS.ViewModels.AdminViewModels;
using IMS.ViewModels;
using Infrastructure.DialogHelper.DatePicker;
using IMS.Views.DialogViews;
using IMS.ViewModels.DialogViewModels;
using FeederProject;


namespace IMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
      
        public App()
        {
            
        }
        private static readonly object _syncRoot = new object();
        private static System.Threading.Mutex _mutex;
        protected override Window CreateShell()
        {

            return Container.Resolve<MainWindow>();
        }
        public static void LoginOut(IContainerProvider containerProvider)
        {
            Current.MainWindow.Hide();

            var dialog = containerProvider.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }

                Current.MainWindow.Show();
            });
        }
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    
                    Environment.Exit(0);
                    return;
                }
               
               
                base.OnInitialized();
            });
        }
        protected  override void OnStartup(StartupEventArgs e)
        {
            
            Authorization.SetAuthorizationCode("a6ffdfde-48bd-4684-b37b-5c2fe7c2e4c6");
            Syncfusion.SfSkinManager.SfSkinManager.ApplyStylesOnApplication = true;
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjUyMTQyQDMyMzAyZTMxMmUzMFBuSjdpUTZWU3g4MjVpalNJYUE0eGhmeG1FR0t6TUdNTXg2OXRVcXZGQzQ9");
            _mutex = new System.Threading.Mutex(true, "Only");
            if (_mutex.WaitOne(0, false) )
            {
               base.OnStartup(e);
            }
            else
            {
                MessageBox.Show("程序已启动,请勿重复启动", "提示");
                this.Shutdown();

            }
            MainWindow current = (MainWindow)App.Current.Windows[0];
            const string outputTemplate = "----[{Timestamp: yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{Exception}{NewLine}";

            SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Async(a => a.File("Logs/Log.log", outputTemplate: outputTemplate
                    , rollingInterval: RollingInterval.Day
                   
                    , retainedFileCountLimit: 10
                    ))
                .Enrich.With(new ThreadIdEnricher())
                //.WriteTo.Async(a => a.RichTextBox(current._richTextBox, Serilog.Events.LogEventLevel.Debug, syncRoot: _syncRoot, outputTemplate: outputTemplate, theme: RichTextBoxConsoleTheme.None))
                .CreateLogger();
        }
        protected override void OnExit(ExitEventArgs e)
        {

            //ConToPlc.DisposeToPlc(ConnectionType.Simens);
            AppDbContext.Db.Dispose();
            Log.CloseAndFlush();
            base.OnExit(e);
        }
    


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
            containerRegistry.Register<IDialogHostService, DialogHostService>();
            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IBaseService, BaseService>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<DataPickerView, DataPickerViewModel>();

            containerRegistry.RegisterForNavigation<MsgView, MsgViewModel>();


            containerRegistry.RegisterForNavigation<AdministratorView>();
            containerRegistry.RegisterForNavigation<AssemblerView, AssemblerViewModel>();
           

            containerRegistry.RegisterForNavigation<PrcCraftTabView, PrcCraftTabViewModel>();
            containerRegistry.RegisterForNavigation<WorkstationConfigView, WorkstationConfigViewModel>();
            containerRegistry.RegisterForNavigation<BoomInquiryView, BoomInquiryViewModel>();
            containerRegistry.RegisterForNavigation<BoomUploadView, BoomUploadViewModel>();
            containerRegistry.RegisterForNavigation<WorkerOrderView, WorkerOrderViewModel>(); 
            containerRegistry.RegisterForNavigation<ProcessConfigView, ProcessConfigViewModel>();
            containerRegistry.RegisterForNavigation<StaffMangeView  , StaffMangeViewModel>();
            containerRegistry.RegisterForNavigation<AlarmView,AlarmViewModel>();
            containerRegistry.RegisterForNavigation<DatenverfolgungView, DatenverfolgungViewModel>();
            containerRegistry.RegisterForNavigation<ProcessCraftView, ProcessCraftViewModel>();

            containerRegistry.RegisterForNavigation<StationFlowLableNewView, StationFlowLableNewViewModel>();
            //注册dialog
            containerRegistry.RegisterForNavigation<AddProcessDialogView, AddProcessDialogViewModel>();
            containerRegistry.RegisterForNavigation<WorkOrderDialogView, WorkOrderDialogViewModel>();
            containerRegistry.RegisterForNavigation<AUProcessConfigView, AUProcessConfigViewModel>();
            containerRegistry.RegisterForNavigation<EditProcessDialogView, EditProcessDialogViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {

          //  moduleCatalog.AddModule<WarehouseClerkModule>();
            moduleCatalog.AddModule<FeederProjectModule>();

        }


    }
    class ThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }
}
