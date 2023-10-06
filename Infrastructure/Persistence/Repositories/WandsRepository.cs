using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WandsRepository 
        : IWandRepository
    {
        private readonly WandsDbContext _dbContext;

        public WandsRepository(WandsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Wand?> CreateWandAsync(Wand wandToCreate)
        {
            var createdWand = 
                await _dbContext.Wands.AddAsync(wandToCreate);

            await _dbContext.SaveChangesAsync();

            return createdWand.Entity;
        }

        public async Task<ICollection<Wand>> GetAllWandsAsync()
        {
            var wands = 
                await _dbContext.Wands.ToListAsync();

            return wands;
        }

        public async Task<Wand?> GetWandByIdAsync(int id)
        {
            var wand = 
                await _dbContext.Wands
                        .FirstOrDefaultAsync(w => w.Id == id);

            return wand;
        }

        public async Task<int> UpdateWandAsync(Wand wandToUpdate)
        {
            int updatedWandsCount = 
                await _dbContext.Wands
                                .Where(w => w.Id == wandToUpdate.Id)
                                .ExecuteUpdateAsync(updating =>
                                    updating.SetProperty(w => w.Wood, wandToUpdate.Wood)
                                            .SetProperty(w => w.Core, wandToUpdate.Core)
                                            .SetProperty(w => w.Owner, wandToUpdate.Owner)
                                            .SetProperty(w => w.LengthInInches, wandToUpdate.LengthInInches)
                                            .SetProperty(w => w.Description, wandToUpdate.Description));

            return updatedWandsCount;
        }

        public async Task<int> DeleteWandAsync(int id)
        {
            int deletedWandsCount = 
                await _dbContext.Wands
                                .Where(w => w.Id == id)
                                .ExecuteDeleteAsync();

            return deletedWandsCount;
        }
    }
}
