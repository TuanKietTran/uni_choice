namespace server.Domain;

public class University
{
    private string UniCode { get; }
    private string UniName { get; }
    private string MajorCode { get; }
    private string MajorName { get; }
    private string SubjectGroup { get; }
    private double BenchMark { get; }
    private int Year { get; }

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