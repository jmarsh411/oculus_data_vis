using System.Collections;

public class Score {
	public float percent;
	public Candidate candidate;
	public Score(string p, Candidate c) {
		percent = float.Parse (p);
		candidate = c;
	}
}
