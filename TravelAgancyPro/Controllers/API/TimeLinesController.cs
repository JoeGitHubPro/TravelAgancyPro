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
using TravelAgancyPro.Classes;

namespace TravelAgancyPro.Controllers.API
{
    public class TimeLinesController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/TimeLines
        public IHttpActionResult GetTimeLines()
        {
            return Ok(db.TimeLines.ToList().Select(a => new {a.ID , a.UserID, a.AspNetUser.UserName,Time = DateOperations.DateMethod( a.PostTime.Value), a.Header, a.Text }).Reverse());
        }
     
        // GET: api/TimeLines/5
        [ResponseType(typeof(TimeLine))]
        public IHttpActionResult GetTimeLine(int id)
        {
            var timeLine = db.TimeLines.ToList().Where(q=>q.ID == id).Select(a => new { a.UserID, a.AspNetUser.UserName, Time = DateOperations.DateMethod(a.PostTime.Value), a.Header, a.Text }).SingleOrDefault();
            if (timeLine == null)
            {
                return NotFound();
            }

            return Ok(timeLine);
        }

        // PUT: api/TimeLines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeLine(int id,string UserID, string Header ,string Text)
        {
            TimeLine timeLine = db.TimeLines.Find(id);
        
            if (id != timeLine.ID)
            {
                return BadRequest();
            }

            timeLine.UserID = UserID;   
            timeLine.Header = Header;   
            timeLine.Text = Text;
            timeLine.PostTime = DateOperations.CairoTimeZone;




            db.Entry(timeLine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeLineExists(id))
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

        // POST: api/TimeLines
        [ResponseType(typeof(TimeLine))]
        public IHttpActionResult PostTimeLine(string UserID, string Header, string Text)
        {

            TimeLine timeLine = new TimeLine();
            timeLine.UserID = UserID;
            timeLine.Header = Header;
            timeLine.Text = Text;
            timeLine.PostTime = DateOperations.CairoTimeZone;
           


            db.TimeLines.Add(timeLine);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TimeLineExists(timeLine.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = timeLine.ID }, timeLine);
        }

        // DELETE: api/TimeLines/5
        [ResponseType(typeof(TimeLine))]
        public IHttpActionResult DeleteTimeLine(int id)
        {
            TimeLine timeLine = db.TimeLines.Find(id);
            if (timeLine == null)
            {
                return NotFound();
            }

            db.TimeLines.Remove(timeLine);
            db.SaveChanges();

            return Ok(timeLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeLineExists(int id)
        {
            return db.TimeLines.Count(e => e.ID == id) > 0;
        }
    }
}