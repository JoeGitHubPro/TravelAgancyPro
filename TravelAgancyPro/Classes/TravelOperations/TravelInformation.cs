using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgancyPro.Classes.TravelOperations
{
    public static class TravelInformation
    {
        public static string TravelDate(/*TravelAgancyEntities db,*/ int TravelID)
        {
            DateTime Date;
            using (TravelAgancyEntities db = new TravelAgancyEntities())
            {

                int DestinationGoID = db.DestinationGoes.Where(a => a.TravelID == TravelID).Select(b => b.DestinationGoID).FirstOrDefault();

                if (DestinationGoID == 0)
                    return "Travel Not Found";

                Date = db.TimeGoes.Where(a => a.DestinationGoID == DestinationGoID).Select(b => b.Time.Value).FirstOrDefault();

                if (Date == DateTime.MinValue)
                    return "Travel Don't Have Any Appointment";

            }
            return Date.ToLongDateString();

        }
    }
}