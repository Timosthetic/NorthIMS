using System;
using System.Collections.Generic;
using System.Text;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Infrastructure.DialogHelper
{
   public  class MsgViewModel:BindableBase, IDialogHostAware
    {
        public MsgViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }
        #region[Files]
        private string _title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _content;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        #endregion
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.No));
        }

        private void Save()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters param = new DialogParameters();
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
        }

        public string DialogHostName { get; set; } = "Root";
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpend(IDialogParameters parameters)
        {
            if(parameters.ContainsKey("Title"))
            Title = parameters.GetValue<string>("Title");
            if (parameters.ContainsKey("Content"))
                Content = parameters.GetValue<string>("Content");
        }
    }
}
