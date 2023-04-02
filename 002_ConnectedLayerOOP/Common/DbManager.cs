using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Configuration;
using System.Data;

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
            GetAllTableName();
            GetDataFromDB();

        }

        //Получаем имена таблиц с БД
        private void GetAllTableName() 
        {
            _dbConnection.ConnectionString = _connectionString;
            _dbConnection.Open();

            DataTable dt = _dbConnection.GetSchema("Tables");

            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];

                if (tablename != "sysdiagrams")
                {
                    _dataTables.Add(tablename, new List<IDataEntity>());
                }
            }

            _dbConnection.Close();
        }

        private void GetAllData(string tableName)
        {

            _dbConnection.ConnectionString = _connectionString;
            _dbConnection.Open();

            _dbCommand.CommandText = $"SELECT * FROM {tableName}";

            if (tableName == "users")
            {
                using (DbDataReader dbAllUser = _dbCommand.ExecuteReader())
                {
                    Console.WriteLine("Содержимое:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    while (dbAllUser.Read())
                    {
                        Console.WriteLine($"Id {dbAllUser["id"]};" +
                            $"\tLogin {dbAllUser["login"]}");

                    }
                    Console.ResetColor();

                }
            }
            else if (tableName == "usersInfo")
            {

            }

            _dbConnection.Close();

            //_dbConnection.ConnectionString = _connectionString;
            //_dbConnection.Open();

            // foreach(var key in _dataTables) 
            // { 
            //    string dataTableName = key.ToString();
            //    Console.WriteLine(dataTableName);
            // }
            //_dbConnection.Close();


            //должен заполнить _dataTables (получаем данные из таблиц и сохраняем в _dataTables)
        }

        /// <summary>
        /// Читает данные из таблиц на основе заранее полученых их названий
        /// </summary>
        private void GetDataFromDB() 
        {
            foreach (var item in _dataTables)
            {
                GetAllData(item.Key);
            }
        }
    }
}
