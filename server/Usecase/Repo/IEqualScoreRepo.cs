namespace server.Usecase.Repo;

public interface IEqualScoreRepo: IParamRepo, ISubjectRepo
{
    Task<double> GetMajorScoreByGroup(string majorCode, string groupCode);
}