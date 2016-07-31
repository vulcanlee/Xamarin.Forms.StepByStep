using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSQLite
{
    public class MyRecord
    {
        public MyRecord()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string SelectItem { get; set; }
        public bool Done { get; set; }
    }
}
