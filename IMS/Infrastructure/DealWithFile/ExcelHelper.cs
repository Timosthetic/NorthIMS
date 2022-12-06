using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Infrastructure.DealWithFile
{
    /// <summary>
    /// EpPlus读取Excel帮助类
    /// </summary>
    public class ExcelHelper
    {
        #region 由List创建简单Excel

        /// <summary>
        /// 由List创建简单Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <param name="dataList">The data list.</param>
        public static void CreateExcelByList<T>(string filePath, List<T> dataList) where T : class
        {
            try
            {
                string dirPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileName(filePath);

                FileInfo newFile = new FileInfo(filePath);
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(filePath);
                }
                PropertyInfo[] properties = null;
                if (dataList.Count > 0)
                {
                    Type type = dataList[0].GetType();
                    properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                    //获取 Descriptions 用作列名
                    Dictionary<string, DescriptionAttribute> filedDescriptions = new Dictionary<string, DescriptionAttribute>();
                    foreach (var item in properties)
                    {
                        filedDescriptions.Add(item.Name, item.GetCustomAttribute<DescriptionAttribute>());
                    }

                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("sheet1");
                        //设置表头单元格格式
                        using (var range = worksheet.Cells[1, 1, 1, properties.Length])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                            range.Style.Font.Color.SetColor(Color.White);
                        }
                        int row = 1, col;
                        object objColValue;
                        string colValue;
                        //表头
                        for (int j = 0; j < properties.Length; j++)
                        {
                            row = 1;
                            col = j + 1;
                            var description = filedDescriptions.Where(o => o.Key == properties[j].Name).Select(o => o.Value).FirstOrDefault();
                            worksheet.Cells[row, col].Value = description == null || string.IsNullOrEmpty(description.Description) ? properties[j].Name : description.Description;
                        }
                        worksheet.View.FreezePanes(row + 1, 1); //冻结表头
                                                                //各行数据
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            row = i + 2;
                            for (int j = 0; j < properties.Length; j++)
                            {
                                col = j + 1;
                                objColValue = properties[j].GetValue(dataList[i], null);
                                colValue = objColValue == null ? "" : objColValue.ToString();
                                worksheet.Cells[row, col].Value = colValue;
                            }
                        }
                        package.Save();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion 由List创建简单Exel.列头取字段的Description或字段名

        #region 读取Excel数据到DataSet

        /// <summary>
        /// 读取Excel数据到DataSet
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static DataSet ReadExcelToDataSet(string filePath)
        {
            DataSet ds = new DataSet("ds");
            DataRow dr;
            try
            {
                object objCellValue;
                string cellValue;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                using (ExcelPackage package = new ExcelPackage())
                {
                    package.Load(fs);
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        if (sheet.Dimension == null) continue;
                        var columnCount = sheet.Dimension.End.Column;
                        var rowCount = sheet.Dimension.End.Row;
                        if (rowCount > 0)
                        {
                            DataTable dt = new DataTable(sheet.Name);
                            for (int j = 0; j < columnCount; j++)//设置DataTable列名
                            {
                                objCellValue = sheet.Cells[1, j + 1].Value;
                                cellValue = objCellValue == null ? "" : objCellValue.ToString();
                                dt.Columns.Add(cellValue, typeof(string));
                            }
                            for (int i = 2; i <= rowCount; i++)
                            {
                                dr = dt.NewRow();
                                for (int j = 1; j <= columnCount; j++)
                                {
                                    objCellValue = sheet.Cells[i, j].Value;
                                    cellValue = objCellValue == null ? "" : objCellValue.ToString();
                                    dr[j - 1] = cellValue;
                                }
                                dt.Rows.Add(dr);
                            }
                            ds.Tables.Add(dt);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        #endregion 读取Excel数据到DataSet
    }
}
