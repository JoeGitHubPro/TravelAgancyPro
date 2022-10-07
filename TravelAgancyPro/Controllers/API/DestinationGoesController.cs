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
    public class DestinationGoesController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/DestinationGoes
        public  IHttpActionResult GetDestinationGoes(int TravelID)
        {
            return Ok( db.DestinationGoes.Where(x=>x.TravelID == TravelID).ToList().Select(e=> new {e.DestinationGoID , e.DestinationName , DestinationGoTime = Destination.DestinationGoTime(e.DestinationGoID) }) );
        }

        // GET: api/DestinationGoes/5
        [ResponseType(typeof(DestinationGo))]
        public IHttpActionResult GetDestinationGo(int id)
        {
            
            var destinationGo = db.DestinationGoes.Where(x=>x.DestinationGoID == id).Select(e=> new {e.TravelID , e.DestinationName, DestinationGoTime = Destination.DestinationGoTime(e.DestinationGoID) }).FirstOrDefault();    
            if (destinationGo == null)
            {
                return NotFound();
            }

            return Ok(destinationGo);
        }

        // PUT: api/DestinationGoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestinationGo(int id, string DestinationName)
        {

            DestinationGo destinationGo = db.DestinationGoes.Find(id);
            destinationGo.DestinationName = DestinationName;    
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destinationGo.DestinationGoID)
            {
                return BadRequest();
            }

            db.Entry(destinationGo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationGoExists(id))
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

        // POST: api/DestinationGoes
        [ResponseType(typeof(DestinationGo))]
        public IHttpActionResult PostDestinationGo(int TravelID, string DestinationName)
        {
            DestinationGo destinationGo = new DestinationGo();
            destinationGo.TravelID = TravelID;
            destinationGo.DestinationName = DestinationName;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DestinationGoes.Add(destinationGo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destinationGo.DestinationGoID }, destinationGo);
        }

        // DELETE: api/DestinationGoes/5
        [ResponseType(typeof(DestinationGo))]
        public IHttpActionResult DeleteDestinationGo(int id)
        {
            DestinationGo destinationGo = db.DestinationGoes.Find(id);
            if (destinationGo == null)
            {
                return NotFound();
            }

            db.DestinationGoes.Remove(destinationGo);
            db.SaveChanges();

            return Ok(destinationGo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationGoExists(int id)
        {
            return db.DestinationGoes.Count(e => e.DestinationGoID == id) > 0;
        }
    }
}