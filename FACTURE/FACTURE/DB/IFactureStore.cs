using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FACTURE.Models;

namespace FACTURE.DB
{
    public interface IFactureStore
    {
        Task<IEnumerable<Facture>> GetFacturesAsync();
        Task<Facture> GetFacture(int Id_Facture);
        Task AddFacture(Facture facture);
        Task UpdateFacture(Facture facture);
        Task DeleteFacture(Facture facture);
    }
}
