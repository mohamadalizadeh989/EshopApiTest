using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Contracts
{
   public interface ISalesPersonsRepository
   {
       IEnumerable<SalesPersons> GetAll();
       Task<SalesPersons> Add(SalesPersons sales);
       Task<SalesPersons> Find(int id);
       Task<SalesPersons> Update(SalesPersons sales);
       Task<SalesPersons> Remove(int id);
       Task<bool> IsExists(int id);
   }
}
