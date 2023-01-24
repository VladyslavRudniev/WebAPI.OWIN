using System;
using System.Web.Http;

namespace WebAPI.OWIN.Controllers
{
    public class CurrentTimeController : ApiController
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }    
    }
}