using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;
using Infrastructure.Model;
using System.Linq;

namespace Infrastructure.ReadWritePlc
{
    public class BasicInfoOfPlc
    {
       
        public static List<CsvBasicInFoModel> ReadCsv()
        {
            try
            {
                using (var reader = new StreamReader(FileName.PlcAddress_CSV, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<CsvBasicInFo>();
                    var records = csv.GetRecords<CsvBasicInFoModel>().ToList();
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static  void WriteNewCsvFile(string path, List<CsvBasicInFoModel> csvBasicInFoModels)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<CsvBasicInFoModel>();
                cw.NextRecord();
                //foreach (CsvBasicInFoModel emp in csvBasicInFoModels)
                //{
                //    cw.WriteRecord<CsvBasicInFoModel>(emp);
                //    cw.NextRecord();
                //}
            }
        }
    }
}
