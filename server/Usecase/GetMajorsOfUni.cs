using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetMajorsOfUni: IUsecase<List<Major>>
{

    private readonly IMajorRepo _majorRepo;
    private readonly string _uniCode;

    public GetMajorsOfUni(IMajorRepo majorRepo, string uniCode)
    {
        _majorRepo = majorRepo;
        _uniCode = uniCode;

    }
    
    public Task<List<Major>> ExecuteUsecase()
    {
        return _majorRepo.GetMajorsOfUni(_uniCode);
    }
}