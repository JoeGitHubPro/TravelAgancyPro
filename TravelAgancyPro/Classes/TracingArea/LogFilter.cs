using TravelAgancyPro.Controllers.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;
using System.Web.Http.ExceptionHandling;

namespace TravelAgancyPro.Classes.TracingArea
{
    public static class global
    {

        private static string _temp;
        public static string temp
        {
            get
            {
                return _temp;
            }

            set { _temp = value; }

        }
    }
    public class LogFilter : DelegatingHandler
    {


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var responsePath = request.RequestUri.LocalPath;
                //var token = request.Headers.Authorization != null ? request.Headers.Authorization.Parameter : null;

                dynamic responseodyHeaders;

                if (task.Result.Content != null)
                {
                    responseodyHeaders = task.Result.Content.Headers;
                }
                else
                {
                    responseodyHeaders = "No Headers Available";
                }

                dynamic TaskException;

                if (task.Exception != null)
                {
                    TaskException = task.Exception;
                }
                else
                {
                    TaskException = "No Task Exception Found";
                }


                var Id = task.Id;
                var Result = task.Result;
                var Status = task.Status;
                var requestMethod = request.Method;
                var requestHeaders = request.Headers;
                var requestRequestUri = request.RequestUri;
                var StatusCode = Convert.ToInt32(Result.StatusCode);
                string Exception = global.temp != null ? global.temp : "No Exception";
                global.temp = null;

                var Break = "----------------------------------------------------------------------------------------------------------------------------------------------";

                string text = $"Id = {Id}\n...\nTime = {DateOperations.CairoTimeZone}\n...\nresponsePath = {responsePath}\n...\nrequestRequestUri = {requestRequestUri}\n...\nrequestMethod = {requestMethod}\n...\nStatusCode = {StatusCode}\n...\nException = {Exception}\n...\nTask Exception = {TaskException}\n...\nIsSuccessStatusCode = {Result.IsSuccessStatusCode}\n...\nStatus = {Status}\n...\nReasonPhrase = {Result.ReasonPhrase}\n...\nrequestHeaders = {requestHeaders}\n...\nresponseodyHeaders = {responseodyHeaders}\n{Break}";

                LogToFile(text);

                return task.Result;



            });
            return response;
        }

        private void LogToFile(string text)
        {
            File.AppendAllText(Paths.logFilePath, $"{text}{Environment.NewLine}");
        }
    }
    public class UnhandledExceptionLogger : ExceptionLogger
    {


        public override void Log(ExceptionLoggerContext context)
        {

            string log = context.Exception.Message;
            LogFilter logFilter = new LogFilter();
            global.temp = log;

        }
    }
}