using AutoMapper;
using Balbet.BL.Interfaces;
using Balbet.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Balbet.WEB.Controllers
{
    public class UserPagingController : ApiController
    {
        readonly IBusinessService businessService;

        public UserPagingController(IBusinessService businessService)
        {
            this.businessService = businessService;
        }

        [Route("api/userpaging")]
        [HttpPost]
        public IHttpActionResult GetUsers([FromBody]PageQueryInputModel query)
        {
            var users = Mapper.Map<List<UserViewModel>>(this.businessService.PagingUsers(query.Skip, query.Take));
            return Ok(users);
        }



    }
}
