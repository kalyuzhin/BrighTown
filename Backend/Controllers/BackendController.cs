using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackendController : ControllerBase
    {
        // [HttpPost]
        // public ActionResult RegisterUser()
        // {
        //     // if (BadRequest())
        //     // {
        //     //     return BadRequest("Error! Bad request!\n");
        //     // }
        // }
    }
}