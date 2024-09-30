using BIMS.DataAccess.Models;
using BIMS.Services.IService;
using BIMS.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Presentation.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseServic _pService;
        private readonly IDDLService _ddlService;

        public PurchaseController(IPurchaseServic pService)
        {
            _pService = pService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _pService.GetAllPurchaseOrder();
            return View(data);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PurchaseOrder model = new PurchaseOrder();
            model.ProductDDL = await _ddlService.GetProductDDL();
            model.SupplierDDL = await _ddlService.GetSupplierDDL();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder model)
        {
            if (ModelState.IsValid)
            {
                var data = await _pService.Create(model);
                if (data)
                {
                    TempData["success"] = "Purchase Order Successfuly Created";
                }
                else
                {
                    TempData["failed"] = "Saved Failed";
                }
                return RedirectToAction("Index");
            }
            model.ProductDDL = await _ddlService.GetProductDDL();
            model.SupplierDDL = await _ddlService.GetSupplierDDL();
            return View(model);
        }
    }
}
