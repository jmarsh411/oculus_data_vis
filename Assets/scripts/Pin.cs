using UnityEngine;
using System.Collections;
using System;

public class Pin : MonoBehaviour {
	// this will be assigned in LoadPrefabs, attached to Map
	public static UnityEngine.Object pinPrefab;

	public string state;
	public DateTime date;
	public Score[] scores;
	public Sphere[] spheres;

	public void Initialize(Poll poll) {
		state = poll.state;
		date = poll.date;
		scores = poll.scores;
	}

	// Use this for initialization
	void Start () {
		set_mock_data ();

		foreach (Score score in scores) {
			if (score != null){
				Sphere sphere = Instantiate(Sphere.spherePrefab) as Sphere;
				sphere.Initialize(score);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void set_mock_data() {
		state = "Michigan";
		transform.position = StatesLookup.pos[state];
	}
}
