using System;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Storages
{
    class UsersStorage: Common.DbManager
    {
        private List<Entities.User> users = new List<Entities.User>();
    }
}
