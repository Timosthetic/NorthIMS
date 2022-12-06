using IMS.Model;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Infrastructure.Event;
using Prism.Mvvm;

namespace IMS.ViewModels
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class AdministratorViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
        IEventAggregator _ea;
        public AdministratorViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            _regionManager = regionManager;
          
            CreatItems();
        }
        


        private void CreatItems()
        {

            leftMenus = new ObservableCollection<LeftMenu>();
            leftMenus.Add(new LeftMenu("BOM上传", PackIconKind.FolderUploadOutline, "BoomUploadView", MenuIte.Boom));

            leftMenus.Add(new LeftMenu("BOM查询", PackIconKind.FolderRefreshOutline, "BoomInquiryView", MenuIte.Boom));
            leftMenus.Add(new LeftMenu("人员信息管理", PackIconKind.FolderEditOutline, "StaffMangeView", MenuIte.Staff));
            leftMenus.Add(new LeftMenu("工单创建", PackIconKind.FolderPlusOutline, "WorkerOrderView", MenuIte.WorkOrder));
            leftMenus.Add(new LeftMenu("产品工序", PackIconKind.FolderPoundOutline, "ProcessConfigView", MenuIte.Formula));
            leftMenus.Add(new LeftMenu("产品工艺", PackIconKind.FolderPoundOutline, "ProcessCraftView", MenuIte.Formula));
            leftMenus.Add(new LeftMenu("标签打印", PackIconKind.FolderCogOutline, "StationFlowLableNewView", MenuIte.CodeLable));
          //  leftMenus.Add(new LeftMenu("标签打印", PackIconKind.FolderCogOutline, "StationFlowLableView", MenuIte.CodeLable));
            leftMenus.Add(new LeftMenu("数据追踪追溯", PackIconKind.FolderSearchOutline, "DatenverfolgungView", MenuIte.CodeLable));

            
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
        private string _with="1.3*";
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
            else if(res == "C")
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
            if(parameter!= null)
            {
                _regionManager.Regions["ContentRegion"].RemoveAll();
                Title = parameter.Name;
                _regionManager.RequestNavigate("ContentRegion", parameter.RegionControl);
            }
        }
        private DelegateCommand _LoginLoadingCommand;
        /// <summary>
        /// 初始化加载页面
        /// </summary>
        public DelegateCommand LoginLoadingCommand => _LoginLoadingCommand ?? (_LoginLoadingCommand = new DelegateCommand(() =>
        {
            Title = leftMenus[0].Name;
            _regionManager.RequestNavigate("ContentRegion", leftMenus[0].RegionControl);
        }));



    }
}
