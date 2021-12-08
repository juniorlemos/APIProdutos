using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Application.DTOs;
using Modelo.Application.DTOs.ModelView;
using Modelo.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace APIProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenService<UsuarioAutenticacaoDto> token;
        private readonly ILogger<AccountController> _logger;


        public AccountController(UserManager<IdentityUser> userManager, ITokenService<UsuarioAutenticacaoDto> token,
             ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.token = token;
            _logger = logger;

        }



        /// <summary>
        /// Realiza o login de um usuario para receber um Token
        /// </summary>
        /// <param Username="UsuarioAutenticacaoDto"></param>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(UsuarioTokenView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UsuarioAutenticacaoDto login)
        {
            var usuario = await userManager.FindByNameAsync(login.Username);

            if (usuario != null && await userManager.CheckPasswordAsync(usuario, login.Password))
            {

                var tokenGerado = token.GenerateToken(login);

                return Ok(
                    new UsuarioTokenView{
                                          Usuario = usuario.UserName,
                                          Token = tokenGerado
                                          });

            }

            return Unauthorized();
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param Username="UsuarioAutenticacaoDto"></param>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(ResponseView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseView), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UsuarioAutenticacaoDto register)
        {
            var usuario = await userManager.FindByNameAsync(register.Username);

            if (usuario != null)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                  new ResponseView { Status = "Error", Message = "Usuario já existe" });

            IdentityUser novoUsuario = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };

            var resultado = await userManager.CreateAsync(novoUsuario, register.Password);



            if (resultado.Succeeded)

                return Ok(new ResponseView { Status = "Success", Message = "Usuario criado com Sucesso" });


            return BadRequest(resultado.Errors);



        }
    }
}
