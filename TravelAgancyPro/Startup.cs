using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using TravelAgancyPro.Classes.Startup;

[assembly: OwinStartup(typeof(TravelAgancyPro.Startup))]

namespace TravelAgancyPro
{
    public partial class Startup
    {
       // private Schedule schedule = new Schedule();

        public void Configuration(IAppBuilder app)
        {
            //My startup confg
           // Task.Factory.StartNew(() => schedule.Run(), TaskCreationOptions.LongRunning);

            ConfigureAuth(app);

           
        }
    }
}
