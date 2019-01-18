using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Filters;

namespace EmployeesWeb.Decorators
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {

        private ILog Logger { get; set; }

        public ExceptionHandlingAttribute()
        {
            Logger = LogManager
                .GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Stongly typed object for XML serialization
        /// </summary>
        public class PlainErrorMessage
        {
            /// <summary>
            /// HTTP Error Code
            /// </summary>
            public HttpStatusCode status { get; set; }

            /// <summary>
            /// Error list
            /// </summary>
            public IEnumerable<string> errors { get; set; }
        }

        private System.Net.Http.Formatting.MediaTypeFormatter
            ComputeFormatter(HttpActionExecutedContext localContext)
        {

            if (localContext.Request.Headers.Accept == null)
                return GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            var acceptType = localContext.Request.Headers.Accept.First();

            switch (acceptType.MediaType)
            {
                case "application/xml":
                    return GlobalConfiguration.Configuration.Formatters.XmlFormatter;
                default:
                    return GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            }
        }

        public override void OnException(HttpActionExecutedContext context)
        {            
            Logger.Error("Critical Exception: " + context.Request.RequestUri.ToString() + " - Message: " + context.Exception.Message + " Stack trace: " + context.Exception.StackTrace);

            throw new HttpResponseException(new
            HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent(typeof(PlainErrorMessage),
                new PlainErrorMessage
                {
                    status = HttpStatusCode.InternalServerError,
                    errors = new string[] { "An error occurred, please try again or contact the administrator." }
                }, ComputeFormatter(context)),
                ReasonPhrase = "Critical Exception",
                StatusCode = HttpStatusCode.InternalServerError
            });            
        }
    }
}