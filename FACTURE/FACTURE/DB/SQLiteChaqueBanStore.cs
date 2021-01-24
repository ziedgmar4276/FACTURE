using FACTURE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FACTURE.DB
{
    public class SQLiteChaqueBanStore : IChaqueBanStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteChaqueBanStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<ChaqueBan>();
        }
        //return  liste  chaqueban
        public async Task<IEnumerable<ChaqueBan>> GetChaqueBansAsync()
        {
            return await _connection.Table<ChaqueBan>().ToListAsync();
        }
        //add chaque  banque  database
        public async Task AddChaqueBan(ChaqueBan chaqueBan)
        {
            await _connection.InsertAsync(chaqueBan);
        }

        public async Task DeleteChaqueBan(ChaqueBan chaqueBan)
        {
            await _connection.DeleteAsync(chaqueBan);
        }

        public async Task<ChaqueBan> GetChaqueBan(int Id_Ban)
        {
            return await _connection.FindAsync<ChaqueBan>(Id_Ban);
        }

       

        public async Task UpdateChaqueBan(ChaqueBan chaqueBan)
        {
            await _connection.UpdateAsync(chaqueBan);
        }
    }
}
