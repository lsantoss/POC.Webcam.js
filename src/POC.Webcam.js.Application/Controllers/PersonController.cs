using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Webcam.js.Application.Models.Error;
using POC.Webcam.js.Domain.Persons.Entities;
using POC.Webcam.js.Domain.Persons.Interfaces.Repositories;
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
            var personList = await _personRepository.ListAsync();
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
            var modelIsValid = await TryUpdateModelAsync(person);

            if (modelIsValid)
            {
                person.CypherPassword();

                await _personRepository.InsertAsync(person);

                TempData["toastr-success"] = "Person added successfully!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["toastr-error"] = "Error getting form data!";

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var person = await _personRepository.GetAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, IFormCollection collection)
        {
            await _personRepository.DeleteAsync(id);

            TempData["toastr-success"] = "Person successfully deleted!";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}