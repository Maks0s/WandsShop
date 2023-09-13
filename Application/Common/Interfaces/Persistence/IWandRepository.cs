using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence
{
    public interface IWandRepository
    {
        Task<Wand?> CreateWandAsync(Wand wandToCreate);
        Task<Wand?> GetWandByIdAsync(int id);
        Task<ICollection<Wand>> GetAllWandsAsync();
        Task<int> UpdateWandAsync(Wand wandToUpdate);
        Task<int> DeleteWandAsync(int id);
    }
}
