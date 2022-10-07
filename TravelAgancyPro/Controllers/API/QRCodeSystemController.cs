using System.Linq;
using System.Web.Http;

namespace TravelAgancyPro.Controllers.API
{
    public class QRCodeSystemController : ApiController
    {
        private TravelAgancyEntities db = new TravelAgancyEntities();

        [HttpGet]
        [Route("api/QRCodeSystem/UserSubscription")]
        public bool UserSubscription(string UserID)
        {
            return db.AspNetUsers.Where(a => a.Id == UserID).Select(b => b.Subscription).SingleOrDefault();
        }

        [HttpGet]
        [Route("api/QRCodeSystem/ExisitUserTravel")]
        public bool ExisitUserTravel(string UserID, int TravelID, bool Go)
        {

            if (Go)
            {
                return db.Travelers.Where(a => a.UserID == UserID && a.TravelID == TravelID).Any(b => b.DestinationGoID.HasValue);
               
            }
            else
            {
                return db.Travelers.Where(a => a.UserID == UserID && a.TravelID == TravelID).Any(b => b.DestinationBackID.HasValue);
             

            }
        }


    }
}
