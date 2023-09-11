using Application.Common.Interfaces.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class WandRepository : IWandRepository
    {
        private readonly WandDbContext _dbContext;

        public WandRepository(WandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Wand> CreateWandAsync(Wand wandToCreate)
        {
            await _dbContext.Wands.AddAsync(wandToCreate);
            await _dbContext.SaveChangesAsync();
            return wandToCreate;
        }

        public async Task<ICollection<Wand>> GetAllWandsAsync()
        {
            var wands = await _dbContext.Wands.ToListAsync();
            return wands;
        }

        public async Task<Wand?> GetWandByIdAsync(int id)
        {
            var wand = await _dbContext.Wands.FirstOrDefaultAsync(w => w.Id == id);
            return wand;
        }

        public async Task UpdateWandAsync(Wand wandToUpdate)
        {
            int wandsUpdated = await _dbContext.Wands
                                        .Where(w => w.Id == wandToUpdate.Id)
                                        .ExecuteUpdateAsync(updating =>
                                            updating.SetProperty(w => w.Wood, wandToUpdate.Wood)
                                                    .SetProperty(w => w.Core, wandToUpdate.Core)
                                                    .SetProperty(w => w.Owner, wandToUpdate.Owner)
                                                    .SetProperty(w => w.Description, wandToUpdate.Description));

            if (wandsUpdated == 0)
            {

            }
        }

        public async Task DeleteWandAsync(int id)
        {
            int wandsDeleted = await _dbContext.Wands
                                        .Where(w => w.Id == id)
                                        .ExecuteDeleteAsync();

            if(wandsDeleted == 0)
            {

            }
        }
    }
}
