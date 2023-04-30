using server.Domain;

namespace server.Usecase.Repo;

public interface IProvinceRepo
{

    Task<Province> GetProvinceByCode(int code);
    
    Task<List<Province>> GetAllProvince();
}

public class ProvinceNotFound : Exception
{
    private static string _name = "ProvinceNotFound";
    private string _message;

    public ProvinceNotFound(int code)
    {
        _message = "Province {code} Not Found";
    }
}