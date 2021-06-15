using AutoMapper;
using Contracts.Repository;
using Entitites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Service
{
    public interface IIpoService {
        Task<List<IpoDTO>> GetIpos();
    }

    public class IpoService : IIpoService
    {
        public IpoService(IipoRepository iporepo,IMapper mapper)
        {
            Iporepo = iporepo;
            Mapper = mapper;
        }

        private readonly IipoRepository Iporepo;

        private readonly IMapper Mapper;

        public async Task<List<IpoDTO>> GetIpos()
        {
            var list = await Iporepo.GetIPOs();
            return Mapper.Map<List<IpoDTO>>(list);

        }
    }
}
