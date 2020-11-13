using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class ClientManager : IClientManager
    {
        public UserContext Database { get; set; }
        public ClientManager(UserContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
        public IList<ClientProfile> GetClient()
        {
            return this.Database.Set<ClientProfile>().ToList();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
