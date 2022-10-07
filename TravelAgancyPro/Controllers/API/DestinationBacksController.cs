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
using TravelAgancyPro.Classes.TravelOperations;

namespace TravelAgancyPro.Controllers.API
{
    public class DestinationBacksController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/DestinationBacks
        public IHttpActionResult GetDestinationBacks(int TravelID)
        {
            return Ok( db.DestinationBacks.Where(x=>x.TravelID == TravelID).ToList().Select(e=> new { e.DestinationBackID ,e.DestinationNameB, DestinationBackTime = Destination.DestinationBackTime(e.DestinationBackID) }));
        }

        // GET: api/DestinationBacks/5
        [ResponseType(typeof(DestinationBack))]
        public IHttpActionResult GetDestinationBack(int id)
        {
            var destinationBack = db.DestinationBacks.Where(x => x.DestinationBackID == id).Select(e => new { e.DestinationBackID, e.DestinationNameB, DestinationBackTime = Destination.DestinationBackTime(e.DestinationBackID) });
            if (destinationBack == null)
            {
                return NotFound();
            }

            return Ok(destinationBack);
        }

        // PUT: api/DestinationBacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestinationBack(int id,string DestinationName)
        {
            DestinationBack destinationBack = db.DestinationBacks.Find(id);

            destinationBack.DestinationNameB = DestinationName;
            
            if (id != destinationBack.DestinationBackID)
            {
                return BadRequest();
            }

            db.Entry(destinationBack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationBackExists(id))
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

        // POST: api/DestinationBacks
        [ResponseType(typeof(DestinationBack))]
        public IHttpActionResult PostDestinationBack(string DestinationName , int TravelID)
        {
            DestinationBack destinationBack = new DestinationBack();
            destinationBack.TravelID = TravelID;
            destinationBack.DestinationNameB = DestinationName;

      

            db.DestinationBacks.Add(destinationBack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destinationBack.DestinationBackID }, destinationBack);
        }

        // DELETE: api/DestinationBacks/5
        [ResponseType(typeof(DestinationBack))]
        public IHttpActionResult DeleteDestinationBack(int id)
        {
            DestinationBack destinationBack = db.DestinationBacks.Find(id);
            if (destinationBack == null)
            {
                return NotFound();
            }

            db.DestinationBacks.Remove(destinationBack);
            db.SaveChanges();

            return Ok(destinationBack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationBackExists(int id)
        {
            return db.DestinationBacks.Count(e => e.DestinationBackID == id) > 0;
        }
    }
}