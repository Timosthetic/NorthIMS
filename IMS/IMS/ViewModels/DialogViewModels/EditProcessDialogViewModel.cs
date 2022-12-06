using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Ioc;
using Infrastructure.DialogHelper;
using Infrastructure.Helper;
using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using System.Windows;

namespace IMS.ViewModels.DialogViewModels
{
    public class EditProcessDialogViewModel : BindableBase, IDialogHostAware
    {
        public EditProcessDialogViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        

        private int _prcCraftNum;
        /// <summary>
        /// 工序齐套数量
        /// </summary>
        public int PrcCraftNum
        {
            get { return _prcCraftNum; }
            set { SetProperty(ref _prcCraftNum, value); }
        }


        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (!DialogHost.IsDialogOpen(DialogHostName)) return;
            DialogParameters param = new DialogParameters();
            if (Prc_Standard.Atprule != 0)
            {
                param.Add("Prc_Standard", Prc_Standard);
              

            }
            else
            {
                MessageBox.Show("请输入有效值");
            }

            DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
        }

        /// <summary>
        /// 工序配置
        /// </summary>
        private Io_prc_standard _Prc_Standard;
        /// <summary>
        /// 
        /// </summary>
        public Io_prc_standard Prc_Standard
        {
            get { return _Prc_Standard; }
            set { SetProperty(ref _Prc_Standard, value); }
        }



        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {
            Prc_Standard = parameters.ContainsKey("Prc_Standard") ? parameters.GetValue<Io_prc_standard>("Prc_Standard") : new Io_prc_standard();
        }
    }
}
