using FeederProject.Models;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Mvvm;

namespace FeederProject.ViewModels
{
    public  class MainFeederViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
        public MainFeederViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CreatItems();
        }


        private void CreatItems()
        {

            leftMenus = new ObservableCollection<LeftMenu>();
            leftMenus.Add(new LeftMenu("上料操作", PackIconKind.AccountArrowUp, "FeederView", MenuIte.Feeder));

            leftMenus.Add(new LeftMenu("实时流转状态", PackIconKind.MapClock, "RealTimeStationView", MenuIte.PlcEvent));
            //leftMenus.Add(new LeftMenu("实时生产状态", PackIconKind.MapClock, "RealTimeProductionView", MenuIte.PlcEvent));
           // leftMenus.Add(new LeftMenu("仿真", PackIconKind.MapClock, "SimulationView", MenuIte.PlcEvent));
            leftMenus.Add(new LeftMenu("缓存库信息", PackIconKind.MapClock, "RealTimeWMSView", MenuIte.PlcEvent));


        }
        private string _Title;
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        private PackIconKind _icon = PackIconKind.ArrowCollapseLeft;
        /// <summary>
        /// 
        /// </summary>
        public PackIconKind Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }
        private string _with = "1.3*";
        /// <summary>
        /// 
        /// </summary>
        public string With
        {
            get { return _with; }
            set { SetProperty(ref _with, value); }
        }

        private DelegateCommand<object> _openMenuCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> OpenMenuCommand => _openMenuCommand ?? (_openMenuCommand = new DelegateCommand<object>(OpenMenu));
        private void OpenMenu(object parameter)
        {
            if (parameter == null) return;
            var res = parameter as string;
            if (res == "O")
            {
                With = "1.3*";
                Icon = PackIconKind.ArrowCollapseLeft;
            }
            else if (res == "C")
            {
                With = "0";
                Icon = PackIconKind.ArrowExpandAll;
            }
        }

        public ObservableCollection<LeftMenu> leftMenus { get; private set; }


        private DelegateCommand<LeftMenu> _NavigationRegionCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<LeftMenu> NavigationRegionCommand => _NavigationRegionCommand ?? (_NavigationRegionCommand = new DelegateCommand<LeftMenu>(Navigation));
        private void Navigation(LeftMenu parameter)
        {
            if (parameter != null)
            {
                Title = parameter.Name;
                _regionManager.RequestNavigate("FeederContentRegion", parameter.RegionControl);
            }
        }
        private DelegateCommand _LoginLoadingCommand;
        /// <summary>
        /// 初始化加载页面
        /// </summary>
        public DelegateCommand LoginLoadingCommand => _LoginLoadingCommand ?? (_LoginLoadingCommand = new DelegateCommand(() =>
        {
            Title = leftMenus[0].Name;
            _regionManager.RequestNavigate("FeederContentRegion", leftMenus[0].RegionControl);
        }));



    }
}
