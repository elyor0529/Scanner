using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SC.Repository.Infrastructure;

namespace SC.Web.Helpers
{
    public static class UIHelper
    {
        private const string ScannerCacheKey = "_scanner_cache_key_";

        public static IHtmlString RenderScannerItems(this HtmlHelper helper)
        {
            var cacheResult = (string)WebCache.Get(ScannerCacheKey);

            if (String.IsNullOrWhiteSpace(cacheResult))
            {
                var appender = new StringBuilder();
                var repo = DependencyResolver.Current.GetService<IScannerRepository>();
                var url = new UrlHelper(helper.ViewContext.RequestContext);

                foreach (var scanner in repo.GetAll())
                {
                    appender.AppendFormat(@"<li><a href='{0}'>  <span class='glyphicon glyphicon-print' aria-hidden='true'></span> {1} </a></li>", url.Action("Index", "Scanner", new { id = scanner.Id }), scanner.Name);
                }

                cacheResult = appender.ToString();

                WebCache.Set(ScannerCacheKey, cacheResult);
            }

            return helper.Raw(cacheResult);
        }

    }
}