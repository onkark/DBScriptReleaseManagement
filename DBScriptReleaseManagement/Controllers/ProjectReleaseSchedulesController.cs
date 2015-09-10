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
	public class ProjectReleaseSchedulesController : ApiController
	{
		private Entities db = new Entities();

		// GET: api/ProjectReleaseSchedules
		public IQueryable<ProjectReleaseSchedule> GetProjectReleaseSchedules(int projectId = 0)
		{
			IQueryable<ProjectReleaseSchedule> releaseScheduleList = db.ProjectReleaseSchedules.Where(fn => fn.ProjectId == projectId);

			var releaseStatusList = db.ItemLists.Where(fn => fn.GroupName == "ReleaseStatus");

			foreach (var item in releaseScheduleList)
			{
				item.ReleaseStatusItemName = releaseStatusList.First(fn => fn.ItemValue == item.ReleaseStatusId).ItemName;
			}
			return releaseScheduleList;
		}

		// GET: api/ProjectReleaseSchedules/5
		[ResponseType(typeof(ProjectReleaseSchedule))]
		public IHttpActionResult GetProjectReleaseSchedule(int id)
		{
			ProjectReleaseSchedule projectReleaseSchedule = db.ProjectReleaseSchedules.Find(id);
			projectReleaseSchedule.ReleaseDate = projectReleaseSchedule.ReleaseDate.Value.ToUniversalTime();
			if (projectReleaseSchedule == null)
			{
				return NotFound();
			}

			return Ok(projectReleaseSchedule);
		}

		// PUT: api/ProjectReleaseSchedules/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutProjectReleaseSchedule(int id, ProjectReleaseSchedule projectReleaseSchedule)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != projectReleaseSchedule.ReleaseId)
			{
				return BadRequest();
			}

			db.Entry(projectReleaseSchedule).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProjectReleaseScheduleExists(id))
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

		// POST: api/ProjectReleaseSchedules
		[ResponseType(typeof(ProjectReleaseSchedule))]
		public IHttpActionResult PostProjectReleaseSchedule(ProjectReleaseSchedule projectReleaseSchedule)
		{
			try
			{


				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				else
				{
					projectReleaseSchedule.ModifiedOn = DateTime.Now;
				}

				db.ProjectReleaseSchedules.Add(projectReleaseSchedule);
				db.Entry(projectReleaseSchedule).State = EntityState.Added;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return CreatedAtRoute("DefaultApi", new { id = projectReleaseSchedule.ReleaseId }, projectReleaseSchedule);
		}

		// DELETE: api/ProjectReleaseSchedules/5
		[ResponseType(typeof(ProjectReleaseSchedule))]
		public IHttpActionResult DeleteProjectReleaseSchedule(int id)
		{
			ProjectReleaseSchedule projectReleaseSchedule = db.ProjectReleaseSchedules.Find(id);
			if (projectReleaseSchedule == null)
			{
				return NotFound();
			}

			db.ProjectReleaseSchedules.Remove(projectReleaseSchedule);
			db.SaveChanges();

			return Ok(projectReleaseSchedule);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool ProjectReleaseScheduleExists(int id)
		{
			return db.ProjectReleaseSchedules.Count(e => e.ReleaseId == id) > 0;
		}
	}
}