using BIMS.DataAccess.ViewModels;
using BIMS.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Presentation.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IDDLService _ddlService;

        public ReportController(IReportService reportService, IDDLService ddlService)
        {
            _reportService = reportService;
            _ddlService = ddlService;
        }

        public async Task<IActionResult> Inventory()
        {
            InventoryReportVM model = new InventoryReportVM();
            model.CategoryDDL = await _ddlService.GetCategoryDDL();
            ViewBag.ShowResult = false;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Inventory(InventoryReportVM model)
        {
            var data = await _reportService.GetInventoryReport(model);
            data.CategoryDDL = await _ddlService.GetCategoryDDL();
            ViewBag.ShowResult = true;
            return View(data);
        }


    }
}
