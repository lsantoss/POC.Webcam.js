using Microsoft.AspNetCore.Mvc;
using POC.Webcam.js.Models.Person;

namespace POC.Webcam.js.Controllers.Person;

public class PersonController : Controller
{
    private static readonly List<PersonViewModel> _personList = [];

    [HttpGet]
    public IActionResult Index()
    {
        var result = _personList.OrderBy(x => x.Id);
        return View(result);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(IFormCollection collection)
    {
        var person = new PersonViewModel();
        var modelIsValid = await TryUpdateModelAsync(person);

        if (modelIsValid)
        {
            person.Id = _personList.Count > 0 ? _personList.Max(x => x.Id) + 1 : 1;
            person.CypherPassword();
            _personList.Add(person);

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
    public IActionResult Delete(long id)
    {
        var person = _personList.FirstOrDefault(x => x.Id == id);
        return View(person);
    }

    [HttpPost]
    public IActionResult Delete(long id, IFormCollection collection)
    {
        var person = _personList.FirstOrDefault(x => x.Id == id);
        if (person != null)
            _personList.Remove(person);

        TempData["toastr-success"] = "Person successfully deleted!";
        return RedirectToAction("Index");
    }
}