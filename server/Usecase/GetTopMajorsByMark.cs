using server.Domain;
using server.Repository;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetTopMajorsByMark: IUsecase<List<Major>>
{
    private readonly IMajorRepo _repo;
    private readonly int _threshold;

    public GetTopMajorsByMark(IMajorRepo majorRepo, int threshold)
    {
        if (threshold < 1) throw new InvalidThreshold();
        _threshold = threshold;
        _repo = majorRepo;
    }
        
    public Task<List<Major>> ExecuteUsecase()
    {
        return _repo.GetTopMajorsByMark(_threshold);
    }
}


public class InvalidThreshold : Exception
{
    private string _message;

    public InvalidThreshold()
    {
        _message = "InvalidThreshold";
    }
}