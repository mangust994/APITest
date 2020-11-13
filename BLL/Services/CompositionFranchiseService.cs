using AutoMapper;
using BLL.Infrastructures;
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
    public class CompositionFranchiseService : ICompositionFranchiseService
    {
        private readonly IRepository repository;

        public CompositionFranchiseService(IRepository repo)
        {
            this.repository = repo;
        }
        public void CreateCompositionFranchise(CompositionFranchiseModel model)
        {
            var composition = this.repository.FirstorDefault<Composition>(x => x.Id == model.Composition.Id);
            var franchise = this.repository.FirstorDefault<Franchise>(x => x.Id == model.Franchise.Id);
            CompositionFranchise compositionFranchise = new CompositionFranchise();
            compositionFranchise.CompositionId = composition.Id;
            compositionFranchise.Composition = composition;
            compositionFranchise.Franchise = franchise;
            compositionFranchise.FranchiseId = franchise.Id;
            this.repository.AddAndSave<CompositionFranchise>(compositionFranchise);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
        public IEnumerable<CompositionFranchiseModel> GetCompositionFranchise()
        {
            var listComposFranchise = this.repository.GetAll<CompositionFranchise>();
            var listmodel = new List<CompositionFranchiseModel>();
            var compMap = MapHelper.Mapping<Composition, CompositionModel>();
            var franchMap = MapHelper.Mapping<Franchise, FranchiseModel>();
            foreach (var item in listComposFranchise)
            {
                var model = new CompositionFranchiseModel();
                model.Id = item.Id;
                model.CompositionId = item.CompositionId;
                model.FranchiseId = item.FranchiseId;
                model.Composition = compMap.Map<CompositionModel>(item.Composition);
                model.Franchise = franchMap.Map<FranchiseModel>(item.Franchise);
                listmodel.Add(model);
            }
            return listmodel;
        }


        public CompositionFranchiseModel GetCompositionFranchise(Func<CompositionFranchise, bool> predicate)
        {
            var mapper = MapHelper.Mapping<CompositionFranchiseModel, CompositionFranchise>();
            return mapper.Map<CompositionFranchiseModel>(this.repository.FirstorDefault(predicate));
        }

        public CompositionFranchiseModel GetCompositionFranchiseById(int id)
        {
            var entity = this.repository.FirstorDefault<CompositionFranchise>(x => x.Id == id);
            var model = new CompositionFranchiseModel();
            model.Id = entity.Id;
            model.CompositionId = entity.CompositionId;
            model.FranchiseId = entity.FranchiseId;
            return model;
        }

        public void RemoveCompositionFranchise(int id)
        {
            var compositionFranchise = this.repository.FirstorDefault<CompositionFranchise>(x => x.Id == id);
            if (compositionFranchise == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(compositionFranchise);
        }

        public void UpdateCompositionFranchise(int id, CompositionFranchiseModel model)
        {
            var compositionFranchise = this.repository.FirstorDefault<CompositionFranchise>(x => x.Id == id);
            if (compositionFranchise == null)
                throw new NullReferenceException();
            var compositionMap = MapHelper.Mapping<CompositionModel, Composition>();
            var franchiseMap = MapHelper.Mapping<FranchiseModel, Franchise>();
            compositionFranchise.CompositionId = model.CompositionId;
            compositionFranchise.Composition = compositionMap.Map<Composition>(model.Composition);
            compositionFranchise.Franchise = franchiseMap.Map<Franchise>(model.Franchise);
            compositionFranchise.FranchiseId = model.FranchiseId;
            this.repository.UpdateAndSave(compositionFranchise);
        }
    }
}
