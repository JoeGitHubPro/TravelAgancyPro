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
    public class TravelersController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        [Route("api/Travelers/GetTravelersByDestination")]
        public IHttpActionResult GetTravelersByDestination(int TravelID)
        {
            #region GetTravelersGroupedByDestination
            //var travel = from T in db.Travelers
            //             where T.TravelID == TravelID
            //             group T by T.DestinationBack.DestinationNameB into s
            //             // orderby T.DestinationBack.DestinationNameB ascending
            //             select new
            //             {
            //                 k = s.Key,
            //                 h = s.Select(a => new { a.AspNetUser.UserName, a.AspNetUser.PhoneNumber ,a.ReferenceNo })
            //                 // l = s.OrderBy(x=>x.DestinationBack.DestinationNameB)
            //             };
            #endregion

            var travel = db.Travelers.Where(x => x.TravelID == TravelID).Select(a => new {a.id, a.AspNetUser.UserName,a.DestinationGo.DestinationName,a.DestinationBack.DestinationNameB, a.AspNetUser.PhoneNumber, a.ReferenceNo });  
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }


        [Route("api/Travelers/GetTravelersTarvel")]
        public IHttpActionResult GetTravelersTarvel(string UserId )
        {
           
            var travel = db.Travelers.Where(x => x.UserID == UserId).Select(e => new {e.id, e.TravelID, e.Travel.TravelName, e.Travel.UserCreatorID, e.Travel.TravelDescription, e.Travel.TravelAppointment });
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        [Route("api/Travelers/GetTraveler")]
        public IHttpActionResult GetTraveler(int id)
        {

            var travel = db.Travelers.Where(x => x.id == id).Select(e => new { e.AspNetUser.UserName, e.Travel.TravelName, e.DestinationGo.DestinationName, e.TimeGo.Time, e.DestinationBack.DestinationNameB, e.TimeBack.TimeB, e.ReferenceNo }).FirstOrDefault();
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }


        // GET: api/Travelers/5
        [ResponseType(typeof(Traveler))]
        public IHttpActionResult GetTraveler(string id)
        {

            var traveler = db.Travelers.Where(x => x.Travel.UserCreatorID == id).Select(e => new { e.AspNetUser.UserName, e.Travel.TravelName, e.DestinationGo.DestinationName, e.TimeGo.Time, e.DestinationBack.DestinationNameB, e.TimeBack.TimeB ,e.ReferenceNo}).FirstOrDefault();
            if (traveler == null)
            {
                return NotFound();
            }

            return Ok(traveler);
        }

        // PUT: api/Travelers/5
        public IHttpActionResult PutTraveler(int id, int DestinationGoID, int DestinationBackID, int TimeGoID, int TimeBackID ,string ReferenceNo)
        {
            Traveler traveler = db.Travelers.Find(id);


            if (DestinationGoID != 0)
            {
                if (Travelcapacity.IsFullGo(traveler.Travel.TravelID))
                {
                    return BadRequest("FullGo Capacity");
                }
                traveler.DestinationGoID = DestinationGoID;
                traveler.TimeGoID = TimeGoID;
            }
            else
            {
                traveler.DestinationGoID = null;
                traveler.TimeGoID = null;
            }

            if (DestinationBackID != 0)
            {
                if (Travelcapacity.IsFullBack(traveler.Travel.TravelID))
                {
                    return BadRequest("FullBack Capacity");
                }
                traveler.DestinationBackID = DestinationBackID;
                traveler.TimeBackID = TimeBackID;
            }
            else
            {
                traveler.DestinationBackID = null;
                traveler.TimeBackID = null;
            }
                traveler.ReferenceNo = ReferenceNo;
          

            if (id != traveler.id)
            {
                return BadRequest();
            }

            db.Entry(traveler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
              
                    throw;
                
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Travelers
        [ResponseType(typeof(Traveler))]
        public IHttpActionResult PostTraveler(string id, int TravelID, int DestinationGoID, int DestinationBackID, int TimeGoID, int TimeBackID, string ReferenceNo)
        {
            Traveler traveler = new Traveler();

            bool isExisit =db.Travelers.Where(a=>a.UserID==id && a.TravelID == TravelID).Any();
            if (isExisit) 
                return BadRequest("Traveler Already Exisit On This Travel");

            traveler.UserID = id;   
            traveler.TravelID = TravelID;
            if (DestinationGoID != 0)
            {
                if (Travelcapacity.IsFullGo(TravelID))
                {
                    return BadRequest("FullGo Capacity");
                }
                    traveler.DestinationGoID = DestinationGoID;
                   traveler.TimeGoID = TimeGoID;
            }
            
            if (DestinationBackID != 0 )
            {
                if (Travelcapacity.IsFullBack(TravelID))
                {
                    return BadRequest("FullBack Capacity");
                }
                    traveler.DestinationBackID= DestinationBackID;
                    traveler.TimeBackID = TimeBackID;
            }
            traveler.ReferenceNo = ReferenceNo;
           

            db.Travelers.Add(traveler);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e )
            {
                
                return BadRequest($"Can Not Post Traveler! Please refer to Exception... {e.Message}");
            }

            return CreatedAtRoute("DefaultApi", new { id = traveler.UserID }, traveler);
        }

        // DELETE: api/Travelers/5
        [ResponseType(typeof(Traveler))]
        public IHttpActionResult DeleteTraveler(int id)
        {

            Traveler traveler = db.Travelers.Where(a => a.id == id).FirstOrDefault();
            if (traveler == null)
            {
                return NotFound();
            }
            try
            {
                db.Travelers.Remove(traveler);
                db.SaveChanges();
            }
            catch (Exception e )
            {

                throw e;
            }

            return Ok(traveler);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelerExists(string id)
        {
            return db.Travelers.Count(e => e.UserID == id) > 0;
        }
    }
}