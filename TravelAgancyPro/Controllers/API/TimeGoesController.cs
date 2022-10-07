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
    public class TimeGoesController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/TimeGoes
        public IHttpActionResult GetTimeGoes(int DestinationGoID)
        {
            return Ok( db.TimeGoes.Where(x=>x.DestinationGoID == DestinationGoID).Select(e=> new {e.TimeGoID , e.Time}) );
        }

        // GET: api/TimeGoes/5
        [ResponseType(typeof(TimeGo))]
        public IHttpActionResult GetTimeGo(int id)
        {
            var timeGo = db.TimeGoes.Where(x => x.TimeGoID == id).Select(e => new { e.TimeGoID, e.Time }).FirstOrDefault();
            if (timeGo == null)
            {
                return NotFound();
            }

            return Ok(timeGo);
        }

        // PUT: api/TimeGoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeGo(int id ,DateTime Time )
        {
            TimeGo timeGo = db.TimeGoes.Where(a=>a.DestinationGoID == id).FirstOrDefault();
            timeGo.Time = Time;

            if (id != timeGo.TimeGoID)
            {
                return BadRequest();
            }

            db.Entry(timeGo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeGoExists(id))
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

        // POST: api/TimeGoes
        [ResponseType(typeof(TimeGo))]
        public IHttpActionResult PostTimeGo(int DestinationGoID, DateTime Time)
        {
            TimeGo timeGo = new TimeGo();
            timeGo.DestinationGoID = DestinationGoID;
            timeGo.Time = Time;

            

            db.TimeGoes.Add(timeGo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeGo.TimeGoID }, timeGo);
        }

        // DELETE: api/TimeGoes/5
        [ResponseType(typeof(TimeGo))]
        public IHttpActionResult DeleteTimeGo(int id)
        {
            TimeGo timeGo = db.TimeGoes.Find(id);
            if (timeGo == null)
            {
                return NotFound();
            }

            db.TimeGoes.Remove(timeGo);
            db.SaveChanges();

            return Ok(timeGo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeGoExists(int id)
        {
            return db.TimeGoes.Count(e => e.TimeGoID == id) > 0;
        }
    }
}