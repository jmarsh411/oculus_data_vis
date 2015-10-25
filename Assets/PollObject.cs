using System;

public class PollObject
{
    public string name;
    public DateTime date;
    public string pollers;
    public float percent;
    public PollObject(string n, string d, string po, string p)
    {
        name = n;
        date = DateTime.ParseExact(d, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        pollers = po;
        percent = float.Parse(p);
    }
}
