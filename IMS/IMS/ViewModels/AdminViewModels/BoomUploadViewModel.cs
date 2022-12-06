using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Linq;
using Infrastructure.Dto;
using Infrastructure.Helper;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using static System.Net.Mime.MediaTypeNames;
using Infrastructure.DealWithFile;
using MaterialDesignThemes.Wpf;
using Serilog;
using Prism.Events;
using Infrastructure.Event;
using Infrastructure.DialogHelper;
using Prism.Ioc;
using Infrastructure.Extensions;
using LibExcel;

namespace IMS.ViewModels.AdminViewModels
{
    public class BoomUploadViewModel: BindableBase
    {
        private readonly IDialogHostService _dialogHostService;
        public BoomUploadViewModel(IContainerExtension container)
        {
            _dialogHostService = container.Resolve<IDialogHostService>();
            Booms = new List<Boom>();
         

        }

     
        private string _FileName;
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _FileName; }
            set { SetProperty(ref _FileName, value); }
        }
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();
        public List<Boom> Booms { get; set; }
        private ObservableCollection<Boom> _boomList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Boom> BoomList
        {
            get { return _boomList; }
            set { SetProperty(ref _boomList, value); }
        }
        private DelegateCommand<string> _ExceteCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> ExceteCommand => _ExceteCommand ?? (_ExceteCommand = new DelegateCommand<string>(Excete));
        private async void Excete(string parameter)
        {
            if(parameter== "ChoseFile")
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                   
                    openFileDialog.Filter = @"XLS文件|*.xls";
                   
                    openFileDialog.FilterIndex = 1;
                   
                    openFileDialog.RestoreDirectory = true;
                    FileName = openFileDialog.FileName;
                    if (openFileDialog.ShowDialog() == false)
                    {
                        return;
                    }
                    FileName = openFileDialog.FileName;
                    if (DwFile.IsFileOpened(openFileDialog.FileName))
                    {
                        BoundMessageQueue.Enqueue("Excel文件处于打开状态");
                    }
                    else
                    {
                        
                        LibExcel.ExcelHelper excelhelper = new LibExcel.ExcelHelper(openFileDialog.FileName);
                        DataTable dt = excelhelper.ExcelToDataTable(null, true);
                        if (dt == null) return;
                        DataTable dtNoEmpty=   LibExcel.ExcelHelper.removeEmpty(dt);
                        Booms = LibExcel.ExcelHelper.GetList<Boom>(dtNoEmpty);
                        BoomList = new ObservableCollection<Boom>(Booms);
                    }
                   
                }
                catch (Exception ex)
                {
                    BoundMessageQueue.Enqueue($"获取BOOM数据失败：原因{ex.Message}");
                    Log.Error($"获取BOOM数据失败：原因{ex.Message}");
                }
               

                

            }
            else if(parameter== "Upload")
            {
                try
                {
                    if (Booms.Count > 0)
                    {

                        var proCode = AppDbContext.Db.Queryable<Boom>().Distinct().Select(x => new { x.母件编码 }).ToList();

                        var proCodeExcel = Booms.Select(x => x.母件编码).Distinct().ToList();
                      
                        var tinct=proCode.Where(x=>proCodeExcel.Exists(t=>x.母件编码.Contains(t))).ToList();
                        if (tinct.Count > 0)
                        {
                            string result = "";
                            foreach (var t in tinct)
                            {
                                result+=t.母件编码.ToString();
                            }
                            var dialogResult= await _dialogHostService.Question("温馨提示", $"已存在以下数据，是否进行覆盖:{result} ?");
                            if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                            else
                            {
                                foreach (var item in tinct)
                                {
                                    var res = Booms.Where(x=>x.母件编码==item.母件编码).ToList();
                                    AppDbContext.Db.Fastest<Boom>().BulkUpdate(res);
                                }
                               
                            }
                        }
                        else
                        {
                            AppDbContext.Db.Insertable(Booms).ExecuteCommand();
                            var dialogResult = await _dialogHostService.Question("温馨提示", $"上传成功");
                            if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                           
                        }

                    }
                   
                }
                catch ( Exception ex)
                {
                    BoundMessageQueue.Enqueue("要上传的BOM表内信息不完整，请完善BOM信息");
                    Log.Error($"上传BOOM数据失败：原因{ex.Message}");
                }
            }
            else if(parameter== "Empty")
            {
                try
                {
                    var dialogResult = await _dialogHostService.Question("温馨提示", $"是否要清空当前选择BOOM清单 ?");
                    if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                    else
                    {
                        BoomList.Clear();
                    }
                }
                catch (Exception ex)
                {

                    Log.Error($"清空BOOM数据失败：原因{ex.Message}");
                }
            }
        }


    }
}
