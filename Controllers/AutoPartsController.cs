﻿using CarService.Models.AutoParts;
using CarService.Service;
using CarService.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    public class AutoPartsController : Controller
    {
        private readonly IAutoPartsService _autoPartsService;

        public AutoPartsController(IAutoPartsService autoPartsService)
        {
            _autoPartsService = autoPartsService;
        }

        public IActionResult Index()
        {
            var autoParts = _autoPartsService.GetAll();
            return View(autoParts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAutoPartsViewModel autoParts)
        {
            if (ModelState.IsValid)
            {
                _autoPartsService.Add(autoParts);
                return RedirectToAction(nameof(Index));
            }

           
            return View(autoParts);
        }

        public IActionResult Delete(int id)
        {
            _autoPartsService.Delete(id);  

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var autoParts = _autoPartsService.Get(id);
            if (autoParts == null)
            {
                return NotFound();
            }

            return View(autoParts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditAutoPartsViewModel autoParts)
        {
            if (ModelState.IsValid)
            {
                _autoPartsService.Edit(autoParts);
                return RedirectToAction(nameof(Index));
            }

            return View(autoParts);
        }

    }
}
