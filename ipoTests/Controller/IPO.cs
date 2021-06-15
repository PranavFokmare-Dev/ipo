

using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entitites.DTO;
using ipo.Controllers;
using ipo.Profiles;
using ipo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ipoTests.Controller
{
    [TestClass]
    public class IPO
    {
        [TestMethod]
        public async Task ControllerPass()
        {
            var m = new Mock<IIpoService>();
            m.Setup(x => x.GetIpos()).ReturnsAsync(() => {
                var list = new List<IpoDTO>();
                list.Add(new IpoDTO());
                return list;
            });

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new IPOProfile()));
            IMapper mapper = mappingConfig.CreateMapper();

            var logger = new Mock<LoggerManager>();
            logger.Setup(logger => logger.LogInfo(It.IsAny<string>())).Verifiable();
            logger.Setup(logger => logger.LogError(It.IsAny<string>())).Verifiable();


            var controller = new IPOController(m.Object, mapper,  logger.Object);
            var result = await controller.GetAllIPOs();

            logger.Verify(log=>log.LogInfo(It.IsAny<string>()),Times.AtLeastOnce);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
            Assert.AreEqual(1,1);
        }

        [TestMethod]
        public async Task ControllerFail()
        {
            var m = new Mock<IIpoService>();
            m.Setup(x => x.GetIpos()).ReturnsAsync(() => {
                throw new Exception("test exception");
            });

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new IPOProfile()));
            IMapper mapper = mappingConfig.CreateMapper();

            var logger = new Mock<LoggerManager>();
            logger.Setup(logger => logger.LogInfo(It.IsAny<string>())).Verifiable();
            logger.Setup(logger => logger.LogError(It.IsAny<string>())).Verifiable();


            var controller = new IPOController(m.Object, mapper, logger.Object);
            var result = await controller.GetAllIPOs();

            logger.Verify(log => log.LogError(It.IsAny<string>()), Times.AtLeastOnce);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(1, 1);
        }
    }
}
