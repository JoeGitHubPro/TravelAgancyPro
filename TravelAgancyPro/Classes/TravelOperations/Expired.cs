using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TravelAgancyPro.Classes.TravelOperations
{
    public static class Expired
    {
        public static  void ExpiredTravel(TravelAgancyEntities DB)
        {

            using (TravelAgancyEntities db = new TravelAgancyEntities())
            {

           

                try
                {
                    List<DateTime> B = new List<DateTime>();


                    foreach (int item in db.Travels.Select(a => a.TravelID))
                    {

                        if (db.DestinationBacks.Where(x => x.TravelID == item).Any())
                        {

                            foreach (int Item in db.DestinationBacks.Where(q => q.TravelID == item).Select(e => e.DestinationBackID))
                            {
                                foreach (int ITem in db.TimeBacks.Where(s => s.DestinationBackID == Item).Select(d => d.TimeBackID))
                                {
                                    B.Add((DateTime)db.TimeBacks.Where(s => s.TimeBackID == ITem).Select(d => d.TimeB).FirstOrDefault());

                                }
                            }


                        }
                        else
                        {
                            foreach (int Item in db.DestinationGoes.Where(q => q.TravelID == item).Select(e => e.DestinationGoID))
                            {
                                foreach (int ITem in db.TimeGoes.Where(s => s.DestinationGoID == Item).Select(d => d.TimeGoID))
                                {
                                    B.Add((DateTime)db.TimeGoes.Where(s => s.TimeGoID == ITem).Select(d => d.Time).FirstOrDefault());

                                }
                            }
                        }
                  

                        if (B.Count != 0)
                        {
                            DateTime t = B.Max();

                            if (t < DateOperations.CairoTimeZone)
                            {

                                Travel travel = DB.Travels.Find(item);
                                if (travel == null)
                                {
                                    return;
                                }

                                 

                                bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

                                try
                                {
                                        DB.Configuration.ValidateOnSaveEnabled = false;

                                        DB.Travels.Remove(travel);

                                        DB.SaveChanges();
                                }
                                finally
                                {
                                        DB.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                                }




                            }
                        }

                        B.Clear();


                    }
                }
                catch (Exception)
                {

                    return ;
                }

            }


        }
    }
}