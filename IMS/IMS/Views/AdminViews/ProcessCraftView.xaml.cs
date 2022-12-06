using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMS.Views.AdminViews
{
    /// <summary>
    /// ProcessCraftView.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessCraftView : UserControl
    {
        private readonly IRegionManager regionManager;

        public ProcessCraftView(IRegionManager regionManager)
        {

            InitializeComponent();
            this.regionManager = regionManager;
        }

        private void _tabcontrol_OnCloseButtonClick(object sender, Syncfusion.Windows.Tools.Controls.CloseTabEventArgs e)
        {
            regionManager.Regions["PersonDetailsRegion"].Remove(e.TargetTabItem.Content);
        }
    }
}
