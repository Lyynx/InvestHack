using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.WindowsAzure.Mobile.Service;

namespace investhackService.Controllers
{
  //  [EnableCors(origins: "http://localhost:35327", // Origin
  //            headers: "*",                     // Request headers
  //            // "GET",                    // HTTP methods
  //            methods: "*"  //, // null,                    // Response headers  'bar'
  //            //SupportsCredentials = true  // Allow credentials
  //)]
    [EnableCors(origins: "http://investhack.azurewebsites.net, http://localhost:35327", headers: "*", methods: "*")]

    public class LandController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Land
        [HttpGet]
        public string Get()
        {
            Services.Log.Info("Hello from custom controller!"); 
            return "Hello";
        }

    }
}
