using AutoMapper;
using ipo.Profiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipoTests.Mapper
{
    [TestClass()]
    public class autoMapperTest
    {


        [TestMethod()]
        public void MapperTest()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new IPOProfile()));
            //IMapper mapper = mappingConfig.CreateMapper();
         
            try
            {
                mappingConfig.AssertConfigurationIsValid();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            
            Assert.IsTrue(true);
        }

    }
}
