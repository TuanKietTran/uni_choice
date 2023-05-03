using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetCandidateScore : IUsecase<CandidateScore>
{
    private const int LowerBound = 2000;
    private const int UpperBound = 2050;
    private readonly ICandidateScoreRepo _candidateScoreRepo;
    private readonly string _studentId;
    private readonly int _year;

    public GetCandidateScore(ICandidateScoreRepo candidateScoreRepo, string studentId, int year)
    {
        _candidateScoreRepo = candidateScoreRepo;
        _studentId = studentId;
        if (year is < LowerBound or > UpperBound)
        {
            throw new ArgumentException();
        }

        _year = year;
    }
    
    public Task<CandidateScore> ExecuteUsecase()
    {
        return _candidateScoreRepo.GetMark(_studentId, _year);
    }
}