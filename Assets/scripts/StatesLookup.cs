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
		pos.Add ("MI", new Vector3 (-3.75f, y, -2.38f));
		pos.Add ("FL", new Vector3 (-5.89f, y, 3.88f));
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
