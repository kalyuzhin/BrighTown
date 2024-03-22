using Backend.Dtos.Pairs;
using System.IO;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _placesService;

        public PlacesController(IPlacesService placesService)
        {
            _placesService = placesService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPlaceRequestDto>>>> GetAllPlaces()
        {
            return Ok(await _placesService.GetAllPlaces());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPlaceRequestDto>>> GetPlace(int id)
        {
            return Ok(await _placesService.GetPlace(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<List<GetPlaceRequestDto>>>> AddPlace(AddPlaceResponseDto place)
        {
            return Ok(await _placesService.AddPlace(place));
        }

        [HttpPost("addtofavourites")]
        public async Task<ActionResult<ServiceResponse<GetPlaceRequestDto>>> AddPlaceToFavourites(
            AddFavouritePlaceDto pair)
        {
            return Ok(await _placesService.AddPlaceToFavourites(pair));
        }

        [HttpPost("getfavourites")]
        public async Task<ActionResult<ServiceResponse<List<GetPlaceRequestDto>>>> GetFavourites(int id)
        {
            return Ok(await _placesService.GetFavourites(id));
        }

        [HttpPut("/deletefavourites")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteFavourites(AddFavouritePlaceDto pair)
        {
            return Ok(await _placesService.DeleteFavourite(pair));
        }

        [HttpPost("/uploadimages")]
        public async Task<ActionResult<ServiceResponse<bool>>> UploadImages()
        {
            var files = HttpContext.Request.Form.Files;
            string Token;
            using (StreamReader sr = new StreamReader(System.IO.File.Open("config.txt", FileMode.Open)))
            {
                Token = await sr.ReadToEndAsync();
                Token.Trim();
            }

            using (var dbx = new DropboxClient(Token))
            {
                foreach (var file in files)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        await dbx.Files.UploadAsync("/Images", WriteMode.Overwrite.Instance,
                            body: memoryStream);
                        // System.IO.File.WriteAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Images"),
                        //     memoryStream.ToArray());
                    }
                }
            }

            return Ok();
        }
    }
}