using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatesLookup: MonoBehaviour {
	// dictionary for state, vector3 pairs
	public static Dictionary<string, Vector3> pos;
	public static float y;

	void Awake() {
		y = 1f;
		pos = new Dictionary<string, Vector3> ();
		pos.Add ("Michigan", new Vector3 (-3.75f, y, -2.38f));
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
