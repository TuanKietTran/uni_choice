using server.Domain;

namespace server.Usecase.Repo;

public interface IUniversityRepo
{
    Task<University> GetUniversityByCode(string code);
    
    Task<List<University>> GetAllUniversity();
}

public class UniNotFound : Exception
{
    private string _message;

    public UniNotFound(string code)
    {
        _message = $"University {code} Not Found";
    }
}