using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TravelAgancyPro;
using TravelAgancyPro.Classes;
using TravelAgancyPro.Classes.TracingArea;
using TravelAgancyPro.Classes.TravelOperations;

namespace TravelAgancyPro.Controllers.API
{
    public class TravelsController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        // GET: api/Travels
        public IHttpActionResult GetTravels()
        {
            using (TravelAgancyEntities DB = new TravelAgancyEntities())
            {
                Expired.ExpiredTravel(DB);
            }

            var Result = db.Travels.ToList().Select(e => new
            {
                e.TravelID,
                e.TravelName,
                e.UserCreatorID,
                e.NoOfSites,
                e.TravelDescription,
                e.TravelAppointment,
                e.ImagePath,
                TravelDate = TravelInformation.TravelDate(e.TravelID)

            }).Reverse();

            // var Result = db.Travels.ToList().Select(e => new { e.TravelID, e.TravelName, e.UserCreatorID, e.NoOfSites, e.TravelDescription, e.TravelAppointment, e.ImagePath }).Reverse();
            return Ok(Result);
        }

        [Route("api/Travels/GetTravelsDate")]
        public IHttpActionResult GetTravelsDate(int TravelID)
        {
            string Result;
            try
            {
                Result = TravelInformation.TravelDate(TravelID);
            }
            catch (Exception e)
            {
                throw e;
            }



            return Ok(Result);
        }

        // GET: api/Travels/5
        [ResponseType(typeof(Travel))]
        public IHttpActionResult GetTravel(string id)
        {
            var travel = db.Travels.Where(x => x.UserCreatorID == id).Select(e => new { e.TravelID, e.TravelName, e.AspNetUser.UserName, e.NoOfSites, e.TravelDescription, e.TravelAppointment, e.ImagePath }).FirstOrDefault();

            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        [Route("api/Travels/GetTravelByid")]
        [ResponseType(typeof(Travel))]
        public IHttpActionResult GetTravelByid(int id)
        {
            var travel = db.Travels.Where(x => x.TravelID == id).Select(e => new { e.TravelID, e.TravelName, e.AspNetUser.UserName, e.NoOfSites, e.TravelDescription, e.TravelAppointment, e.ImagePath }).FirstOrDefault();

            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        // PUT: api/Travels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTravel(int id, string TravelName, string UserCreatorID, int NoOfSites, string TravelDescription, string TravelAppointment, bool EditPhoto)
        {
            Travel travel = db.Travels.Find(id);

            travel.TravelName = TravelName;
            travel.UserCreatorID = UserCreatorID;
            travel.NoOfSites = NoOfSites;
            travel.TravelDescription = TravelDescription;
            travel.TravelAppointment = TravelAppointment;

            if (EditPhoto)
            {
                string tempImagePath = travel.ImagePath;

                try
                {
                    travel.ImagePath = await Files.CreateFile(Request);

                    Files.DeleteFile(tempImagePath);

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }



            }




            db.Entry(travel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Travels
        [ResponseType(typeof(Travel))]
        public async Task<IHttpActionResult> PostTravel(string TravelName, string UserCreatorID, int NoOfSites, string TravelDescription, string TravelAppointment)
        {
            Travel travel = new Travel();
            try
            {

                travel.TravelName = TravelName;
                travel.UserCreatorID = UserCreatorID;
                travel.NoOfSites = NoOfSites;
                travel.TravelDescription = TravelDescription;
                travel.TravelAppointment = TravelAppointment;

                try
                {
                    travel.ImagePath = await Files.CreateFile(Request);
                }
                catch (Exception)
                {

                    return BadRequest("Image Error");
                }




                try
                {
                    db.Travels.Add(travel);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }



            }
            catch (Exception)
            {

                return BadRequest("Create Error");
            }



            return CreatedAtRoute("DefaultApi", new { id = travel.TravelID }, travel);
        }

        // DELETE: api/Travels/5
        [ResponseType(typeof(Travel))]
        public IHttpActionResult DeleteTravel(int id)
        {
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return NotFound();
            }
            Files.DeleteFile(travel.ImagePath);

            db.Travels.Remove(travel);
            db.SaveChanges();

            return Ok(travel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();

            }
            base.Dispose(disposing);
        }

        private bool TravelExists(int id)
        {
            return db.Travels.Count(e => e.TravelID == id) > 0;
        }
    }
}