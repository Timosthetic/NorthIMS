using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DialogHelper.DatePicker
{
    public class DataPickerViewModel : BindableBase, IDialogHostAware
    {
        public DataPickerViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

      

        #region [Files]
        private DateTime _dateTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }

        #endregion

        #region Command
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (!DialogHost.IsDialogOpen(DialogHostName)) return;
            DialogParameters param = new DialogParameters();
            param.Add("Value", DateTime);
            DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
        }
        #endregion
        public string DialogHostName { get; set; } = "Root";
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpend(IDialogParameters parameters)
        {
          
        }
    }
}
