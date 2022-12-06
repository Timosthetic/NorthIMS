using Infrastructure.DialogHelper;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace Infrastructure.Extensions
{
  public static  class DialogExtensions
    {
        /// <summary>
        /// 询问窗口
        /// </summary>
        /// <param name="dialogHost">制定的Dialoghost会话主机</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="dialogHostName">会话主机名称   dialoghost背景区域</param>
        /// <returns></returns>
        public static async Task<IDialogResult>Question(this IDialogHostService dialogHost,string title,string content,string dialogHostName = "Root")
        {
            DialogParameters param = new DialogParameters();
            param.Add("Title", title);
            param.Add("Content", content);

            param.Add("dialogHostName", dialogHostName);
          var dialogResult=  await dialogHost.ShowDialog("MsgView", param, dialogHostName);
            return dialogResult;
        }
       
    }
}
