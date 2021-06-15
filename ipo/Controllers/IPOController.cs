using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entitites.DTO;
using Entitites.Models;
using ipo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPOController : ControllerBase
    {
        private readonly IIpoService _repo;
        private readonly IMapper _mapper;
        private readonly LoggerManager logger;

        public IPOController(IIpoService repo,IMapper mapper, LoggerManager _logger)
        {
            _repo = repo;
            _mapper = mapper;
            logger = _logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIPOs()
        {
            try
            {
                logger.LogInfo("Getting all IPOS");
                return Ok(await _repo.GetIpos());
            }
            catch(Exception ex)
            {
                logger.LogError("Error in IPO getting");
                return BadRequest("server error");
            }
        }

    }
}
