using server.Domain;

namespace server.Usecase.Repo;

public interface IScoreRepo
{
    Task<CandidateScore> GetMark(string studentId, int year);
}

public class IdNotFound : Exception
{
    private string _message;

    public IdNotFound(string studentId)
    {
        _message = $"Major {studentId} Not Found";
    }
}