using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FACTURE.Models;
namespace FACTURE.DB
{
  public interface IFournisseurStore
    {
        Task<IEnumerable<Fournisseur>> GetFournisseursAsync();
        Task<Fournisseur> GetFournisseur(int Id_Fournisseur);
        Task AddFournisseur(Fournisseur fournisseur);
        Task UpdateFournisseur(Fournisseur fournisseur);
        Task DeleteFournisseur(Fournisseur fournisseur);
    }
}
