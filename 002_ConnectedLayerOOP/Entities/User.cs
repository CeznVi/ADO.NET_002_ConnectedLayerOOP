using _002_ConnectedLayerOOP.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _002_ConnectedLayerOOP.Entities
{
    class User: IDataEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Login: {Login}, Pass: {Password}, Email: {Email}";
        }
    }
}
