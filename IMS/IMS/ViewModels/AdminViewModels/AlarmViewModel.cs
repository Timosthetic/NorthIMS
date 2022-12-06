using Infrastructure.DialogHelper;
using Infrastructure.Dto;
using Infrastructure.Dto.Login;
using Infrastructure.Extensions;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IMS.ViewModels.AdminViewModels
{
    
    public class AlarmViewModel : BindableBase
    {
       private readonly IBaseService _baseService;
        private readonly IDialogHostService _dialogHostService;
        public AlarmViewModel(IContainerExtension container)
        {
            container = container ?? throw new ArgumentNullException(nameof(container));
            _baseService = container.Resolve<IBaseService>();
            _dialogHostService = container.Resolve<IDialogHostService>();

            var alarm = AppDbContext.Db.Queryable<AlarmRecord>().Take(50).ToList();
            AlarmList = new ObservableCollection<AlarmRecord>(alarm);



        }
        private DateTime _start = DateTime.Now;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Start
        {
            get { return _start; }
            set { SetProperty(ref _start, value); }
        }
        private DateTime _end = DateTime.Now;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End
        {
            get { return _end; }
            set { SetProperty(ref _end, value); }



        }

        public List<AlarmRecord> AlarmRecords { get; set; }
        private ObservableCollection<AlarmRecord> _alarmList;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<AlarmRecord> AlarmList
        {
            get { return _alarmList; }
            set { SetProperty(ref _alarmList, value); }
        }

       


        private DelegateCommand<object> _inquireCommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> InquireCommand => _inquireCommand ?? (_inquireCommand = new DelegateCommand<object>(Inquire));
        private async void Inquire(object parameter)
        {
            var res = await _baseService.GetAlarm(Start, End);
            if (res != null)
                AlarmRecords = res.Result as List<AlarmRecord>;
            AlarmList = new ObservableCollection<AlarmRecord>(AlarmRecords);
            if (AlarmRecords.Count < 0)
            {
                 await _dialogHostService.Question("温馨提示", "此时间段内没有报警数据");
            }
          
            
        }
    }
}
