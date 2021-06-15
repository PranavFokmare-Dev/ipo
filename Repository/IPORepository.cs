using Contracts.Repository;
using Entitites.Models;
using ipo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class IPORepository : RepositoryBase<IPO>, IipoRepository
    {
       
        public IPORepository(ApplicationContext context):base(context)
        {

        }

        public async Task<IPO> GetIPOById(Guid id)
        {
            return await FindByCondition((ipo) => (ipo.Id.Equals(id))).SingleOrDefaultAsync() ;
        }

        public async Task<IEnumerable<IPO>> GetIPOs()
        {
            return await FindAll().ToListAsync();
        }
        public async Task CreateIpo(IPO ipo)
        {
            Create(ipo);
        }
    }
}
