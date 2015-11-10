using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
	public static Object spherePrefab;
	public float diameter;
	public Candidate candidate;

	public void Initialize(Score score) {
		candidate = score.candidate;
//		calcDiameter (score);
		// assign or access candidate's color
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	float calcDiameter(Score score) {
//		diameter = 0.05f * score.percentage;
//	}
}
