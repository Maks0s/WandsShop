using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence
{
    public interface IWandRepository
    {
        Task<Wand> CreateWandAsync(Wand wandToCreate);
        Task<Wand?> GetWandByIdAsync(int id);
        Task<ICollection<Wand>> GetAllWandsAsync();
        Task UpdateWandAsync(Wand wandToUpdate);
        Task DeleteWandAsync(int id);
    }
}
