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
            return await _dbContext.Wands.ToListAsync();
        }

        public async Task<Wand?> GetWandByIdAsync(int id)
        {
            return await _dbContext.Wands.FirstOrDefaultAsync(w => w.Id == id);
        }

        public Task UpdateWandAsync(Wand wandToUpdate)
        {
            return Task.Run(() => _dbContext.Wands.Update(wandToUpdate));
        }

        public async Task DeleteWandAsync(int id)
        {
            var wandToDelete = await _dbContext.Wands.FirstOrDefaultAsync(w => w.Id == id);
            await Task.Run(() => _dbContext.Wands.Remove(wandToDelete));
        }
    }
}
