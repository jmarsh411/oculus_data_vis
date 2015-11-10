using UnityEngine;
using System.Collections;

public class TestPinNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		System.DateTime testDate = new System.DateTime (2012, 1, 27);
		Poll testPoll = CSVReader.pollByDate [testDate];
		GameObject pin2 = (GameObject)Instantiate(Pin.pinPrefab);
		pin2.GetComponent<Pin>().Initialize(testPoll);
//		pinscript.Initialize (testPoll);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
