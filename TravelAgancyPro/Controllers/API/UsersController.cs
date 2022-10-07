using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TravelAgancyPro;

namespace TravelAgancyPro.Controllers.API
{
    public class UsersController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        //My Func
        [HttpGet]
        [Route("api/Users/GetNoUsers")]
        public IHttpActionResult GetNoUsers()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
         
            List<AspNetUser> User = new List<AspNetUser>();    
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == "User")
                {
                    User.Add(item);
                }
            }
                int No = User.Count();
                User.Clear();

               return Ok(No);
        }

        [HttpGet]
        [Route("api/Users/GetNoManger")]
        public IHttpActionResult GetNoManger()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == "Manger")
                {
                    User.Add(item);
                }
            }
            int No = User.Count();
            User.Clear();

            return Ok(No);
        }


        [HttpGet]
        [Route("api/Users/GetNoAdmin")]
        public IHttpActionResult GetNoAdmin()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == "Admin")
                {
                    User.Add(item);
                }
            }
            int No = User.Count();
            User.Clear();

            return Ok(No);
        }

        #region Subscriper

        [HttpGet]
        [Route("api/Users/GetAllSubscriper")]
        public IHttpActionResult GetAllSubscriper()
        {
            return Ok(db.AspNetUsers.Where(a=>a.Subscription == true).Select(e => new { e.Id, e.UserName, e.Email, e.PhoneNumber }));

        }
       
        [HttpGet]
        [Route("api/Users/PutSubscriper")]
        public IHttpActionResult PutSubscriper(string id , bool Subscription) 
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            aspNetUser.Subscription = Subscription;
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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
       
        #endregion

        [HttpGet]
        [Route("api/Users/GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();               
                User.Add(item);
                
            }
            int No = User.Count();
            User.Clear();

            return Ok(No);
        }

        [HttpGet]
        [Route("api/Users/GetAccUsers")]
        public IHttpActionResult GetAccUsers(string RoleName)
        {
            // get the user manager from the owin context
            ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            List<AspNetUser> User = new List<AspNetUser>();
            foreach (var item in db.AspNetUsers)
            {
                string Role = userManager.GetRoles(item.Id).SingleOrDefault();
                if (Role == RoleName)
                {
                    User.Add(item);
                }
                

            }
          

            return Ok(User.Select(a => new { a.Id, a.UserName, a.Email, a.PhoneNumber }));
        }
        // GET: api/Users
        public IHttpActionResult GetAspNetUsers()
        {
            return Ok( db.AspNetUsers.Select(e=> new { e.Id, e.UserName , e.Email , e.PhoneNumber ,e.Subscription}));
        }

        // GET: api/Users/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult GetAspNetUser(string id)
        {
            
            var aspNetUser = db.AspNetUsers.Where(e => e.Id == id).Select(e => new { e.Id, e.UserName, e.Email, e.PhoneNumber ,e.Subscription }).FirstOrDefault();
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return Ok(aspNetUser);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAspNetUser(string id, string UserName , string Email , string PhoneNumber , bool Subscription = false)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);

            aspNetUser.UserName = UserName;
            aspNetUser.Email = Email;
            aspNetUser.PhoneNumber = PhoneNumber;
            aspNetUser.Subscription = Subscription;


           

            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        // DELETE: api/Users/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult DeleteAspNetUser(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspNetUser);
            db.SaveChanges();

            return Ok(aspNetUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUserExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}