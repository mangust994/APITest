using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFranchiseService : IDisposable
    {
        IEnumerable<FranchiseModel> GetFranchise();

        FranchiseModel GetFranchiseById(int id);

        FranchiseModel GetFranchise(Func<Franchise, bool> predicate);

        void CreateFranchise(FranchiseModel model);

        void UpdateFranchise(int id, FranchiseModel model);

        void RemoveFranchise(int id);
    }
}
