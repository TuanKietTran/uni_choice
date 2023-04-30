namespace server.Domain;
public enum Subject
{
    Literature,
    Math,
    English,
    Physics,
    Chemistry,
    Biology,
    History,
    Geography,
    Civil
}

public class SubjectGroup
{
    private string GroupCode { get; }
    private List<Subject> ListSubject { get; }

    SubjectGroup(string groupCode, List<Subject> listSubject)
    {
        this.GroupCode = groupCode;
        this.ListSubject = listSubject;
    }
}