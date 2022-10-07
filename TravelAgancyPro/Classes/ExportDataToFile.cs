using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GemBox.Spreadsheet;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace TravelAgancyPro.Classes
{
    public static class ExportDataToFile
    {
     
        public static void ExportToExcel()
        {
            TravelAgancyEntities db = new TravelAgancyEntities();
            // If you are using the Professional version, enter your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");


            // Create test DataSet with five DataTables
            DataSet dataSet = new DataSet();


            //Create new WorkSheet
            DataTable dataTable = new DataTable("Users");

            dataTable.Columns.Add("UserName");
            dataTable.Columns.Add("ID");


            foreach (AspNetUser item in db.AspNetUsers)
            {
     
               dataTable.Rows.Add(new object[] { item.UserName, item.Id  }); 
               
            }

            // Create and fill a sheet for every DataTable in a DataSet
            ExcelFile workbook = new ExcelFile();

            GemBox.Spreadsheet.ExcelWorksheet worksheet = workbook.Worksheets.Add(dataTable.TableName);


            worksheet.Cells[0,0].Style.FillPattern.SetSolid(SpreadsheetColor.FromArgb(100, 105, 122));
            worksheet.Cells[0, 1].Style.FillPattern.SetSolid(SpreadsheetColor.FromArgb(100, 105, 122));
            worksheet.Columns[1].Width = 10000;
            worksheet.Columns[0].Width = 5000;
       
            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dataTable, new InsertDataTableOptions() { ColumnHeaders = true });


            string Root = Paths.ExcelFilePath;
            workbook.Save(Root);



        }



    }
}