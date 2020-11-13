using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompositionFranchiseService : IDisposable
    {
        IEnumerable<CompositionFranchiseModel> GetCompositionFranchise();

        CompositionFranchiseModel GetCompositionFranchiseById(int id);

        CompositionFranchiseModel GetCompositionFranchise(Func<CompositionFranchise, bool> predicate);

        void CreateCompositionFranchise(CompositionFranchiseModel model);

        void UpdateCompositionFranchise(int id, CompositionFranchiseModel model);

        void RemoveCompositionFranchise(int id);
    }
}
