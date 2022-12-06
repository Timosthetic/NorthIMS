
using Infrastructure.Dto.NewDto;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Infrastructure.Helper
{
    public class AppDbContext
    {
      
        static AppDbContext()
        {

            Db = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["db_mysql_config"].ToString(),
                DbType = DbType.MySql,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据库，如果存在事务，在事务结束之后释放。
                InitKeyType = InitKeyType.Attribute//从实体特性中读取主键自增列信息   
            });
        }
        public static void CreateTable(bool Backup = false, int StringDefaultLength = 50, params Type[] types)
        {
            Db.CodeFirst.SetStringDefaultLength(StringDefaultLength);
            Db.DbMaintenance.CreateDatabase();
            if (Backup)
            {
                Db.CodeFirst.BackupTable().InitTables(types);
            }
            else
            {
                Db.CodeFirst.InitTables(types);
            }
        }

      
       public SimpleClient<Io_prc_product> Io_prc_product { get { return new SimpleClient<Io_prc_product>(Db); } }
        public SimpleClient<Io_prc_standard> Io_prc_standard { get { return new SimpleClient<Io_prc_standard>(Db); } }
        public SimpleClient<Io_pro_details> Io_pro_details { get { return new SimpleClient<Io_pro_details>(Db); } }

       
        public static SqlSugarScope Db { get; }
    }
}
