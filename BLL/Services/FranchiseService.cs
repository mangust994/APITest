using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IRepository repository;

        public FranchiseService(IRepository repo)
        {
            this.repository = repo;
        }
        public void CreateFranchise(FranchiseModel model)
        {
            var mapper = MapHelper.Mapping<FranchiseModel, Franchise>();
            Franchise franchise = mapper.Map<Franchise>(model);
            this.repository.AddAndSave<Franchise>(franchise);
        }
        public void Dispose()
        {
            this.repository.Dispose();
        }
        public IEnumerable<FranchiseModel> GetFranchise()
        {
            var mapper = MapHelper.Mapping<Franchise, FranchiseModel>();
            return mapper.Map<List<FranchiseModel>>(this.repository.GetAll<Franchise>());
        }

        public FranchiseModel GetFranchise(Func<Franchise, bool> predicate)
        {
            var mapper = MapHelper.Mapping<FranchiseModel, Franchise>();
            return mapper.Map<FranchiseModel>(this.repository.FirstorDefault(predicate));
        }

        public FranchiseModel GetFranchiseById(int id)
        {
            var mapper = MapHelper.Mapping<FranchiseModel, Franchise>();
            return mapper.Map<FranchiseModel>(this.repository.FirstorDefault<Franchise>(x => x.Id == id));
        }

        public void RemoveFranchise(int id)
        {
            var franchise = this.repository.FirstorDefault<Franchise>(x => x.Id == id);
            if (franchise == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(franchise);
        }

        public void UpdateFranchise(int id, FranchiseModel model)
        {
            var franchise = this.repository.FirstorDefault<Franchise>(x => x.Id == id);
            if (franchise == null)
                throw new NullReferenceException();
            var mapper = MapHelper.Mapping<Franchise, FranchiseModel>();
            franchise = mapper.Map<Franchise>(model);
            this.repository.UpdateAndSave(franchise);
        }
    }
}
