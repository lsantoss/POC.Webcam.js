using FormWebcamJs.Domain.Interfaces.Repositories;
using FormWebcamJs.Domain.Models.Erro;
using FormWebcamJs.Domain.Models.Pessoa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormWebcamJs.WebApp.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IActionResult Index()
        {
            var pessoas = _pessoaRepository.Listar();
            return View(pessoas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            var pessoa = new PessoaViewModel();
            TryUpdateModelAsync(pessoa);

            if (pessoa.ImagemBase64String is null)
                pessoa.DefinirImagemBase64StringGenerica();

            var id = _pessoaRepository.Salvar(pessoa);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}