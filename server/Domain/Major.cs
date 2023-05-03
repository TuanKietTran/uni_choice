namespace server.Domain;

public class Major
{
    public string UniCode { get; set; }
    public string UniName { get; set;}
    public string MajorCode { get; set;}
    public string MajorName { get; set;}
    public double? BenchMark { get; set;}

    public Major(string uniCode,
        string uniName,
        string majorCode,
        string majorName,
        double? mark = null
)
    {
        this.UniCode = uniCode;
        this.UniName = uniName;
        this.MajorCode = majorCode;
        this.MajorName = majorName;
        if (mark is not null)
        {
            BenchMark = mark;
        }
    }
}