using AutoMapper;
using Contracts.Repository;
using Entitites.Models;
using ipo.Profiles;
using ipo.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipoTests
{
    [TestClass]
    public class Mow
    {
        [TestMethod]
        public async Task demoTestAsync()
        {
            var m = new Mock<IipoRepository>();
            m.Setup( x => x.GetIPOs()).ReturnsAsync(()=> { var list = new List<IPO>();
                list.Add(new IPO());
                return list;
            });
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new IPOProfile()));
            IMapper mapper = mappingConfig.CreateMapper();


            IIpoService iposervice = new IpoService(m.Object,mapper);
            var res = await iposervice.GetIpos();
            Assert.AreEqual(1, res.Count());

        }
        public async Task demoTestAsync1()
        {
            var m = new Mock<IipoRepository>();
            m.Setup(x => x.GetIPOs()).ReturnsAsync(() => {
                var list = new List<IPO>();
                list.Add(new IPO());
                return list;
            });
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new IPOProfile()));
            IMapper mapper = mappingConfig.CreateMapper();


            IIpoService iposervice = new IpoService(m.Object, mapper);
            var res = await iposervice.GetIpos();
            Assert.AreEqual(1, res.Count());

        }
    }
}
