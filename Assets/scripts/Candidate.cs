using UnityEngine;
using System.Collections;

public class Candidate {
	public string name;
	public int candNum;
	public Color color;
	public string party;


	public Candidate(string n, int cN) {
		name = n;
		candNum = cN;
		color = ColorPicker.colors.Dequeue();
		party = "lets";
	}

	public Candidate(string n, int cN, Color c, string p) {
		name = n;
		candNum = cN;
		color = c;
		party = p;
	}
}
