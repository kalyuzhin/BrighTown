using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    [Route("api/[controller]")]
    [ApiController]

    public class SampleController : ControllerBase
    {
       private readonly User _contextUser;
       private readonly Place _contextPlace;
        public SampleController(User context) { _contextUser = context; }
        public SampleController(Place context) { _contextPlace = context; }

        //[HttpGet]
        //public ActionResult<string> Get()
        //{
        //    return "Hello from backend!";
        //}

        //[HttpPost]
        //public ActionResult<string> Post([FromBody] string data)
        //{
        //    // Обработка полученных данных и возврат результата
        //    return Ok($"Received data: {data}");
        //}

        // Получение информации о пользователе
        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
            if (_contextUser == null)
            {
                return NotFound();
            }
            return _contextUser;
        }

        // Получение информации о месте
        [HttpGet]
        public async Task<ActionResult<Place>> GetPlace()
        {
            if (_contextPlace == null)
            {
                return NotFound();
            }
            return _contextPlace;
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserId(int id)
        //{
        //    if (_contextUser == null)
        //    {
        //        return NotFound();
        //    }
        //    var user = _contextUser;

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}
    }
}
