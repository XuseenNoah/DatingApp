using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Data;
using DatingApp.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        public async Task<IActionResult> GetUsers()
        {
            var getUsers = await _repo.GetUsers();

            var userToReturn = _mapper.Map<List<UserForListDto>>(getUsers);
            return Ok(userToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var getUser = await _repo.GetUser(id);
            var UserToReturn = _mapper.Map<UserDetailForDto>(getUser);
            return Ok(UserToReturn);
        }
    }
}