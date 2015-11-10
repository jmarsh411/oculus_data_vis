 using System.Collections;


public class Candidate {
	public string name;
	public int candNum;
	public string color;
	public string party;

	public Candidate(string n, int cN) {
		name = n;
		candNum = cN;
		color = "Black";
		party = "lets";
	}

	public Candidate(string n, int cN, string c, string p) {
		name = n;
		candNum = cN;
		color = c;
		party = p;
	}
}
