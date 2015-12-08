using System.Collections;
using System;

public class Poll {
	public string state;
	public DateTime date;
	public Score[] scores;

	public Poll(string s, DateTime d, Score[] sc) {
		state = s;
		date = d;
		scores = sc;
	}
	public Poll(string s, string d, Score[] sc) {
		state = s;
		try {
			date = DateTime.ParseExact(d, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
		}
		catch (Exception e) {
			try {
				date = DateTime.ParseExact(d, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
			}
			catch (Exception ex) {
				date = new DateTime(2001,01,01);
			}
		}
		scores = sc;
	}
}
