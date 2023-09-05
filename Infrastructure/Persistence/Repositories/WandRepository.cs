using Application.Common.Interfaces.Persistence;
using Domain.Models;
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

        public Wand CreateWand(Wand wand)
        {
            throw new NotImplementedException();
        }

        public ICollection<Wand> GetAllWands()
        {
            throw new NotImplementedException();
        }

        public Wand GetWandById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWand(Wand wand)
        {
            throw new NotImplementedException();
        }

        public void DeleteWand(int id)
        {
            throw new NotImplementedException();
        }
    }
}
