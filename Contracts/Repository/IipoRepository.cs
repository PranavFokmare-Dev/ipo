using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IipoRepository:IRepositoryBase<IPO>
    {
        Task<IEnumerable<IPO>> GetIPOs();
        Task<IPO> GetIPOById(Guid id);
        Task CreateIpo(IPO ipo);

    }
}
