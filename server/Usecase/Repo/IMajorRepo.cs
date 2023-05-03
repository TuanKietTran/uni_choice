using server.Domain;

namespace server.Usecase.Repo;

public interface IMajorRepo
{
    Task<Major> GetMajorByCode(string code);
    
    Task<List<Major>> GetMajorsOfUni(string uniCode);
    
    Task<List<Major>> GetTopMajorsByMark(int threshold = 20);

    Task<List<string>> GetGroupSubject(string major);
}

public class MajorNotFound : Exception
{
    private string _message;

    public MajorNotFound(string code)
    {
        _message = $"Major {code} Not Found";
    }
}
