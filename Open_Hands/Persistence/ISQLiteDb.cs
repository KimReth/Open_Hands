using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Open_Hands.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
