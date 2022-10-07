using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data;
using System.Web;
using System.IO;
using System.Web.Http;
using System.Diagnostics;

namespace TravelAgancyPro.Classes
{
    public static class Files
    {
       
        public static async Task<string> CreateFile(HttpRequestMessage Request)
        {
            string FileLocationPath = string.Empty;

            string Root = Paths.ImageFilePath;

            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(Root);

            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (MultipartFileData file in provider.FileData)
            {

                string FileName = file.Headers.ContentDisposition.FileName.Trim('"');

                string LocalFileName = file.LocalFileName;

                string filePath = Path.Combine(Root, FileName);

                try
                {
                    File.Move(LocalFileName, filePath);
                }
                catch (Exception e)
                {

                    return e.Message;
                }

                FileLocationPath = FileName;
            }

            return FileLocationPath;

        }

       
        public static void DeleteFile( string FileName)
        {
            if(FileName != null)
            {
                try
                {
                string preroot = Paths.ImageFilePath;
                string root = preroot + "/" + FileName;
                File.Delete(root);
                }
                catch (Exception e )
                {

                    throw e;
                }

            
            }
        }


     



    }
}
