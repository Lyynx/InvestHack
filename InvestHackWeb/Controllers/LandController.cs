using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InvestHackWeb.Controllers
{
    [EnableCors(origins: "http://investhack.azurewebsites.net, http://localhost:35327", headers: "*", methods: "*")]
    public class LandController : ApiController
    {
        // GET: api/Land
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Land/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Land
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Land/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Land/5
        public void Delete(int id)
        {
        }
    }
}
