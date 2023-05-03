using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetCadidateScore : IUsecase<Score>
{
    private readonly IScoreRepo _scoreRepo;
    private readonly string _studentId;

    public GetCadidateScore(IScoreRepo scoreRepo, string studentId)
    {
        _scoreRepo = scoreRepo;
        _studentId = studentId;
    }
    
    public Task<Score> ExecuteUsecase()
    {
        return _scoreRepo.GetMark(_studentId);
    }
}