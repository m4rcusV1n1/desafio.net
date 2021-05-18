using ApplicationDesafioNet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationDesafioNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _appEnvironment = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<dynamic>> postApi()
        {
            List<import> data = new List<import>();
            Shipping shipping = new Shipping();
           
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _appEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            try
            {
                if (file.Length > 0)
                {
                    string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                    string fullPath = Path.Combine(newPath, file.FileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                       
                    }

                    string[] lines = System.IO.File.ReadAllLines(fullPath);

                    foreach (string line in lines)
                    {
                        var SubTipo = line.Substring(0,1);
                        var SubData = line.Substring(1,4) + "-" +line.Substring(5, 2) + "-" + line.Substring(7, 2);
                        var SubValor = line.Substring(9, 10);
                        var SubCPF = line.Substring(19, 11);
                        var SubCartao = line.Substring(30, 12);
                        var SubHora = line.Substring(42, 2) + ":"+line.Substring(44, 2) + ":" + line.Substring(46, 2);
                        var SubDonoLoja = line.Substring(48, 14).Trim();
                        var SubNomeLoja = line.Substring(62).Trim();
                        data.Add(new import() { 
                            Tipo = Convert.ToInt32(SubTipo), 
                            Data = Convert.ToDateTime(SubData), 
                            Valor = Convert.ToDecimal(SubValor) / 100, 
                            CPF = SubCPF, 
                            Cartao = SubCartao, 
                            Hora= Convert.ToDateTime(SubHora).ToString("hh:mm:ss"), 
                            DonoLoja=SubDonoLoja, 
                            NomeLoja=SubNomeLoja});
                    }

                    var SendApi = shipping.SendListData(data);
                    return new
                    {
                        Inseridos = SendApi.Inserido,
                        Error = SendApi.Error
                    };


                }
                else
                {
                    return new { message = "Sem arquivo" };
                }
                
            }
            catch(Exception ex)
            {
                return new { message = ex.Message };
            }
           
       
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
