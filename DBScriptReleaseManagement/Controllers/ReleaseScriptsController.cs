using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DBScriptReleaseManagement.Models;

namespace DBScriptReleaseManagement.Controllers
{
    public class ReleaseScriptsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/ReleaseScripts
        public IQueryable<ReleaseScript> GetReleaseScripts(int releaseId = 0)
        {
            IQueryable<ReleaseScript> releaseScriptsList = db.ReleaseScripts.Where(fn => fn.ReleaseId == releaseId);

            return releaseScriptsList;
        }

        // GET: api/ReleaseScripts/5
        [ResponseType(typeof(ReleaseScript))]
        public IHttpActionResult GetReleaseScript(int id)
        {
            ReleaseScript releaseScript = db.ReleaseScripts.Find(id);
            if (releaseScript == null)
            {
                return NotFound();
            }

            return Ok(releaseScript);
        }

        // PUT: api/ReleaseScripts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReleaseScript(int id, ReleaseScript releaseScript)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != releaseScript.ReleaseScriptId)
            {
                return BadRequest();
            }

            db.Entry(releaseScript).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseScriptExists(id))
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

        // POST: api/ReleaseScripts
        [ResponseType(typeof(ReleaseScript))]
        public IHttpActionResult PostReleaseScript(ReleaseScript releaseScript)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReleaseScripts.Add(releaseScript);
            db.Entry(releaseScript).State = EntityState.Added;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = releaseScript.ReleaseScriptId }, releaseScript);
        }

        // DELETE: api/ReleaseScripts/5
        [ResponseType(typeof(ReleaseScript))]
        public IHttpActionResult DeleteReleaseScript(int id)
        {
            ReleaseScript releaseScript = db.ReleaseScripts.Find(id);
            if (releaseScript == null)
            {
                return NotFound();
            }

            db.ReleaseScripts.Remove(releaseScript);
            db.SaveChanges();

            return Ok(releaseScript);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReleaseScriptExists(int id)
        {
            return db.ReleaseScripts.Count(e => e.ReleaseScriptId == id) > 0;
        }
    }
}