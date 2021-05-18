using ApiDesafioDotnet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDesafioDotnet.Data;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ApiDesafioDotnet.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class HomeController : ControllerBase
    {
        public IConfiguration _configuration;
        private IWebHostEnvironment _hostingEnvironment;

        /// <summary>
        /// database connection config
        /// </summary>
        /// <param name="configuration"></param>
        public HomeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _hostingEnvironment = env;
        }
        /// <summary>
        /// Lista dos os itens exportado pelo txt
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="imports"></param>
        /// <returns>Lista dos os itens exportado pelo txt</returns>
        [Route("GetItems")]
        [HttpGet]
        [Authorize(Roles = "administrador")]
        public ActionResult <IEnumerable<importFile>> getAllItems([FromServices] DataContext _db)
        {
            try
            {
                var Ret = _db.Imports.Select(x => x).ToList();
                return Ret;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        /// <summary>
        /// Insere dados dos itens tratados no frontEnd
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="import"></param>
        /// <returns>Insere dados dos itens tratados no frontEnd</returns>
        [Route("insertItems")]
        [HttpPost]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult<dynamic>> insertItems(
            [FromServices] DataContext _db,
            [FromBody] List<importFile> imports)
        {
            try
            {
                int coutOk = 0;
                int coutError = 0;
                foreach (var import in imports)
                {
                    _db.Imports.Add(import);
                    try
                    {
                        await _db.SaveChangesAsync();
                        coutOk++;
                    }
                    catch (Exception ex)
                    {
                        coutError++;
                    }

                }
                Response.StatusCode = 200;
                return new
                {
                    Inserido = coutOk,
                    Error = coutError
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
            
        }
    }
}
