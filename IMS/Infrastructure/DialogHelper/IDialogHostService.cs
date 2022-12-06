using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DialogHelper
{
   public  interface IDialogHostService:IDialogService
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="name">模块名</param>
       /// <param name="parameters"></param>
       /// <param name="dialogHostName"></param>
       /// <returns></returns>
        Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "Root");
    }
}
