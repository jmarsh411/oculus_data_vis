using UnityEngine;
using System.Collections;

public class Pin : Poll {
	// this will be assigned in LoadPrefabs, attached to Map
	public static Object pinPrefab;

	public Sphere[] spheres;

	public void Initialize() {

	}

	// Use this for initialization
	void Start () {
		set_mock_data ();

//		foreach (Score score in scores) {
//			Instantiate(Sphere(score))
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void set_mock_data() {
		state = "Michigan";
		transform.position = StatesLookup.pos[state];
	}
}
