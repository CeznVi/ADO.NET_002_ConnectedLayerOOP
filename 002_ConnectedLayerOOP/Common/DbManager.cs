using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;

namespace _002_ConnectedLayerOOP.Common
{
    class DbManager
    {
        private string _connectionString;
        protected DbProviderFactory _dbProviderFactory;
        protected DbConnection _dbConnection;
        protected DbCommand _dbCommand;
        protected DbTransaction _dbTransaction;
        protected DbDataReader _dataReader;

        protected Dictionary<string, List<IDataEntity>> _dataTables;


        public DbManager()
        {
            _dataTables = new Dictionary<string, List<IDataEntity>>();

            Init();



        }

        private void Init()
        {
            try
            {
                switch (ConfigurationManager.AppSettings["ActiveProvider"])
                {
                    case "MSSQL":
                        {
                            string prividerName = ConfigurationManager.AppSettings["ActiveProvider"];
                            DbProviderFactories.RegisterFactory(prividerName, System.Data.SqlClient.SqlClientFactory.Instance);
                            _dbProviderFactory = DbProviderFactories.GetFactory(prividerName);
                            _connectionString = ConfigurationManager.ConnectionStrings["SqlProvider"].ConnectionString;
                            _dbConnection = _dbProviderFactory.CreateConnection();
                            _dbCommand = _dbProviderFactory.CreateCommand();
                            _dbCommand.Connection = _dbConnection;
                            break;
                        }
                    case "Oracle":
                        {

                            break;
                        }
                    case "MYSql":
                        {

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void GetAllTableName() {
            //должен заполнить _dataTables (получаем имена таблиц в Бд)
        }

        private void GetAllData(string tableName)
        {
            //должен заполнить _dataTables (получаем данные из таблиц и сохраняем в _dataTables)
        }
    }
}
