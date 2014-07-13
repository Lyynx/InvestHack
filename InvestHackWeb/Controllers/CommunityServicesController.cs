using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InvestHackWeb.Models;

namespace InvestHackWeb.Controllers
{
    public class CommunityServicesController : ApiController
    {
        private investhack_dbEntities db = new investhack_dbEntities();

        // GET: api/CommunityServices
        public IQueryable<CommunityService> GetCommunityServices()
        {
            return db.CommunityServices;
        }

        // GET: api/CommunityServices/5
        //[ResponseType(typeof(CommunityService))]
        //public async Task<IHttpActionResult> GetCommunityService(string id)
        //{
        //    CommunityService communityService = await db.CommunityServices.FindAsync(id);
        //    if (communityService == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(communityService);
        //}

        // GET: api/CommunityServices/woodlands
        // [ResponseType(typeof(CommunityService))]
        [HttpGet]
        public IQueryable<CommunityService> GetCommunityService(string id)
        {
            var communityServices = db.CommunityServices.Where(c => c.Suburb.ToLower() == id.ToLower());
            return communityServices;
        }

        // PUT: api/CommunityServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCommunityService(string id, CommunityService communityService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != communityService.ServiceApprovalNumber)
            {
                return BadRequest();
            }

            db.Entry(communityService).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CommunityServices
        [ResponseType(typeof(CommunityService))]
        public async Task<IHttpActionResult> PostCommunityService(CommunityService communityService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommunityServices.Add(communityService);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommunityServiceExists(communityService.ServiceApprovalNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = communityService.ServiceApprovalNumber }, communityService);
        }

        // DELETE: api/CommunityServices/5
        [ResponseType(typeof(CommunityService))]
        public async Task<IHttpActionResult> DeleteCommunityService(string id)
        {
            CommunityService communityService = await db.CommunityServices.FindAsync(id);
            if (communityService == null)
            {
                return NotFound();
            }

            db.CommunityServices.Remove(communityService);
            await db.SaveChangesAsync();

            return Ok(communityService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommunityServiceExists(string id)
        {
            return db.CommunityServices.Count(e => e.ServiceApprovalNumber == id) > 0;
        }
    }
}