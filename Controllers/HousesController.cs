


namespace gregslist_csharp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    private readonly HousesService _housesService;

    public HousesController(HousesService housesService)
    {
      _housesService = housesService;
    }

    // GET HOUSES
    [HttpGet]
    public ActionResult<List<House>> GetHouses()
    {
      try
      {
        List<House> houses = _housesService.GetHouses();
        return Ok(houses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET HOUSES BY ID
    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
      try
      {
        House house = _housesService.GetHouseById(houseId);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // CREATE HOUSES
    [HttpPost]
    public ActionResult<House> CreateHouse([FromBody] House houseData)
    {
      try
      {
        House house = _housesService.CreateHouse(houseData);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




    // REMOVE HOUSE
    [HttpDelete]
    public ActionResult<string> RemoveHouse(int houseId)
    {
      try
      {
        House house = _housesService.RemoveHouse(houseId);

        return Ok("This house was deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }






    // UPDATE HOUSE
    [HttpPut("{houseId}")]
    public ActionResult<House> UpdateHouse(int houseId, [FromBody] House houseData)
    {
      try
      {
        House house = _housesService.UpdateHouse(houseId, houseData);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}