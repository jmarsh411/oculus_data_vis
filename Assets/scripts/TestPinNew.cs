using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPinNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		System.DateTime testDate = new System.DateTime (2012, 1, 27);
		System.DateTime testDate2 = new System.DateTime (2012, 2, 20);
		foreach (Poll poll in CSVReader.pollByDate [testDate]) {
			GameObject pin = (GameObject)Instantiate (Pin.pinPrefab);
			pin.GetComponent<Pin> ().Initialize (poll);
		}
		foreach (Poll poll in CSVReader.pollByDate [testDate2]) {
			GameObject pin = (GameObject)Instantiate (Pin.pinPrefab);
			pin.GetComponent<Pin> ().Initialize (poll);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
