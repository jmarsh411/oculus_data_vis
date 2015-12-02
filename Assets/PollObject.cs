using System;

public class PollObject
{
    public string name;
    public string state;
    public DateTime date;
    public string pollers;
    public float percent;
    public PollObject(string n, string s, string d, string po, string p)
    {
        name = n;
        state = s;
        date = DateTime.ParseExact(d, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        pollers = po;
        percent = float.Parse(p);
    }
}
