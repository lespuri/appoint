using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TableService
{
    public class HttpHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public string GetHttp(string prUrl, string prHeaderAuthorization = "")
        {
            string rt = "";
            try
            {
                WebRequest request = WebRequest.Create(prUrl);

                if (!string.IsNullOrEmpty(prHeaderAuthorization))
                    request.Headers["Authorization"] = prHeaderAuthorization;

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                //Console.WriteLine(rt);

                reader.Close();
                response.Close();

                Log.Debug("CHAMADA API GET: \n url:" + prUrl + "\n responseBody: " + rt + MethodBase.GetCurrentMethod());
            }

            catch (WebException ex)
            {
                WebResponse response = (HttpWebResponse)ex.Response;

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                //aCoContextExecution.aCoMessageList.Add(new CoMessage(ex.Message, CoMessage.KDType.kdError));
                Log.Error(string.Format("CHAMADA API GET Error: \n url:{0} \n responseBody: {1} \n codeStatus:{2} ", prUrl, rt, ((HttpWebResponse)ex.Response).StatusCode));

                //throw new System.Exception(ex.Message);
            }
            return rt;
        }


        public string Delete(string prUrl, string json, string prHeaderAuthorization = "")
        {
            var result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(prUrl);
            try
            {
                if (!string.IsNullOrEmpty(prHeaderAuthorization))
                    //httpWebRequest.Headers["Authorization"] = "Basic c3VwZXI6MTIzNA==";
                    httpWebRequest.Headers["Authorization"] = prHeaderAuthorization;

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Log.Debug(string.Format("CHAMADA API POST: \n url:{0} \n json: {1} \n responseBody: {2} ", prUrl, json, result));
            }
            catch (WebException ex)
            {
                var httpResponse = (HttpWebResponse)ex.Response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Log.Error(string.Format("CHAMADA API POST Error: \n url:{0} \n json: {1} \n responseBody: {2} \n codeStatus:{3}", prUrl, json, result, ((HttpWebResponse)ex.Response).StatusCode));

                //aCoContextExecution.CoLog(ex, MethodBase.GetCurrentMethod(), CoContextExecution.KDLogType.kdFatal);
                //throw new System.Exception(ex.Message);
            }

            return result;
        }


        public string Post(string prUrl, string json, string prHeaderAuthorization = "")
        {
            var result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(prUrl);
            try
            {
                if (!string.IsNullOrEmpty(prHeaderAuthorization))
                    //httpWebRequest.Headers["Authorization"] = "Basic c3VwZXI6MTIzNA==";
                    httpWebRequest.Headers["Authorization"] = prHeaderAuthorization;

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Log.Debug(string.Format("CHAMADA API POST: \n url:{0} \n json: {1} \n responseBody: {2} ", prUrl, json, result ));
            }
            catch (WebException ex)
            {
                var httpResponse = (HttpWebResponse)ex.Response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Log.Error(string.Format("CHAMADA API POST Error: \n url:{0} \n json: {1} \n responseBody: {2} \n codeStatus:{3}", prUrl, json, result, ((HttpWebResponse)ex.Response).StatusCode)  );
                
                //aCoContextExecution.CoLog(ex, MethodBase.GetCurrentMethod(), CoContextExecution.KDLogType.kdFatal);
                //throw new System.Exception(ex.Message);
            }

            return result;
        }




    }
}
