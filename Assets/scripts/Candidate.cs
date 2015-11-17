using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Candidate {
	public string name;
	public int candNum;
	public Color color;
	public string party;
	public static Queue<Color> colors;

	public static void setupColors(){
		colors = new Queue<Color> ();
		colors.Enqueue (Color.blue);
		colors.Enqueue (Color.yellow);
		colors.Enqueue (Color.red);
		colors.Enqueue (Color.green);
		colors.Enqueue (Color.white);
		colors.Enqueue (Color.magenta);
		colors.Enqueue (Color.cyan);
		colors.Enqueue (Color.black);
		colors.Enqueue (Color.grey);
	}
	 
	public Candidate(string n, int cN) {
		name = n;
		candNum = cN;
		if (colors.Count > 0) {
			color = colors.Dequeue ();
		}
			party = "lets";
	}

	public Candidate(string n, int cN, Color c, string p) {
		name = n;
		candNum = cN;
		color = c;
		party = p;
	}
}
