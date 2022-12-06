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

namespace IMS.ViewModels.DialogViewModels
{
    public class AddProcessDialogViewModel : BindableBase, IDialogHostAware
    {
        
        public SnackbarMessageQueue BoundMessageQueue { get; } = new SnackbarMessageQueue();
        public AddProcessDialogViewModel()
        {
           
         
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
          
        
        }


        private Io_pro_CompleteSet _craftItem;
        /// <summary>
        /// 产品齐套
        /// </summary>
        public Io_pro_CompleteSet CraftItem
        {
            get { return _craftItem; }
            set { SetProperty(ref _craftItem, value); }
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
            if(PrcCraftNum<= CraftItem.mal_lastnum)
            {
               

                Prc_Standard = new Io_prc_standard()
                {
                    Materiel = CraftItem.mal_code,
                    MtiName = CraftItem.mal_name,
                    MtiClass = CraftItem.mal_type,
                    Atprule = PrcCraftNum,
                   
                };
                param.Add("Prc_Standard", Prc_Standard);
                CraftItem.mal_lastnum -=PrcCraftNum;
                AppDbContext.Db.Updateable(CraftItem).ExecuteCommand();
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
            else
            {
                BoundMessageQueue.Enqueue("剩余的齐套数量小于配置的齐套数量");
            }
        }
        /// <summary>
        /// 工序配置
        /// </summary>
        public Io_prc_standard Prc_Standard { get; set; }


        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public void OnDialogOpend(IDialogParameters parameters)
        {

            CraftItem = parameters.ContainsKey("Value") ? parameters.GetValue<Io_pro_CompleteSet>("Value") : new Io_pro_CompleteSet();
            Prc_Standard = parameters.ContainsKey("Prc_Standard") ? parameters.GetValue<Io_prc_standard>("Prc_Standard") : new Io_prc_standard();
        }
    }
}
