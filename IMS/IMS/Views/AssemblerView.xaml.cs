using System;
using System.Collections.Generic;
using System.IO;
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
using Infrastructure.Model;
using PrintServer;

namespace IMS.Views
{
    /// <summary>
    /// AssemblerView.xaml 的交互逻辑
    /// </summary>
    public partial class AssemblerView : UserControl
    {
        public AssemblerView()
        {
            InitializeComponent();
           
            Task.Run(() => Load());
          

        }
        private long LengthBuffer;
        private  async void Load()
        {
            while (true)
            {
                if (File.Exists(@"D:\SOP\SOPFile.pdf"))     // 返回bool类型，存在返回true，不存在返回false
                {
                    FileStream res = new FileStream(@"D:\SOP\SOPFile.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    if (res.Length != LengthBuffer)
                    {
                        LengthBuffer = res.Length;
                        await pdfViewer.LoadAsync(res);
                    }

                }




                await Task.Delay(3000);
            }
          
     
         
        }
    }
}
