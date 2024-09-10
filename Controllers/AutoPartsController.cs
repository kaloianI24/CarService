using CarService.Models.AutoParts;
using CarService.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CarService.Controllers
{
    public class AutoPartsController : Controller
    {
        private readonly IAutoPartsService autoPartstService;
        public AutoPartsController(IAutoPartsService autoPartstService)
        {
            this.autoPartstService = autoPartstService;
        }

        public IActionResult Index()
        {
            var autoParts = autoPartstService.GetAll();
            return View(autoParts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateAutoPartsViewModel autoParts)
        {

            autoPartstService.Add(autoParts);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int id)
        {
          autoPartstService.Delete(id);
           

         return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit (int id)
        {
            var autoParts = autoPartstService.Get(id);

            return View(autoParts);
        }

        [HttpPost]
        public IActionResult Edit (EditAutoPartsViewModel autoParts)
        {
            autoPartstService.Edit(autoParts);

            return RedirectToAction(nameof(Index));

        }

    } 
}
