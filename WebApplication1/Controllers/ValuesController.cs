using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Telegram.Bot.Types;
using WebApplication1.Services;
using WebApplication1.UserInterface;
using WebApplication1.UserInterface.Main;
using WebApplication1.UserInterface.salesman;

namespace WebApplication1.Controllers
{
    // [Authorize]
    public class ValuesController : ApiController
    {
        public ValuesController()
        {

        }

        // POST api/values
        public void Post([FromBody]Update result)
        {
            if (result.CallbackQuery == null)
            {
                NullCallback nullcallbackquery = new NullCallback();
                nullcallbackquery.Process(result);
            }

            else if (result.CallbackQuery != null)
            {
                ExistsCallback existcallbackquery = new ExistsCallback();
                existcallbackquery.Process(result);
            }
        }
        public IHttpActionResult Get()
        {
            try
            {
                var db = new ApplicationDbContext();
                return Ok(db.Cities.OrderBy(t => t.Name).Take(10));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
