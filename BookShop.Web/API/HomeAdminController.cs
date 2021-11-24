using BookShop.Service;
using BookShop.Web.Infastucture.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]//h cái nào cũng cần  phải có xác thực
    public class HomeAdminController : ApiControllerBase
    {
        IErrorService _erorrService;
        public HomeAdminController(IErrorService errorSerive) : base(errorSerive)
        {
            this._erorrService = errorSerive;
        }
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello,Admin Memmber";
        }
    }
}
