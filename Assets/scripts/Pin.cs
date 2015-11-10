using UnityEngine;
using System.Collections;
using System;

public class Pin : MonoBehaviour {
	// this will be assigned in LoadPrefabs, attached to Map
	public static UnityEngine.Object pinPrefab;

	public string state;
	public DateTime date;
	public Score[] scores;
	public GameObject[] spheres;

	public void Initialize(Poll poll) {
		state = poll.state;
		date = poll.date;
		scores = poll.scores;

		// setup the sphere array to be the size of the non-null scores
		for (int i = 0; i < scores.Length; i++) {
			Score score = scores [i];
			if (score == null) {
				spheres = new GameObject[i + 1];
			}
		}
			for (int i = 0; i < scores.Length; i++) {
			Score score = scores[i];
			if (score != null){
				GameObject sphere = (GameObject)Instantiate(Sphere.spherePrefab);
				sphere.GetComponent<Sphere>().Initialize(score);
				// make the sphere's orientation relative to this Pin
				sphere.transform.parent = transform;
				spheres[i] = sphere;
			}
		}
		transform.position = StatesLookup.pos[state];

		// set each sphere's position based on its ranking
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
