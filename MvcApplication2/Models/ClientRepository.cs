using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcApplication2.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public override IQueryable<Client> All()
        {
            return base.All().Where(c => !c.IsDeleted);
        }

        public Client Find(int id)
        {
            return this.All().Where(c => c.ClientId == id).FirstOrDefault();
        }

        public void Delete(Client client)
        {
            client.IsDeleted = true;
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}