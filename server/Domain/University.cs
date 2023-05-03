namespace server.Domain;

public class University
{
    public string UniCode { get; set; }
    public string UniName { get; set;}

    public University(string uniCode,
        string uniName)
    {
        this.UniCode = uniCode;
        this.UniName = uniName;
    }
}