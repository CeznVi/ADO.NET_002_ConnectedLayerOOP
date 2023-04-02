using System.Data.Common;

namespace _001_ConectedLayer
{
    class UpdateParam
    {
        public string NameCol { set; get; }
        public  DbParameter Parameter { set; get; }

    }
}