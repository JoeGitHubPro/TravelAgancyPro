using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgancyPro.Classes.TravelOperations
{
    public static class Travelcapacity
    {
        private static TravelAgancyEntities db = new TravelAgancyEntities();

        public static bool IsFullGo(int TravelID)
        {
           

            int NoOfSites = (int)db.Travels.Where(a => a.TravelID == TravelID).Select(b => b.NoOfSites).FirstOrDefault();
            int NoOfTravelers = db.Travelers.Where(b => b.TravelID == TravelID && b.DestinationGoID != null).Count();
            if (NoOfSites > NoOfTravelers)
            {
                return false;
            }


            return true;
        }

        public static bool IsFullBack(int TravelID)
        {
            

            int NoOfSites = (int)db.Travels.Where(a => a.TravelID == TravelID).Select(b => b.NoOfSites).FirstOrDefault();
            int NoOfTravelers = db.Travelers.Where(b => b.TravelID == TravelID && b.DestinationBackID != null).Count();
            if (NoOfSites > NoOfTravelers)
            {
                return false;
            }


            return true;
        }




    }
}