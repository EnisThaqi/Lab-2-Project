using AutoMapper;
using Lab2.DataService;
using Lab2.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserServiceController : ControllerBase
    {
        private readonly UserService _userService;

        public UserServiceController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create-for-subjects")]
        public async Task<IActionResult> CreateUserForSubjects([FromBody] UserSubjectRequest request)
        {
            try
            {
                await _userService.CreateUserForSubjects(request.User, request.SubjectIds);
                return Ok("User created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public class UserSubjectRequest
    {
        public UserDTO User { get; set; }
        public List<int> SubjectIds { get; set; }
    }
}
