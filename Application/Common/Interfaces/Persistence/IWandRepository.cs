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
        Wand CreateWand(Wand wand);
        Wand GetWandById(int id);
        ICollection<Wand> GetAllWands();
        void UpdateWand(Wand wand);
        void DeleteWand(int id);
    }
}
