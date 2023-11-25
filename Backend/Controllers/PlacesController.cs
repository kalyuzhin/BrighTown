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
    }
}