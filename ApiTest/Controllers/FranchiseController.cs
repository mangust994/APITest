using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTest.Controllers
{
    [EnableCors(origins: "http://localhost:44383/", headers: "", methods: "")]
    public class FranchiseController : ApiController
    {

        private readonly IFranchiseService franchiseService;

        public FranchiseController(IFranchiseService franchiseService)
        {
            this.franchiseService = franchiseService;
        }

        [HttpGet]
        public IEnumerable<FranchiseModel> Get()
        {
            return this.franchiseService.GetFranchise();
        }

        public FranchiseModel Get(int id)
        {
            return this.franchiseService.GetFranchiseById(id);
        }

        [HttpPost]
        public void Post([FromBody] FranchiseModel model)
        {
            franchiseService.CreateFranchise(model);
        }

        public void Put(int id, [FromBody] FranchiseModel model)
        {
            franchiseService.UpdateFranchise(id, model);
        }

        public void Delete(int id)
        {
            franchiseService.RemoveFranchise(id);
        }
    }
}
