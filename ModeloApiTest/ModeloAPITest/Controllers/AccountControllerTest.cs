using APIProduto.Controllers;
using DataFake.ProdutoData;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modelo.Application.DTOs;
using Modelo.Domain.Interfaces.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ModeloApiTest.ModeloAPITest.Controllers
{
    public class AccountControllerTest
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AccountController _accountController;
        private readonly UsuarioAutenticacaoDto _usuarioAtenticacaoDto;
        private readonly ITokenService<UsuarioAutenticacaoDto> _token;
        private readonly ILogger<AccountController> _logger;

        public AccountControllerTest()
        {
            _userManager = Substitute.For<UserManager<IdentityUser>>(Substitute.For<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

            _token = Substitute.For<ITokenService<UsuarioAutenticacaoDto>>();
            _logger = Substitute.For<ILogger<AccountController>>();

            _accountController = new AccountController(_userManager, _token,_logger);

            _usuarioAtenticacaoDto = new UsuarioAutenticacaoDtoFaker().Generate();
        }

        [Fact]

        public async Task ControllerMetodoLoginRetornaNãoAutorizadoPorqueOUsuarioNulo_()
        {


            _userManager.FindByNameAsync(_usuarioAtenticacaoDto.Username).ReturnsNull();


            var conta = (UnauthorizedResult)await _accountController.Login(_usuarioAtenticacaoDto);


            conta.StatusCode.Should().Be(StatusCodes.Status401Unauthorized);

        }

        [Fact]

        public async Task ControllerMetodoLoginRetornaNãoAutorizadoPorquePassowrdErrado_()
        {

            IdentityUser user = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "fernando"

            };

            UsuarioAutenticacaoDto usuario = new UsuarioAutenticacaoDto()
            {
                Username = "juniopr",
                Password = "234234243"
            };



            _userManager.FindByNameAsync(_usuarioAtenticacaoDto.Username).Returns(user);
            _userManager.CheckPasswordAsync(user, _usuarioAtenticacaoDto.Password).Returns(true);
            _token.GenerateToken(usuario).Returns("sdasdaqwedasdasdasdas");


            var conta = (ObjectResult)await _accountController.Login(_usuarioAtenticacaoDto);


            conta.StatusCode.Should().Be(StatusCodes.Status200OK);

        }


        [Fact]

        public async Task ControllerMetodoRegisterRetornaErro_500_Porque_O_UsuarioJaExiste_()
        {

            IdentityUser user = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = _usuarioAtenticacaoDto.Username

            };
            _userManager.FindByNameAsync(_usuarioAtenticacaoDto.Username).Returns(user);


            var conta = (ObjectResult)await _accountController.Register(_usuarioAtenticacaoDto);


            conta.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);

        }


        [Fact]

        public async Task ControllerMetodoRegisterUsuarioCriadoComSucesso()
        {






            _userManager.FindByNameAsync(_usuarioAtenticacaoDto.Username).ReturnsNull();



            _userManager.CreateAsync(Arg.Any<IdentityUser>(), _usuarioAtenticacaoDto.Password).Returns(IdentityResult.Success);




            var conta = (ObjectResult)await _accountController.Register(_usuarioAtenticacaoDto);


            conta.StatusCode.Should().Be(StatusCodes.Status200OK);

        }



        [Fact]

        public async Task ControllerMetodoRegisterErroNaCriaçaoDoUsuarioRetornaBadRequest()
        {






            _userManager.FindByNameAsync(_usuarioAtenticacaoDto.Username).ReturnsNull();



            _userManager.CreateAsync(Arg.Any<IdentityUser>(), _usuarioAtenticacaoDto.Password).Returns(IdentityResult.Failed());




            var conta = (ObjectResult)await _accountController.Register(_usuarioAtenticacaoDto);


            conta.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

        }
    }
}
