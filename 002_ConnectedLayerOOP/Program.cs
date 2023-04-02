using _002_ConnectedLayerOOP.Common;
using System;

namespace _002_ConnectedLayerOOP
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DbManager dbManager = new DbManager();

            Console.WriteLine("Users: ");
            dbManager.ShowUsersFromLocalStorage();

            Console.WriteLine("\n\nUserInfo: ");
            dbManager.ShowUsersInfoFromLocalStorage();
        }
    }
}
