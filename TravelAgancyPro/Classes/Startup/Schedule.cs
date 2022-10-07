using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TravelAgancyPro.Classes.Startup
{
    public class Schedule
    {
        public async void Run()
        {
            int days = 1;
            int day = 24 * 60 * 60 * 1000;
            int Period = day * days;

            // Timer timer = new Timer(Mehtod, null, 0, /*Period*/muints);
            await Task.Run(() => new Timer(Mehtod, null, 0, Period));

        }

        private void Mehtod(object o)
        {
            SendMailViaProvider.SendViaGmail("gamasaporto@gmail.com", "youssefprogrammingservices@gmail.com", "qpklcmchtorbbqgh", $"{DateOperations.CairoTimeZone}\nThis is daily bakup :", /*Paths.DatabaseBackupFilePath*/null, "Database Backup File");
            // CheckMehtod(null);
        }
        private async void CheckMehtod(object o)
        {
            FileInfo file = new FileInfo(Paths.logFilePath);
            long fileSize = file.Length;
            if (fileSize > 100000000)
            {
                SendMailViaProvider.SendViaGmail("gamasaporto@gmail.com", "youssefprogrammingservices@gmail.com", "qpklcmchtorbbqgh", "This is Log File :", Paths.logFilePath, "Logging  File");
                File.Delete(Paths.logFilePath);
            }
        }
    }
}