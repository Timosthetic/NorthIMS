using DataVisualization.Views;
using Infrastructure.Helper;
using Prism.Ioc;
using System.Windows;

namespace DataVisualization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        private static readonly object _syncRoot = new object();
        private static System.Threading.Mutex _mutex;
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

           
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjUyMTQyQDMyMzAyZTMxMmUzMFBuSjdpUTZWU3g4MjVpalNJYUE0eGhmeG1FR0t6TUdNTXg2OXRVcXZGQzQ9");
            _mutex = new System.Threading.Mutex(true, "Only");
            if (_mutex.WaitOne(0, false))
            {
                base.OnStartup(e);
            }
            else
            {
                MessageBox.Show("程序已启动,请勿重复启动", "提示");
                this.Shutdown();

            }
         
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void OnInitialized()
        {
            try
            {
              //  MessageBox.Show("程序加载中......");
                SqlDbContext.Db.Open();
               // MessageBox.Show("程序加载成功");
              

                base.OnInitialized();
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
            
        }
        protected override void OnExit(ExitEventArgs e)
        {
            SqlDbContext.Db.Dispose();
            base.OnExit(e);
        }
    }
}
