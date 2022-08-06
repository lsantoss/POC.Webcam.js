using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Webcam.js.Application.Models.Error;
using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
using POC.Webcam.js.Infra.Helpers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace POC.Webcam.js.Application.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personList = await _personRepository.List();
            return View(personList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var person = new Person();
            await TryUpdateModelAsync(person);

            person.CypherPassword();

            await _personRepository.Insert(person);

            TempData["toastr-success"] = "Person added successfully!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var person = await _personRepository.Get(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, IFormCollection collection)
        {
            await _personRepository.Delete(id);

            TempData["toastr-success"] = "Person successfully deleted!";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}