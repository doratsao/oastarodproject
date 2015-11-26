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
using OastarodProject.Models;

namespace OastarodProject.Controllers
{
    public class EnrolmentsController : ApiController
    {
        private OastarodProjectContext db = new OastarodProjectContext();

        // GET: api/Enrolments
        public IQueryable<Enrolment> GetEnrolments()
        {
            return db.Enrolments;
        }

        // GET: api/Enrolments/5
        [ResponseType(typeof(Enrolment))]
        public IHttpActionResult GetEnrolment(int id)
        {
            Enrolment enrolment = db.Enrolments.Find(id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return Ok(enrolment);
        }

        // PUT: api/Enrolments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnrolment(int id, Enrolment enrolment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrolment.EnrolmentID)
            {
                return BadRequest();
            }

            db.Entry(enrolment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrolmentExists(id))
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

        // POST: api/Enrolments
        [ResponseType(typeof(Enrolment))]
        public IHttpActionResult PostEnrolment(Enrolment enrolment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enrolments.Add(enrolment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enrolment.EnrolmentID }, enrolment);
        }

        // DELETE: api/Enrolments/5
        [ResponseType(typeof(Enrolment))]
        public IHttpActionResult DeleteEnrolment(int id)
        {
            Enrolment enrolment = db.Enrolments.Find(id);
            if (enrolment == null)
            {
                return NotFound();
            }

            db.Enrolments.Remove(enrolment);
            db.SaveChanges();

            return Ok(enrolment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrolmentExists(int id)
        {
            return db.Enrolments.Count(e => e.EnrolmentID == id) > 0;
        }
    }
}