using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSQLite
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
