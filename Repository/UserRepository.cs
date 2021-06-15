using Contracts.Repository;
using Entitites.Models;
using ipo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) { }
    }
}
