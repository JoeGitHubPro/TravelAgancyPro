using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgancyPro.Classes
{
    public static class Paths
    {
        static Paths()
        {
            logFilePath = "Content/Logging/Log.txt";
            ImageFilePath = "Content/IMG";
            ExcelFilePath = "Content/Excel/Users.xlsx";
            DatabaseBackupFilePath = "Content/DatabaseBackup/TravelAgencyDB.bak";
        }


        private static string _fullLogFilePath;
        public static string logFilePath
        {
            get { return _fullLogFilePath; }
            set { _fullLogFilePath = CurrentFullPath(value); }
        }


        private static string _imageFilePath;
        public static string ImageFilePath
        {
            get { return _imageFilePath; }
            set { _imageFilePath = CurrentFullPath(value); }
        }

  
        private static string _excelFilePath ;
        public static string ExcelFilePath
        {
            get { return _excelFilePath; }
            set { _excelFilePath = CurrentFullPath(value); } 
        }


        private static string _databaseBackupFilePath;
        public static string DatabaseBackupFilePath 
        {
            get { return _databaseBackupFilePath; }
            set { _databaseBackupFilePath = CurrentFullPath(value); }
        }



        public static string CurrentFullPath(string FilePath) 
        {

            // string CurrentServerPath = HttpContext.Current.Server.MapPath(FilePath);
            string CurrentServerPath =$"{HttpRuntime.AppDomainAppPath}{FilePath}";

            return CurrentServerPath;

        }
        
    }
}
