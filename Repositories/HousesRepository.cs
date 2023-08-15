

namespace gregslist_csharp.Repositories
{
  public class HousesRepository
  {

    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    // GET HOUSES
    internal List<House> GetHouses()
    {
      string sql = "SELECT * FROM houses;";
      List<House> houses = _db.Query<House>(sql).ToList();
      return houses;
    }




    // GET HOUSES BY ID
    internal House GetHouseById(int houseId)
    {
      string sql = "SELECT * FROM houses WHERE id = @houseId;";
      House house = _db.QueryFirstOrDefault<House>(sql, new { houseId }); return house;
    }



    // CREATE HOUSE
    internal int CreateHouse(House houseData)
    {
      string sql = @"
    INSERT INTO houses (sqft, bedrooms, bathrooms, imgUrl, description, price)
    VALUES (@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price);
    SELECT LAST_INSERT_ID()
    ;";
      int houseId = _db.ExecuteScalar<int>(sql, houseData);
      return houseId;
    }





    // REMOVE HOUSE
    internal void RemoveHouse(int houseId)
    {
      string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1;";
      _db.Execute(sql, new { houseId });
    }





    // UPDATE HOUSE
    internal House UpdateHouse(House originalHouse)
    {
      string sql = @"
    UPDATE houses 
    SET
    sqft = @Sqft,
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    imgUrl = @ImgUrl,
    description = @Description,
    price = @Price
    WHERE id = @Id
    LIMIT 1;
    SELECT * FROM houses WHERE id = @Id
    ;";

      House updatedHouse = _db.QueryFirstOrDefault<House>(sql, originalHouse);

      return updatedHouse;
    }
  }
}