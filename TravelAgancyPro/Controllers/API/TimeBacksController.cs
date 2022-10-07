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
using TravelAgancyPro;

namespace TravelAgancyPro.Controllers.API
{
    public class TimeBacksController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/TimeBacks
        public IHttpActionResult GetTimeBacks(int DestinationBackID)
        {
            return Ok( db.TimeBacks.Where(x=>x.DestinationBackID == DestinationBackID).Select(e=> new {e.TimeBackID ,e.TimeB}));
        }

        // GET: api/TimeBacks/5
        [ResponseType(typeof(TimeBack))]
        public IHttpActionResult GetTimeBack(int id)
        {
            var timeBack = db.TimeBacks.Where(x => x.TimeBackID == id).Select(e => new { e.TimeBackID, e.TimeB }).FirstOrDefault();
            if (timeBack == null)
            {
                return NotFound();
            }

            return Ok(timeBack);
        }

        // PUT: api/TimeBacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeBack(int id, DateTime Time )
        {

            TimeBack timeBack = db.TimeBacks.Where(a=>a.DestinationBackID == id).FirstOrDefault();

            timeBack.TimeB = Time;

          

            if (id != timeBack.TimeBackID)
            {
                return BadRequest();
            }

            db.Entry(timeBack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeBackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/TimeBacks
        [ResponseType(typeof(TimeBack))]
        public IHttpActionResult PostTimeBack(int DestinationBackID , DateTime Time)
        {
            TimeBack timeBack = new TimeBack();

            timeBack.DestinationBackID = DestinationBackID;
            timeBack.TimeB = Time;

            db.TimeBacks.Add(timeBack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeBack.TimeBackID }, timeBack);
        }

        // DELETE: api/TimeBacks/5
        [ResponseType(typeof(TimeBack))]
        public IHttpActionResult DeleteTimeBack(int id)
        {
            TimeBack timeBack = db.TimeBacks.Find(id);
            if (timeBack == null)
            {
                return NotFound();
            }

            db.TimeBacks.Remove(timeBack);
            db.SaveChanges();

            return Ok(timeBack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeBackExists(int id)
        {
            return db.TimeBacks.Count(e => e.TimeBackID == id) > 0;
        }
    }
}