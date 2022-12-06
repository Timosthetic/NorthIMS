using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibExcel
{
    public class ExcelHelper : IDisposable
    {
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);

                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        public bool DeleteExcel(int index, string filepath, string tempath)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            //fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //if (filepath.IndexOf(".xlsx") > 0) // 2007版本
            //    workbook = new XSSFWorkbook();
            //else if (filepath.IndexOf(".xls") > 0) // 2003版本
            //    workbook = new HSSFWorkbook();

            try
            {
                string templetfilepath = filepath;
                //string tpath = @"E:\000\out.xls";
                string tpath = tempath;
                //FileInfo ff = new FileInfo(tpath);
                //if (ff.Exists)
                //{
                //    ff.Delete();
                //}
                //FileStream fs = File.Create(tpath);
                //HSSFWorkbook x1 = new HSSFWorkbook();
                //x1.Write(fs);
                //fs.Close();


                FileStream fileRead = new FileStream(templetfilepath, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(fileRead);
                fileRead.Close();

                FileStream fileSave2 = new FileStream(tpath, FileMode.Open, FileAccess.Read);
                HSSFWorkbook book2 = new HSSFWorkbook(fileSave2);
                fileSave2.Close();
                //int sheetnumber = book2.Workbook.NumSheets - 1;
                // for (int x = 0; x < sheetnumber; x++)//
                //{
                book2.RemoveSheetAt(8);//如果你要保留第一个Sheet，这里参数就设置为1，如果你要全部都删除这里设为0（表示每次都删除第一个Sheet）
                                       // }
                using (FileStream fileSave = new FileStream(tpath, FileMode.Open, FileAccess.Write))
                {
                    book2.Write(fileSave);
                    fileSave.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false; ;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null)
                            continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }
        private static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }
        private static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {  //You can log something here     
                       //throw;    
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// 删除datebale的空白行
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable removeEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        
                        rowdataisnull = false;
                    }
                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            return dt;
        }
        /// <summary>
        /// DataTable转换成List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = row[tempName];
                        
                        if (tempName.Equals("id")|| tempName.Contains("数量"))
                        {

                            int i = int.Parse(value.ToString().Trim());
                            pro.SetValue(t, i, null);
                        }
                        if (!value.ToString().Equals("") && !tempName.Equals("id") && !tempName.Contains("数量"))
                        {
                            value.ToString().Trim();
                            pro.SetValue(t, value, null);
                        }

                    }
                }
                list.Add(t);
            }
            return list.Count == 0 ? null : list;
        }
        /// <summary>
        /// List<T>转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataSet<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;
            PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (T t in list)
            {
                try
                {
                    if (t == null)
                    {
                        continue;
                    }
                    row = dt.NewRow();
                    for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                    {
                        System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                        foreach (object attribute in pi.GetCustomAttributes(true)) //2.通过映射，找到成员属性上关联的特性类实例，
                        {
                            bool bo = true;
                            if (attribute is IsExport)//3.如果找到了限定长度的特性类对象，就用这个特性类对象验证该成员
                            {
                                IsExport attr = (IsExport)attribute;
                                bo = attr.IsExportData;
                            }
                            if (attribute is DisplayNameAttribute && bo)
                            {
                                DisplayNameAttribute dis = (DisplayNameAttribute)attribute;
                                string name = dis.DisplayName;
                                if (dt.Columns[name] == null)
                                {
                                    Type colType = pi.PropertyType;
                                    if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        colType = colType.GetGenericArguments().Max();
                                    }
                                    column = new DataColumn(name, colType);
                                    dt.Columns.Add(column);
                                }
                                row[name] = pi.GetValue(t, null);
                            }
                        }
                    }
                    dt.Rows.Add(row);
                }
                catch (Exception v)
                {
                    string aa = v.ToString();
                }

            }
            //ds.Tables.Add(dt);

            return dt;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
    }
}
