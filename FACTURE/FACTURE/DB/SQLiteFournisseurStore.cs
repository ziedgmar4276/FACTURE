using FACTURE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FACTURE.DB
{
    class SQLiteFournisseurStore : IFournisseurStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteFournisseurStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Fournisseur>();
        }
        public async Task AddFournisseur(Fournisseur fournisseur)
        {
            await _connection.InsertAsync(fournisseur);
        }

        public async Task DeleteFournisseur(Fournisseur fournisseur)
        {
            await _connection.DeleteAsync(fournisseur);
        }

        public async Task<Fournisseur> GetFournisseur(int Id_Fournisseur)
        {
            return await _connection.FindAsync<Fournisseur>(Id_Fournisseur);
        }

        public async Task<IEnumerable<Fournisseur>> GetFournisseursAsync()
        {
            return await _connection.Table<Fournisseur>().ToListAsync();
        }

        public async Task UpdateFournisseur(Fournisseur fournisseur)
        {
            await _connection.UpdateAsync(fournisseur);
        }
    }
}
