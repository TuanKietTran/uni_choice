using server.Domain;

namespace server.Usecase.Repo;

public interface IParamRepo
{
    Task<HyperParam> GetParamBySubject(string subject);
}