using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Employees.DAL
{
    /// <summary>
    /// Singleton for creating a REST Client
    /// </summary>
    public sealed class RestClient
    {
        private static readonly HttpClient instance = new HttpClient();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RestClient()
        {
            instance.BaseAddress = new Uri(ConfigurationManager.AppSettings["Employees-Endpoint"]);
            instance.DefaultRequestHeaders.Accept.Clear();
            instance.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private RestClient()
        {
        }

        /// <summary>
        /// Returns the singleton Instance of the REST Client
        /// </summary>
        public static HttpClient Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
