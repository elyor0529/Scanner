using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using SC.Common.Helpers;
using SC.Model.Entity;
using SC.Service;
using SC.Service.Infrastructure;
using SC.Web.Filters;

namespace SC.Web.Controllers
{
    public class ScannerController : Controller
    {
        private readonly IScannerService _scannerService;
        private readonly IDataTupleService _tupleService;
        private readonly ITupleItemService _itemService;
        private static readonly IList<object[]> _results;
        private const string FileName = "Scanner_Scanner1_20180206.log";

        static ScannerController()
        {
            var path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/App_Data"),FileName);

            _results = ParserHelper.GetPoints(path);
        }

        public ScannerController(IScannerService scannerService)
        {
            _scannerService = scannerService;
        }

        public ScannerController(IScannerService scannerService, IDataTupleService tupleService, ITupleItemService itemService) : this(scannerService)
        {
            _tupleService = tupleService;
            _itemService = itemService;
        }

        public ActionResult Chart1()
        {
            ViewBag.Title = FileName;

            return View();
        }

        public ActionResult Chart2()
        {
            ViewBag.Title = FileName;

            return View();
        }

        public ActionResult Chart3()
        {
            ViewBag.Title = FileName;

            return View();
        }

        [HttpPost]
        public ActionResult GetData(int id)
        {
            if (id > _results.Count)
                return Json(null, JsonRequestBehavior.AllowGet);

            return Json(_results[id], JsonRequestBehavior.AllowGet);
        } 

    }
}
