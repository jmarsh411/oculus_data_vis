using UnityEngine;
using System.Collections;

public class TestPinNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		System.DateTime testDate = new System.DateTime (2012, 1, 27);
		Poll testPoll = CSVReader.pollByDate [testDate];
		Pin pin2 = Instantiate(Pin.pinPrefab) as Pin;
		pin2.Initialize (testPoll);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
