using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SC.Common;
using SC.Service.Infrastructure;
using SC.Web.Filters;
using SC.Web.Models;

namespace SC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScannerService _scannerService;

        public HomeController()
        {

        }

        public HomeController(IScannerService scannerService)
        {
            _scannerService = scannerService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _scannerService.GetAll().Include(a => a.Tuples).Select(s => new DashboardViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Total = s.Tuples.Count
            }).ToArrayAsync();

            return View(model);
        }

        public ActionResult Upload()
        {
            var model = new LogFileViewModel
            {
                Scanners = _scannerService.GetAll().ToDictionary(a => a.Id, a => a.Name)
            };

            return PartialView("_Upload", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(LogFileViewModel model)
        {
            if (ModelState.IsValid && model.LogFile.ContentLength > 0)
            {
                var path = Path.Combine(MainSettings.UploadFolder, string.Format("data-{0:yyyy-MM-dd_hh-mm-ss-tt}.log", DateTime.Now));

                //backup file
                model.LogFile.SaveAs(path);

                //import file
                _scannerService.Import(model.ScannerId, path);
            }

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            var error = (string)Session["last-error"];

            if (string.IsNullOrWhiteSpace(error))
                return View();

            Session["last-error"] = null;

            return View(new HandleErrorInfo(new Exception(error), "Home", "Error"));

        }

    }
}