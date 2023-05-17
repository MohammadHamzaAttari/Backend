using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Backend.Dtos.User;
using Backend.Contracts;
using Backend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Authorization;
using UserManagementService.Services;
using UserManagementService.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public Account(IAuthManager authManager, UserManager<ApiUser> userManager, IMapper mapper,IEmailService emailService)
        {
            _authManager = authManager;
            this._userManager = userManager;
            this._mapper = mapper;
            this._emailService = emailService;
        }
        [HttpGet]
        [Route("register")]
        public async Task<ActionResult<List<ApiUserDto>>> GetRegisterUsers(){
            var record = await _userManager.Users.ToListAsync();
            if (record == null)
            {
                return BadRequest("Users not exists");
            }
            var users = _mapper.Map<List<ApiUserDto>>(record);
            return Ok(users);
}
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            var errors = await _authManager.Register(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok();
        }
        //Post;Login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var authResponse = await _authManager.Login(loginUserDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
        /*  [AllowAnonymous]
          [HttpPost]
          public async Task<IActionResult> ForgotPassword(string email)
          {
              var user = await _userManager.FindByEmailAsync(email);

              if (user == null)
              {
                  return BadRequest("The specified email address is not found.");
              }

              var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

              var uri = Url.Action("ResetPassword", "Account", new { resetToken });

              var mailOptions = new MailOptions
              {
                  Subject = "Reset Your Password",
                  Body = $"Please click on the following link to reset your password: {uri}",
                  To = user.Email
              };

              await _emailSender.SendEmailAsync(mailOptions);

              return Ok();
          }*/
        [HttpGet]
        public async Task<IActionResult> TestEmail()
        {
            var message = new Message(new string[] { "qomaise3@gmail.com" }, "<h1>Email Send Succesfully</h1>", "testing" );
          
            _emailService.SendEmail(message);
            return Ok("Email send Successfully");
        }
    }
}
