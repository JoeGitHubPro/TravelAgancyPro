using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace TravelAgancyPro.Classes
{
    public static class DatabaseBackup
    {
        public static void GenerateBackup(string Server, string UserName, string Password, string DatabaseName)
        {

            string Root = Paths.DatabaseBackupFilePath;
            Server dbServer = new Server(new ServerConnection(Server, UserName, Password));
            Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = DatabaseName };
            dbBackup.Devices.AddDevice(Root, DeviceType.File);
            dbBackup.Initialize = true;
            dbBackup.SqlBackupAsync(dbServer);
           
        }
    }
}