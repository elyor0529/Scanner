using System.IO.Compression;
using System.Web.Mvc;

namespace SC.Web.Filters
{
    public class OptimizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() ||
                filterContext.ActionDescriptor.IsDefined(typeof(ChildActionOnlyAttribute), true) ||
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                return;

            var response = filterContext.HttpContext.Response;

            //compress
            var request = filterContext.HttpContext.Request;
            var acceptEncoding = request.Headers["Accept-Encoding"];
            if (!string.IsNullOrWhiteSpace(acceptEncoding))
            {
                acceptEncoding = acceptEncoding.ToUpperInvariant();

                if (acceptEncoding.Contains("GZIP"))
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("DEFLATE"))
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }

            //remove white space
            response.Filter = new WhiteSpaceFilter(response.Filter);
        }
    }
}