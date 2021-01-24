using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FACTURE.DB
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
