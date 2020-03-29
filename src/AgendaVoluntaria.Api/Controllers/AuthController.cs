using AgendaVoluntaria.Api.Controllers.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers
{
    public class AuthController : CoreController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService, INotifier notifier) : base(notifier)
        {
            _authService = authService;
        }

        /// <summary>
        /// Autenticar Usuario
        /// </summary>
        /// <remarks>
        /// Metodo para realizar a autenticação do usuario, e receber o token jwt
        /// </remarks>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody]LoginRequest login)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var userToken = await _authService.Login(login);
            return CustomResponse("Usuario Autenticado!", userToken);
        }

        /// <summary>
        /// Cadastrar novo Usuario
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserRequest userResgister)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var user = await _authService.Register(userResgister);
            return CustomCreated("Usuario registrado!", user);
        }
    }
}