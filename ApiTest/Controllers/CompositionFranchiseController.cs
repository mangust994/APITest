using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class CompositionFranchiseController : ApiController
    {

        private readonly ICompositionFranchiseService compositionFranchiseService;

        public CompositionFranchiseController(ICompositionFranchiseService compositionFranchiseService)
        {
            this.compositionFranchiseService = compositionFranchiseService;
        }

        [HttpGet]
        public IEnumerable<CompositionFranchiseModel> Get()
        {
            return this.compositionFranchiseService.GetCompositionFranchise();
        }

        public CompositionFranchiseModel Get(int id)
        {
            return this.compositionFranchiseService.GetCompositionFranchiseById(id);
        }

        [HttpPost]
        public void Post([FromBody] CompositionFranchiseModel model)
        {
            compositionFranchiseService.CreateCompositionFranchise(model);
        }

        public void Put(int id, [FromBody] CompositionFranchiseModel model)
        {
            compositionFranchiseService.UpdateCompositionFranchise(id, model);
        }

        public void Delete(int id)
        {
            compositionFranchiseService.RemoveCompositionFranchise(id);
        }
    }
}