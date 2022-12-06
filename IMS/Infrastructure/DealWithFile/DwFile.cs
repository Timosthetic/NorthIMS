using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.DealWithFile
{
	/// <summary>
	/// 判断文件是否已经到开
	/// </summary>
    public static class DwFile
    {
		public static bool IsFileOpened(string file)
		{
			bool result = false;
			try
			{
				FileStream fs = File.OpenWrite(file);
				fs.Close();
			}
			catch (Exception e)
			{
				result = true;
			}
			return result;
		}

//		得到的结果如下：
//如果文件是.txt.log.dat 则文件是否打开都显示 false；
//如果文件是.doc.xls.csv 则文件打开显示true， 文件没有打开则显示false；


    }
}
