using AutoMapper;
using Entitites.DTO;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Profiles
{
    public class IPOProfile:Profile
    {
        public IPOProfile()
        {
            CreateMap<IPO, IpoDTO>().ReverseMap();
            CreateMap<IPO, IpoCreationDTO>().ReverseMap();
            CreateMap<Subscription, SubscriptionDTO>();
        }
    }
}
