using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetGroupSubject: IUsecase<List<string>>
{
    private readonly IMajorRepo _majorRepo;
    private readonly string _majorCode;

    public GetGroupSubject(IMajorRepo majorRepo, string majorCode)
    {
        _majorRepo = majorRepo;
        _majorCode = majorCode;

    }
    
    public Task<List<string>> ExecuteUsecase()
    {
        return _majorRepo.GetGroupSubject(_majorCode);
    }
}