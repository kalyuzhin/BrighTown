using Backend.Migrations;
using Microsoft.Data.Sqlite;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly DataContext _dbContext;
        private readonly SqliteConnection _connection;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public UsersController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UsersController()
        {
            // Инициализация подключения к базе данных SQLite
            _connection = new SqliteConnection("Data Source=database.db");
            _connection.Open();
        }

        [HttpPost("Register")]
        public IActionResult Register(AddUserDto user)
        {
            try
            {
                // Сохранение данных пользователя в базе данных
                _usersService.Register(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        //    [HttpPost]
        // async Task<IActionResult> RegisterUser(User user)
        //{
        //    // Валидация полей пользователя
        //    if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.SecondName))
        //    {
        //        return BadRequest("Все поля должны быть заполнены");
        //    }

        //    using (var connection = new SqliteConnection("Data Source=database.db"))
        //    {
        //        connection.Open();
        //        // Добавление пользователя в базу данных
        //        using (var command = new SqliteCommand("INSERT INTO Users (Username, FirstName, SecondName, Password, Email) VALUES (@Username, @FirstName, @SecondName, @Password, @Email)", connection))
        //        {
        //            command.Parameters.AddWithValue("@Username", user.Username);
        //            command.Parameters.AddWithValue("@FirstName", user.FirstName);
        //            command.Parameters.AddWithValue("@SecondName", user.SecondName);
        //            command.Parameters.AddWithValue("@Password", user.Password);
        //            command.Parameters.AddWithValue("@Email", user.Email);

        //            command.ExecuteNonQuery();
        //        }
        //        return Ok("Пользователь успешно зарегистрирован");
        //    }
        }
        }

        //[HttpPost("register-user")]
        //public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(AddUserDto newUser)
        //{
        //    return Ok(await _usersService.Register(newUser));
        //}
    }