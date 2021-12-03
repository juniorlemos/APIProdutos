using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Service.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;


        }



      

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioAutenticacao login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {

              
                var token = TokenService.GenerateToken(login);


                return Ok(new
                UsuarioTokenView {

                   Usuario = user.UserName,
                  
                   Token=token 
                    

                }) ;

               
                    
               
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult>Register([FromBody] UsuarioAutenticacao register)
        {
            var userExists = await userManager.FindByNameAsync(register.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseView { Status = "Error", Message = "Usuario já existe" });

            IdentityUser user = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseView { Status = "Error", Message = "Erro na criação do Usuario" });

            return Ok(new ResponseView { Status = "Success", Message = "Usuario criado com Sucesso" });
        }
    }
}
