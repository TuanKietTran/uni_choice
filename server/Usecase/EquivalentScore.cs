using server.Usecase.DTO;
using server.Usecase.Repo;

namespace server.Usecase;

public class EquivalentScore : IUsecase<EqualScore>
{
    private readonly string _majorCode;
    private readonly string _subjectGroup;

    private readonly IEqualScoreRepo _repo;

    public EquivalentScore(
        IEqualScoreRepo repo,
        string majorCode,
        string subjectGroup
        )
    {
        _repo = repo;
        _majorCode = majorCode;
        _subjectGroup = subjectGroup;
    }

    public async Task<EqualScore> ExecuteUsecase()
    {
        const int round = 100;
        var queryMark = await _repo.GetMajorScoreByGroup(_majorCode, _subjectGroup);
        var queryGroup = await _repo.GetGroup(_subjectGroup);
        double total = 0;
        foreach (var sub in queryGroup)
        {
            var param = await _repo.GetParamBySubject(sub);
            total += (param.Std / param.StdNow * (queryMark / 3 - param.MeanNow) + param.Mean);
        }

        var results = new EqualScore
        {
            CurrentScore = queryMark,
            PredictScore = Math.Round(total * round, MidpointRounding.AwayFromZero) / round
        };
        
        return results;
    }
}