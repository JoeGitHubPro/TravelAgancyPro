using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgancyPro.Classes.TravelOperations
{
    public static class Destination
    {
        public static string DestinationGoTime(int DestinationGoID)
        {
            DateTime? Date;
            using (TravelAgancyEntities db = new TravelAgancyEntities())
            {
                Date = db.TimeGoes.Where(x => x.DestinationGoID == DestinationGoID).Select(e => e.Time).SingleOrDefault();


                if (Date == DateTime.MinValue)
                    return "Travel Don't Have Any Appointment";

            }
            return Convert.ToDateTime(Date).ToLongTimeString();

        }
        public static string DestinationBackTime(int DestinationBackID)
        {
            DateTime? Date;
            using (TravelAgancyEntities db = new TravelAgancyEntities())
            {
                Date = db.TimeBacks.Where(x => x.DestinationBackID == DestinationBackID).Select(e => e.TimeB).SingleOrDefault();


                if (Date == DateTime.MinValue)
                    return "Travel Don't Have Any Appointment";

            }
            return Convert.ToDateTime(Date).ToLongTimeString();

        }
    }
}