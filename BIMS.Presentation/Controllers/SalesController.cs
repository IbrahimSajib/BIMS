﻿using BIMS.DataAccess.Models;
using BIMS.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Presentation.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;
        private readonly IDDLService _ddlService;

        public SalesController(ISalesService salesService, IDDLService ddlService)
        {
            _salesService = salesService;
            _ddlService = ddlService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _salesService.GetAllSalesOrder();
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SalesOrder model = new SalesOrder();
            model.ProductDDL = await _ddlService.GetAvailableProductDDL();
            model.CustomerDDL = await _ddlService.GetCustomerDDL();
            model.Quantity = 1;
            model.SalePrice = 1;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesOrder model)
        {
            if (ModelState.IsValid)
            {
                var data = await _salesService.Create(model);
                if (data)
                {
                    TempData["success"] = "Sales Order Successfuly Created";
                }
                else
                {
                    TempData["failed"] = "Saved Failed";
                }
                return RedirectToAction("Index");
            }
            model.ProductDDL = await _ddlService.GetAvailableProductDDL();
            model.CustomerDDL = await _ddlService.GetCustomerDDL();
            return View(model);
        }

    }
}
