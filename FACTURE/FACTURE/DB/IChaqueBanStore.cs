using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FACTURE.Models;

namespace FACTURE.DB
{
    public  interface IChaqueBanStore
    {
        Task<IEnumerable<ChaqueBan>>GetChaqueBansAsync();
        Task<ChaqueBan> GetChaqueBan(int Id_Ban);
        Task AddChaqueBan(ChaqueBan chaqueBan);
        Task UpdateChaqueBan(ChaqueBan chaqueBan);
        Task DeleteChaqueBan(ChaqueBan chaqueBan);
    }
}
