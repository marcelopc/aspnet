﻿using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Aplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService service)
        {
            _userService = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok( await _userService.GetAll());
            }
            catch (ArgumentException error)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, error.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _userService.Get(id));
            }
            catch (ArgumentException error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, error.Message);
            }
        }

    }
 
}
