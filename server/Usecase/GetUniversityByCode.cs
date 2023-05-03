using server.Domain;
using server.Usecase.Repo;

namespace server.Usecase;

public class GetUniversityByCode: IUsecase<University>
{
    private const int LimitCode = 3;
    private readonly IUniversityRepo _universityRepo;
    private readonly string _code;

    public GetUniversityByCode(IUniversityRepo universityRepo, string code)
    {
        _universityRepo = universityRepo;
        if (code.Length != LimitCode) throw new UniNotFound(code);
        _code = code;
    }
    
    
    public Task<University> ExecuteUsecase()
    {
        return _universityRepo.GetUniversityByCode(_code);
    }
}