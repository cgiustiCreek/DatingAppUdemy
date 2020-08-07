using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IDatingRepository repository;

		public readonly IMapper mapper;

		public UserController(IDatingRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await repository.GetUsers();

			var userToReturn = mapper.Map<IEnumerable<UserForListDto>>(users);

			return Ok(userToReturn);
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult> GetUser(int id)
		{
			var user = await repository.GetUser(id);

			var userToReturn = mapper.Map<UserForDetailDto>(user);

			return Ok(userToReturn);
		}
	}
}
