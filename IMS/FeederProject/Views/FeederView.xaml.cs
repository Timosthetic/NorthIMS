using FeederProject.Models;
using Infrastructure.DealWithFile;
using Infrastructure.Dto.Login;
using Infrastructure.Dto.NewDto;
using Infrastructure.Helper;
using Prism.Ioc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeederProject.Views
{
    /// <summary>
    /// FeederView.xaml 的交互逻辑
    /// </summary>
    public partial class FeederView : UserControl
    {
        private readonly IBaseService _baseService;
        public FeederView(IContainerExtension container)
        {
            InitializeComponent();
            this.Textbox.Focus();
            this.Textbox.SelectAll();
            _baseService = container.Resolve<IBaseService>();
        }
        private ListviewLog listviewLog;

        private async void Textbox_KeyDown(object sender, KeyEventArgs e)
       
        {
            try
            {
                if (e.Key == Key.Enter)
                {

                    string Flag = this.Textbox.Text.Replace(" ", "");
                    var rfis = RFID.GetRFIDReadInfo("ST13_上料");

                    Io_Vehicles_Bing io_Vehicles_Bing = Get_Vehicles_Bing(rfis.RfidInfo).Result;

                    if (AppDbContext.Db.Queryable<dt_Trace_Track>().Where(x => x.Serial_num.Equals(Flag)).Count() > 0)
                    {
                        listviewLog = new ListviewLog($"条码已被使用，禁止二次利用");
                        this.Textbox.Focus();
                        this.Textbox.Text = "";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(rfis.RfidInfo))
                        {



                            RFIDInfo.Text = rfis.RfidInfo;
                            io_Vehicles_Bing.vh_code = rfis.RfidInfo;

                            var res = await AppDbContext.Db.Queryable<DataTraceability>().Where(x => x.serial_num == Flag).SingleAsync();

                            if (res != null)
                            {
                                io_Vehicles_Bing.circulation_st = res.station;
                                io_Vehicles_Bing.await_st = res.station;
                                io_Vehicles_Bing.material_code = res.materialCode;
                                io_Vehicles_Bing.pro_code = res.procode;
                                io_Vehicles_Bing.serial_num = res.serial_num;
                                io_Vehicles_Bing.workorder = res.work_order;
                                io_Vehicles_Bing.TagSerialnum = res.TagSerialnum;
                                UpdateVelBing(io_Vehicles_Bing);
                                var str = Convert.ToInt32(res.station.Split(",")[0]);
                                var st = await AppDbContext.Db.Queryable<Io_RFID_InFo>().Where(x => x.StCode == str).Select(x => x.Station).SingleAsync();
                                listviewLog = new ListviewLog($"条码绑定成功", st);

                                this.Textbox.Focus();
                                this.Textbox.SelectAll();
                            }
                            else
                            {
                                listviewLog = new ListviewLog($"此条码不存在当前生产的工单里面");

                                this.Textbox.Focus();
                                this.Textbox.Text = "";
                            }


                        }
                        else
                        {
                            listviewLog = new ListviewLog($"条码绑定失败，请重新扫码绑定");

                            this.Textbox.Text = "";
                        }
                    }


                    _list.Items.Insert(0, listviewLog);
                    if (_list.Items.Count > 2000)
                    {
                        _list.Items.Clear();
                    }

                }
            }
            catch (Exception ex)
            {

                Log.Error($"载具绑定失败,原因:{ex.Message}");
            }
           
        }


        /// <summary>
        /// 更新载具绑定信息
        /// </summary>
        /// <param name="io_Vehicles_Bing"></param>
        private async void UpdateVelBing(Io_Vehicles_Bing io_Vehicles_Bing)
        {
            var res = await _baseService.UpdateVelBingAsync(io_Vehicles_Bing);
        }


        /// <summary>
        /// 获取此载具ID的绑定信息
        /// </summary>
        /// <param name="VehiclesCode"></param>
        /// <returns></returns>
        private async Task<Io_Vehicles_Bing> Get_Vehicles_Bing(string VehiclesCode)
        {
            var res = await _baseService.GetVelBingAsync(VehiclesCode);
            var ress = (Io_Vehicles_Bing)res.Result;

            return ress;

        }

        private void richlog_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
