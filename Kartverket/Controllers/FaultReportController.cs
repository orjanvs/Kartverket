using Kartverket.Data;
using Kartverket.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kartverket.Controllers
{
    public class FaultReportController : Controller
    {
        private readonly KartverketDbContext _kartverketDbContext;

        public FaultReportController(KartverketDbContext kartverketDbContext)
        {
            _kartverketDbContext = kartverketDbContext;
        }

        [HttpGet]
        public IActionResult FaultReportForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToFaultReportForm(FaultReportModel faultReportModel)
        {
            if (faultReportModel == null)
            {
                return BadRequest();
            }

            var faultReport = new FaultReportModel
            {
                Longitude = faultReportModel.Longitude,
                Latitude = faultReportModel.Latitude,
                Description = faultReportModel.Description
            };

            await _kartverketDbContext.FaultReports.AddAsync(faultReport);
            await _kartverketDbContext.SaveChangesAsync();

            return RedirectToAction("FaultReportList");
        }

        [HttpGet]
        [ActionName("FaultReportList")]
        public async Task<IActionResult> FaultReportList()
        {
            var faultReports = await _kartverketDbContext.FaultReports.ToListAsync();

            return View(faultReports);
        }

        [HttpPost]
        public async Task<IActionResult> FaultReportEdit()
           {

        }
    }
}
