namespace server.Domain;

public class University
{
    public string UniCode { get; set; }
    public string UniName { get; set;}
    public string MajorCode { get; set;}
    public string MajorName { get; set;}
    public string SubjectGroup { get; set;}
    public double BenchMark { get; set;}
    public int Year { get; set;}

    public University(string uniCode,
        string uniName,
        string majorCode,
        string majorName,
        string subjectGroup,
        double benchMark,
        int year)
    {
        this.UniCode = uniCode;
        this.UniName = uniName;
        this.MajorCode = majorCode;
        this.MajorName = majorName;
        this.SubjectGroup = subjectGroup;
        this.BenchMark = benchMark;
        this.Year = year;
    }
}