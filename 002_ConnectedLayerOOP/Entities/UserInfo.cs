using _002_ConnectedLayerOOP.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _002_ConnectedLayerOOP.Entities
{
    class UserInfo: IDataEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Fio { get; set; }

        public string Inn { get; set; }
        
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, UserId:{UserId}, FIO: {Fio}, Inn: {Inn}, BDay: {BirthDate}, Gende: {Gender}";
        }
    }
}
