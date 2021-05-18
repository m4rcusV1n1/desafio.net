using ApiDesafioDotnet.Data;
using ApiDesafioDotnet.Models;
using ApiDesafioDotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafioDotnet.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Primeiro passso para gerar o token passando o login e senha disponibilizado na documentação do Git obs: para acessar os metodos abaixo é necessário gerar o token.
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("generatetoken")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext _db,
            [FromBody] User model)
        {
           
            var auth = _db.Auth.FirstOrDefault(x => x.Login == model.Login && x.Password == model.Password);
            if (auth == null)
            {
                return NotFound(new { message = "Usuário ou senha inválido" });
            }
            if (auth != null) 
            { 
                var token = TokenService.GenerateToken(auth);
                auth.Password = "";
                return new
                {
                    user = auth,
                    token = token
                };
            }
            else
            {
                return NotFound(new { message = "Usuário ou senha inválido" });
            }
        }
    }
}
