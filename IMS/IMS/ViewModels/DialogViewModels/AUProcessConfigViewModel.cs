using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Dto.NewDto;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.ViewModels.DialogViewModels
{
    public class AUProcessConfigViewModel : BindableBase, IDialogHostAware
    {

        public AUProcessConfigViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
           
        }
        #region Files
        private Io_prc_product _pross;
        /// <summary>
        /// 
        /// </summary>
        public Io_prc_product Pross
        {
            get { return _pross; }
            set { SetProperty(ref _pross, value); }
        }
      



      
      
        #endregion

        #region Command

        private DelegateCommand _GetSopFileCommand;
        /// <summary>
        /// 获取sop路径
        /// </summary>
        public DelegateCommand GetSopFileCommand => _GetSopFileCommand ?? (_GetSopFileCommand = new DelegateCommand(() =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.FilterIndex = 1;

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }
            Pross.Esop = openFileDialog.FileName.Replace("\\", "\\\\");
        }));
        #endregion


        #region Dialog

        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (!DialogHost.IsDialogOpen(DialogHostName)) return;
            DialogParameters param = new DialogParameters();

       
        
            if (!string.IsNullOrEmpty(Pross.NodeName) &&!string.IsNullOrEmpty(Pross.Esop)
                && Pross.CT!=0)
                
            {
              
                param.Add("UpdateValue1", Pross);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
            else
            {

            }

        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {

            Pross = parameters.ContainsKey("UpdateValue1") ? parameters.GetValue<Io_prc_product>("UpdateValue1") : new Io_prc_product();
            //Prc_Standard = parameters.ContainsKey("Prc_Standard") ? parameters.GetValue<Io_prc_standard>("Prc_Standard") : new Io_prc_standard();
        }
        #endregion

    }
}
