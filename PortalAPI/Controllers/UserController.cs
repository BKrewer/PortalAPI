using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using PortalAPI.Services;
using PortalAPI.ViewModels;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;

        public UserController(IUserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Login([FromBody] LoginRequest loginRequest, [FromServices] TokenService tokenService, [FromServices] PasswordService passwordService)
        {
            bool validCredentials = false;
            User userDb = _user.GetByEmail(loginRequest.Email);

            if (userDb != null && userDb.Status == 1)
            {
                bool passwordValid = passwordService.PasswordValidate(loginRequest.Password, userDb.Password);

                if (!passwordValid)
                {
                    return BadRequest(new { authenticated = false, message = "Usuário ou senha incorretos" });
                }

                validCredentials = (userDb != null &&
                        loginRequest.Email == userDb.Email);
            }

            if (validCredentials)
            {
                var token = tokenService.GenerateToken(userDb);
                userDb.Password = "";

                var userResponse = _mapper.Map<UserResponse>(userDb);

                return new
                {
                    userResponse,
                    token
                };
            }

            return BadRequest(new { message = "Usuário ou senha incorretos" });
        }

        [HttpGet("recoverypassword/{email}")]
        [AllowAnonymous]
        public IActionResult PasswordRecovery(string email, [FromServices] EmailService emailService, [FromServices] PasswordService passwordService)
        {
            User userDb = _user.GetByEmail(email);

            if (userDb != null)
            {
                string newPassword = passwordService.KeyGenerator(8);

                userDb.Password = newPassword;
                emailService.SendNewPassword(userDb);

                string passwordEncrypted = passwordService.PasswordEncrypt(newPassword);
                userDb.Password = passwordEncrypted;
                userDb.ConfirmPassword = passwordEncrypted;
                _user.Update(userDb);

                return Ok(new { message = "Senha enviada para seu email com sucesso!" });
            }

            return NotFound(new { message = "Email não encontrado" });
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [Authorize(Roles = "employee, admin")]
        public IActionResult Get(string id)
        {
            User userDb = _user.Get(id);
            var userResponse = _mapper.Map<UserResponse>(userDb);
            return Ok(userResponse);
        }

        [HttpGet]
        [Authorize(Roles = "employee, admin")]
        public IActionResult GetAll()
        {
            var usersDb = _user.GetAll();
            var usersResponse = _mapper.Map<ICollection<UserResponse>>(usersDb);
            return Ok(usersResponse);
        }

        [HttpGet("allusers")]
        [Authorize(Roles = "employee, admin")]
        public IActionResult GetAllUsers()
        {
            var usersDb = _user.GetAllUsers();
            var usersResponse = _mapper.Map<ICollection<UserResponse>>(usersDb);
            return Ok(usersResponse);
        }

        [HttpGet("allemployees")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllEmployees()
        {
            var usersDb = _user.GetAllEmployees();
            var usersResponse = _mapper.Map<ICollection<UserResponse>>(usersDb);
            return Ok(usersResponse);
        }

        [HttpGet("alladmins")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllAdmins()
        {
            var usersDb = _user.GetAllAdmins();
            var usersResponse = _mapper.Map<ICollection<UserResponse>>(usersDb);
            return Ok(usersResponse);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody] UserRequest userRequest, [FromServices] PasswordService passwordService)
        {
            if (ModelState.IsValid)
            {
                User newUser = _mapper.Map<User>(userRequest);
                string passwordEncrypted = passwordService.PasswordEncrypt(userRequest.Password);
                newUser.Password = passwordEncrypted;
                newUser.ConfirmPassword = passwordEncrypted;
                _user.Register(newUser);
                return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(string id, [FromBody] UserRequest userRequest, [FromServices] PasswordService passwordService)
        {
            User userDb = _user.Get(id);

            if (userDb != null)
            {
                User userUpdated = _mapper.Map(userRequest, userDb);
                string passwordEncrypted = passwordService.PasswordEncrypt(userRequest.Password);
                userUpdated.Password = passwordEncrypted;
                userUpdated.ConfirmPassword = passwordEncrypted;
                _user.Update(userUpdated);
                return Ok(userUpdated);
            }

            return NotFound(new { message = "Usuário não encontrado" });
        }

        [HttpPatch("changestatus/{id}")]
        [Authorize(Roles = "employee, admin")]
        public IActionResult ChangeStatus(string id)
        {
            User userDb = _user.Get(id);
            if (userDb != null)
            {
                userDb.Status = (userDb.Status == 1) ? userDb.Status = 2 : userDb.Status = 1;
                _user.Update(userDb);

                return Ok(userDb);
            }

            return NotFound(new { message = "Usuário não encontrado" });
        }

        [HttpPatch("changerole/{id}/{userRole}")]
        [Authorize(Roles = "admin")]
        public IActionResult ChangeRole(string id,string userRole)
        {
            User userDb = _user.Get(id);
            if (userDb != null)
            {
                userDb.Role = userRole;
                _user.Update(userDb);

                return Ok(userDb);
            }

            return NotFound(new { message = "Usuário não encontrado" });
        }
    }
}