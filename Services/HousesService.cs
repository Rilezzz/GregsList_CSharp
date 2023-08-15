

namespace gregslist_csharp.Services
{
  public class HousesService
  {
    private readonly HousesRepository _housesRepository;

    public HousesService(HousesRepository housesRepository)
    {
      _housesRepository = housesRepository;
    }


    // GET HOUSES
    internal List<House> GetHouses()
    {
      List<House> houses = _housesRepository.GetHouses();
      return houses;

    }



    // GET HOUSES BY ID
    internal House GetHouseById(int houseId)
    {
      House house = _housesRepository.GetHouseById(houseId);

      if (house == null)
      {
        throw new Exception($"{houseId} is not a valid ID");
      }
      return house;

    }




    // CREATE HOUSE
    internal House CreateHouse(House houseData)
    {
      int houseId = _housesRepository.CreateHouse(houseData);
      House house = GetHouseById(houseId);
      return house;
    }




    // REMOVE HOUSE
    internal House RemoveHouse(int houseId)
    {
      House house = GetHouseById(houseId);
      _housesRepository.RemoveHouse(houseId);
      return house;
    }





    // UPDATE HOUSE
    internal House UpdateHouse(int houseId, House houseData)
    {
      House originalHouse = GetHouseById(houseId);

      originalHouse.Sqft = houseData.Sqft;
      originalHouse.Bedrooms = houseData.Bedrooms;
      originalHouse.Bathrooms = houseData.Bathrooms;
      originalHouse.ImgUrl = houseData.ImgUrl;
      originalHouse.Price = houseData.Price;
      originalHouse.Description = houseData.Description;

      House house = _housesRepository.UpdateHouse(originalHouse);

      return house;
    }
  }
}