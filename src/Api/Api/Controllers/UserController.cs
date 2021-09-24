using Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Common.Collection;
using Business;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserQueryService _userQueryService;
            

        public UserController(ILogger<UserController> logger, IUserQueryService userQueryService)
        {
            _logger = logger;
            _userQueryService = userQueryService;
        }

        [HttpGet]
        public List<UserDto> Get()
        {
            return _userQueryService.GetAllUsers();
        }
        //public async Task<DataCollection<UserDto>> Get(int page = 1, int take = 10, string ids = null)
        //{
        //    IEnumerable<int> customers = null;
        //    if (!string.IsNullOrEmpty(ids))
        //    {
        //        customers = ids.Split(',').Select(x => Convert.ToInt32(x));
        //    }
        //    return await _userQueryService.GetAllAsync(page, take, customers);

        //}
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userQueryService.GetAsync(id);
        }
    }
}
