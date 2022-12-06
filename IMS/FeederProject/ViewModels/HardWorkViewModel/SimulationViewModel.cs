using FeederProject.Models;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Prism.Ioc;
using Infrastructure.DialogHelper;
using Prism.Services.Dialogs;

namespace FeederProject.ViewModels.HardWorkViewModel
{
    public class SimulationViewModel:BindableBase
    {
        private readonly IDialogHostService _dialogHostService;
        public SimulationViewModel(IContainerExtension container)
        {
            _dialogHostService = container.Resolve<IDialogHostService>();
            GetValue();
        }

        private ObservableCollection<SimulationModel> _simulationModel;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<SimulationModel> SimulationModels
        {
            get { return _simulationModel; }
            set { SetProperty(ref _simulationModel, value); }
        }

        private List<SimulationModel> _simulation;
        private void GetValue()
        {


            //ST 工位 ，TFL 末端流转  TF流转位  BF缓存位   UP上料位  DOWN 下料位
            _simulation = new List<SimulationModel>();
            _simulation.Add(new SimulationModel() { Id = 1, Title = "" ,BackGround= "Transparent" });
            _simulation.Add(new SimulationModel() { Id = 2, STNum= 71, Title = "ST07" });
            _simulation.Add(new SimulationModel() { Id = 3, STNum = 81, Title = "ST08" });
            _simulation.Add(new SimulationModel() { Id = 4, STNum = 91, Title = "ST09" });
            _simulation.Add(new SimulationModel() { Id = 5, STNum = 101, Title = "ST10" });
            _simulation.Add(new SimulationModel() { Id = 6, STNum = 111, Title = "ST11" });
            _simulation.Add(new SimulationModel() { Id = 7, STNum = 121, Title = "ST12" });
            _simulation.Add(new SimulationModel() { Id = 8, Title = "", BackGround = "Transparent" });



            _simulation.Add(new SimulationModel() { Id = 9, Title = "TFL02" });
            _simulation.Add(new SimulationModel() { Id = 10, Title = "TF07" });
            _simulation.Add(new SimulationModel() { Id = 11, Title = "TF08" });
            _simulation.Add(new SimulationModel() { Id = 12, Title = "TF09" });
            _simulation.Add(new SimulationModel() { Id = 13, Title = "TF10" });
            _simulation.Add(new SimulationModel() { Id = 14, Title = "TF11" });
            _simulation.Add(new SimulationModel() { Id = 15, Title = "TF12" });
            _simulation.Add(new SimulationModel() { Id = 16, Title = "DOWN01" });



            _simulation.Add(new SimulationModel() { Id = 17, Title = "", BackGround = "Transparent" });
            _simulation.Add(new SimulationModel() { Id = 18, Title = "BF06" });
            _simulation.Add(new SimulationModel() { Id = 19, Title = "BF05" });
            _simulation.Add(new SimulationModel() { Id = 20, Title = "BF04" });
            _simulation.Add(new SimulationModel() { Id = 21, Title = "BF03" });
            _simulation.Add(new SimulationModel() { Id = 22, Title = "BF02" });
            _simulation.Add(new SimulationModel() { Id = 23, Title = "BF01" });
            _simulation.Add(new SimulationModel() { Id = 24, Title = "DOWN02" });




            _simulation.Add(new SimulationModel() { Id = 25, Title = "TFL01" });
            _simulation.Add(new SimulationModel() { Id = 26, Title = "TF06" });
            _simulation.Add(new SimulationModel() { Id = 27, Title = "TF05" });
            _simulation.Add(new SimulationModel() { Id = 28, Title = "TF04" });
            _simulation.Add(new SimulationModel() { Id = 29, Title = "TF03" });
            _simulation.Add(new SimulationModel() { Id = 30, Title = "TF02" });
            _simulation.Add(new SimulationModel() { Id = 31, Title = "TF01" });
            _simulation.Add(new SimulationModel() { Id = 32, Title = "UP01" });



            _simulation.Add(new SimulationModel() { Id = 33, Title = "", BackGround = "Transparent" });
            _simulation.Add(new SimulationModel() { Id = 34, STNum = 61, Title = "ST06" });
            _simulation.Add(new SimulationModel() { Id = 35, STNum = 51, Title = "ST05" });
            _simulation.Add(new SimulationModel() { Id = 36, STNum = 41, Title = "ST04" });
            _simulation.Add(new SimulationModel() { Id = 37, STNum = 31, Title = "ST03" });
            _simulation.Add(new SimulationModel() { Id = 38, STNum = 21, Title = "ST02" });
            _simulation.Add(new SimulationModel() { Id = 39, STNum = 11, Title = "ST01" });
            _simulation.Add(new SimulationModel() { Id = 40, Title = "", BackGround = "Transparent" });


            SimulationModels = new ObservableCollection<SimulationModel>(_simulation);
        }




        private DelegateCommand<object> _SelectedWMSCODECommand;
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<object> SelectedWMSCODECommand => _SelectedWMSCODECommand ?? (_SelectedWMSCODECommand = new DelegateCommand<object>(SelectedWMSCODE));
        private async void SelectedWMSCODE(object parameter)
        {
            if(parameter == null) return;
            var res=parameter as SimulationModel;

            if (res.Title == "UP01")
            {
                var resDialog = await _dialogHostService.ShowDialog("Simu_UPView", null);
                if (resDialog.Result != ButtonResult.OK) return;
                var simulationModel= _simulation.Where(x => x.Title == "TF01").FirstOrDefault();
                if(simulationModel != null)
                {
                    var todo = resDialog.Parameters.GetValue<DataTraceability>("ProInfo");
                    simulationModel.Tag = 2;
                    simulationModel.serialnum = todo.serial_num;
                    simulationModel.InOut = "进站";
                    SimulationModels = new ObservableCollection<SimulationModel>(_simulation);
                }
            }

            else if (res.Title.Contains("ST"))
            {
                var simulationModel = _simulation.Where(x => x.Title == "TF01").FirstOrDefault();
                if (simulationModel != null)
                {
                    simulationModel.Tag = 1;
                    simulationModel.serialnum ="";
                    simulationModel.InOut = "";
                    SimulationModels = new ObservableCollection<SimulationModel>(_simulation);
                }
            }
        }


    }
}
