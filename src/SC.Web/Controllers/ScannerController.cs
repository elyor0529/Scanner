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
        private const string FileName = "Scanner_Scanner1_20180206.log";
        private static readonly string FilePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/App_Data"), FileName);
        private static readonly object CacheLocker = new object();

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
            var lines = (string[])WebCache.Get(FileName);

            if (lines == null)
            {
                lock (CacheLocker)
                {
                    lines = ParserHelper.ReadPointLines(FilePath);

                    WebCache.Set(FileName, lines);
                }
            }

            IList<object> values = null;
            if (lines.Length - 1 >= id)
                values = lines[id].ExtractPointValues();

            return Json(values, JsonRequestBehavior.AllowGet);
        }

    }
}
