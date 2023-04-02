using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _001_ConectedLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dpName = ConfigurationManager.AppSettings["provider"];
            string connString = ConfigurationManager.ConnectionStrings["SqlProvider"].ConnectionString;

            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(dpName);

            //DbConnection conn = dbProviderFactory.CreateConnection();

            //conn.ConnectionString = connString;

            //conn.Open();


            //Console.WriteLine("Open succesful");
            //Console.WriteLine($"Object connect {conn.GetType().Name}");

            //conn.Close();

            //using (DbConnection conn = dbProviderFactory.CreateConnection())
            //{
            //    conn.ConnectionString = connString;
            //    conn.Open();



            //DbCommand dbCommandGettAllUsers  = dbProviderFactory.CreateCommand();
            //dbCommandGettAllUsers.Connection = conn;
            //dbCommandGettAllUsers.CommandText = "SELECT * FROM users";


            //using (DbDataReader dbAllUser = dbCommandGettAllUsers.ExecuteReader())
            //{
            //    Console.WriteLine("Содержимое:");
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    while (dbAllUser.Read()) 
            //    {
            //        Console.WriteLine( $"Id {dbAllUser["id"]};" +
            //            $"\tLogin {dbAllUser["login"]}");

            //    }
            //    Console.ResetColor();

            //}

            //string userLogin = "Supeuser";
            //string userEmail = "Supeuser@gmail.com";
            //string userPassord = "qwerty3";

            //DbCommand dbCommandInsertUser = dbProviderFactory.CreateCommand();
            //dbCommandInsertUser.Connection = conn;
            //dbCommandInsertUser.CommandText =
            //    "INSERT INTO users (login, email, password) VALUES (@login, @email, @password)";

            //DbParameter loginParametr = dbCommandInsertUser.CreateParameter();
            //loginParametr.DbType = System.Data.DbType.String;
            //loginParametr.ParameterName = "@login";
            //loginParametr.Value = userLogin;
            //dbCommandInsertUser.Parameters.Add(loginParametr);

            //DbParameter emailParametr = dbCommandInsertUser.CreateParameter();
            //emailParametr.DbType = System.Data.DbType.String;
            //emailParametr.ParameterName = "@email";
            //emailParametr.Value = userEmail;
            //dbCommandInsertUser.Parameters.Add(emailParametr);

            //DbParameter passParametr = dbCommandInsertUser.CreateParameter();
            //passParametr.DbType = System.Data.DbType.String;
            //passParametr.ParameterName = "@password";

            //SHA256 sHA256 = SHA256.Create();
            //byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(userPassord));

            //StringBuilder builder = new StringBuilder();

            //for(int i = 0; i < bytes.Length; i++)
            //{
            //    builder.Append(bytes[i].ToString("x2"));
            //}

            //passParametr.Value = builder.ToString();

            //dbCommandInsertUser.Parameters.Add(passParametr);

            //if(dbCommandInsertUser.ExecuteNonQuery() == 1)
            //{
            //    Console.WriteLine("Ползов добавлен");
            //}
            //else
            //    Console.WriteLine("ERORR!");



            ///////////////UPDATE
            //    DbCommand dbCommandUpdateUser = dbProviderFactory.CreateCommand();
            //    dbCommandUpdateUser.Connection = conn;
            //    dbCommandUpdateUser.CommandText = "UPDATE users SET email = @email, login = @login WHERE Id = @id";

            //    List<UpdateParam> updateParams = new List<UpdateParam>();

            //    UpdateParam updateIdParams = new UpdateParam()
            //    {
            //        NameCol = "Id",
            //        Parameter = dbCommandUpdateUser.CreateParameter()
            //    };
            //    updateIdParams.Parameter.ParameterName = "@id";
            //    updateIdParams.Parameter.DbType = System.Data.DbType.Int32;
            //    updateIdParams.Parameter.Value = 7;
            //    dbCommandUpdateUser.Parameters.Add(updateIdParams.Parameter);

            //    UpdateParam updateEmailParams = new UpdateParam()
            //    {
            //        NameCol = "email",
            //        Parameter = dbCommandUpdateUser.CreateParameter()
            //    };
            //    updateEmailParams.Parameter.ParameterName = "@email";
            //    updateEmailParams.Parameter.DbType = System.Data.DbType.String;
            //    updateEmailParams.Parameter.Value = "SuperEMAIL@g.com";
            //    dbCommandUpdateUser.Parameters.Add(updateEmailParams.Parameter);


            //    UpdateParam updateLoginParams = new UpdateParam()
            //    {
            //        NameCol = "login",
            //        Parameter = dbCommandUpdateUser.CreateParameter()
            //    };
            //    updateLoginParams.Parameter.ParameterName = "@login";
            //    updateLoginParams.Parameter.DbType = System.Data.DbType.String;
            //    updateLoginParams.Parameter.Value = "SuperLOGIN";
            //    dbCommandUpdateUser.Parameters.Add(updateLoginParams.Parameter);


            //    if (dbCommandUpdateUser.ExecuteNonQuery() == 1)
            //        Console.WriteLine("DONE");
            //    else
            //        Console.WriteLine("WRONG");
            //}


            //CRUD create updete delete
            //store prcedure
            //Transaction 
            //Параметризированные запросы

            //DbCommand dbCommandGetFullIfroProc = dbProviderFactory.CreateCommand();
            //dbCommandGetFullIfroProc.Connection = conn;
            //dbCommandGetFullIfroProc.CommandText = "getFullUserInfo";
            //dbCommandGetFullIfroProc.CommandType = System.Data.CommandType.StoredProcedure;

            //DbParameter dbParameterId = dbCommandGetFullIfroProc.CreateParameter();
            //dbParameterId.DbType = System.Data.DbType.Int32;
            //dbParameterId.ParameterName = "@Id";
            //dbParameterId.Value = 1;
            //dbCommandGetFullIfroProc.Parameters.Add(dbParameterId);





            //using (DbDataReader dbAllUser = dbCommandGetFullIfroProc.ExecuteReader())
            //{
            //    Console.WriteLine("Содержимое:");
            //    Console.ForegroundColor = ConsoleColor.Green;

            //    while (dbAllUser.Read())
            //    {
            //        Console.WriteLine($"Id {dbAllUser["id"]};" +
            //            $"\tLogin {dbAllUser["login"]}");

            //    }
            //    Console.ResetColor();



            //}

            //}
            ////--------------------------ТРАНЗАКЦИИ
            //using (DbConnection conn = dbProviderFactory.CreateConnection())
            //{
            //    conn.ConnectionString = connString;
            //    conn.Open();

            //    DbTransaction transaction = conn.BeginTransaction();
            //    DbCommand dbTrCommand = dbProviderFactory.CreateCommand();
            //    dbTrCommand.Connection = conn;
            //    dbTrCommand.Transaction = transaction;

            //    try
            //    {
            //        dbTrCommand.CommandType = System.Data.CommandType.Text;
            //        dbTrCommand.CommandText = " DELETE FROM usersInfo WHERE userId = 4";
            //        dbTrCommand.ExecuteNonQuery();


            //        //dbTrCommand.CommandType = System.Data.CommandType.Text;
            //        //dbTrCommand.CommandText = " DELETE FROM usersInfo WHERE userId = ";
            //        //dbTrCommand.ExecuteNonQuery();

            //        dbTrCommand.CommandType = System.Data.CommandType.Text;
            //        dbTrCommand.CommandText = " DELETE FROM users WHERE Id = 4";
            //        dbTrCommand.ExecuteNonQuery();

            //        transaction.Commit();
            //    }
            //    catch (Exception ex) 
            //    { 
            //        transaction.Rollback();
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine(ex.Message);
            //        Console.ResetColor();   


            //    }
            //    finally 
            //    {
            //        conn.Close(); 
            //    }


            //}
            ////--------------------------ТРАНЗАКЦИИ КОНЕЦ

            using (DbConnection conn = dbProviderFactory.CreateConnection())
            {
                conn.ConnectionString = connString;
                conn.Open();



            }
        }
    }
}
