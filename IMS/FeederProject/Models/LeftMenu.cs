using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MaterialDesignThemes.Wpf;

namespace FeederProject.Models
{
    public class LeftMenu : INotifyPropertyChanged
    {
        public LeftMenu(string name, PackIconKind icon, string regionControl, MenuIte rootNode)
        {
            _name = name;
            _regionControl = regionControl;
            _rootNode = EnumHelper.GetEnumDescription(rootNode);
            _icon = icon;
        }
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private PackIconKind _icon;

        public PackIconKind Icon
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(); }
        }

        private string _regionControl;

        public string RegionControl
        {
            get { return _regionControl; }
            set { _regionControl = value; OnPropertyChanged(); }
        }
        private string _rootNode;

        public string RootNode
        {
            get { return _rootNode; }
            set { _rootNode = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
