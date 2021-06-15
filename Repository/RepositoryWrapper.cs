using Contracts.Repository;
using ipo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext context;

        private IipoRepository _ipo;
        private IUserRepository _user;

        public IipoRepository IPO
        {
            get
            {
                if (_ipo == null)
                    _ipo = new IPORepository(context);
                return _ipo;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(context);
                return _user;
            }
        }
        public RepositoryWrapper(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task Save()
        {
            await context.SaveChangesAsync();

        }
    }
}
