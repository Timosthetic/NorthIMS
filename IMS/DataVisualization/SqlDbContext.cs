using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataVisualization
{
    public class SqlDbContext
    {
        static SqlDbContext()
        {
            Db = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["db_mysql_config_data"].ToString(),
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


    

        public static SqlSugarScope Db { get; }
    }
}
