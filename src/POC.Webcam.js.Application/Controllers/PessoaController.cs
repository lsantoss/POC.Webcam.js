using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Webcam.js.Application.Models.Error;
using POC.Webcam.js.Domain.Person.Entities;
using POC.Webcam.js.Domain.Person.Interfaces.Repositories;
using POC.Webcam.js.Infra.Helpers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POC.Webcam.js.Application.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPersonRepository _pessoaRepository;

        public PessoaController(IPersonRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pessoas = await _pessoaRepository.List();

            return View(pessoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var pessoa = new Person();
            await TryUpdateModelAsync(pessoa);

            pessoa.Password = HashHelper.GenerateHash(pessoa.Password);

            var id = await _pessoaRepository.Insert(pessoa);

            TempData["success"] = "Pessoa adicionada com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var pessoa = await _pessoaRepository.Get(id);

            return View(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, IFormCollection collection)
        {
            await _pessoaRepository.Delete(id);

            TempData["success"] = "Pessoa apagada com sucesso!";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}