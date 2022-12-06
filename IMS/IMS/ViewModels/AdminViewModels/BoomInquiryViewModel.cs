using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Threading;
using Infrastructure.Dto;
using Infrastructure.Helper;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.ViewModels.AdminViewModels
{
    public class BoomInquiryViewModel : BindableBase
    {
        public BoomInquiryViewModel()
        {
           
            var proCodeRes= AppDbContext.Db.Queryable<Boom>().Distinct().Select(it => it.母件编码).ToList();
            var ChildproCodeRes = AppDbContext.Db.Queryable<Boom>().Distinct().Select(it => it.子件编码).ToList();

            var booms = AppDbContext.Db.Queryable<Boom>().ToList();
            ProCode = new ObservableCollection<string>((List<string>)proCodeRes);
            ChildProCode=new ObservableCollection<string>((List<string>)ChildproCodeRes);
            BoomList = new ObservableCollection<Boom>(booms);

        }

        #region Files

        private bool _IsBusy;
        /// <summary>
        /// 
        /// </summary>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }

        private ObservableCollection<Boom> _boomList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Boom> BoomList
        {
            get { return _boomList; }
            set { SetProperty(ref _boomList, value); }
        }


        private ObservableCollection<string> _proCode;
        /// <summary>
        /// 母件编码
        /// </summary>
        public ObservableCollection<string> ProCode
        {
            get { return _proCode; }
            set { SetProperty(ref _proCode, value); }
        }
        private ObservableCollection<string> _ChildProCode;
        /// <summary>
        /// 子件编码
        /// </summary>
        public ObservableCollection<string> ChildProCode
        {
            get { return _ChildProCode; }
            set { SetProperty(ref _ChildProCode, value); }
        }

        #endregion

        private DelegateCommand<string> _ExceteCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> ExceteCommand => _ExceteCommand ?? (_ExceteCommand = new DelegateCommand<string>(Excete));
        private void Excete(string parameter)
        {

            if(parameter=="Quiry")
            {
                var booms = AppDbContext.Db.Queryable<Boom>().ToList();
                BoomList = new ObservableCollection<Boom>(booms);

            }
            else
            {

            }
        }
    }
}
