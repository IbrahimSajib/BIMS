﻿using BIMS.DataAccess.Models;
using BIMS.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Presentation.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _sService;

        public SupplierController(ISupplierService sService)
        {
            _sService = sService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _sService.GetAllSupplier();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier model)
        {
            if (ModelState.IsValid)
            {
                var data = await _sService.Create(model);
                if (data)
                {
                    TempData["success"] = "Supplier Successfuly Added";
                }
                else
                {
                    TempData["failed"] = "Saved Failed";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _sService.GetSupplierById(id);
            if (data == null)
            {
                ViewBag.ErrorMessage = "Supplier Not Found";
                return View("NotFound");
            }

            return View(data);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier model)
        {
            if (ModelState.IsValid)
            {
                var data = await _sService.Edit(model);
                if (data)
                {
                    TempData["success"] = "Supplier Successfuly Updated";
                }
                else
                {
                    TempData["failed"] = "Update Failed";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
