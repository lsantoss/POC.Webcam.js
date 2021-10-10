using FormWebcamJs.Domain.Interfaces.Repositories;
using FormWebcamJs.Domain.Models.Erro;
using FormWebcamJs.Domain.Models.Pessoa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FormWebcamJs.Infra.Hash;

namespace FormWebcamJs.WebApp.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.Listar();

            return View(pessoas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            var pessoa = new PessoaViewModel();
            TryUpdateModelAsync(pessoa);

            pessoa.Senha = HashHelper.GerarHash(pessoa.Senha);

            var id = _pessoaRepository.Salvar(pessoa);

            TempData["success"] = "Pessoa adicionada com sucesso!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var pessoa = _pessoaRepository.Obter(id);

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Delete(long id, IFormCollection collection)
        {
            _pessoaRepository.Deletar(id);

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