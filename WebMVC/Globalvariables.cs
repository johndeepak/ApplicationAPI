using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebMVC
{
    public static class Globalvariables
    {
        public static HttpClient webapiclient = new HttpClient();

        static Globalvariables()
        {
            webapiclient.BaseAddress = new Uri("http://localhost:14470/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}