using FACTURE.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FACTURE.DB
{
    public class SQLiteFacturStore : IFactureStore
    {

        private SQLiteAsyncConnection _connection;
        public SQLiteFacturStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Facture>();
        }

        public async Task AddFacture(Facture facture)
        {
            await _connection.InsertAsync(facture);
        }

        public async Task DeleteFacture(Facture facture)
        {
            await _connection.DeleteAsync(facture);
        }

        public async Task<Facture> GetFacture(int Id_Facture)
        {
            return await _connection.FindAsync<Facture>(Id_Facture);
        }

        public async Task<IEnumerable<Facture>> GetFacturesAsync()
        {
            return await _connection.Table<Facture>().ToListAsync();
        }

        public async Task UpdateFacture(Facture facture)
        {
            await _connection.UpdateAsync(facture);
        }
    }
}
