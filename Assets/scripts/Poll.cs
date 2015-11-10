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
		date = DateTime.ParseExact(d, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
		scores = sc;
	}
}
