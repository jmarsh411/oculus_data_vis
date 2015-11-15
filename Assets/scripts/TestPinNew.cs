using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPinNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		List<System.DateTime> dateList = new List<System.DateTime> ();
//		System.DateTime testDate = new System.DateTime (2012, 1, 27);
//		dateList.Add (testDate);
		System.DateTime testDate2 = new System.DateTime (2012, 2, 20);
		dateList.Add (testDate2);
//		System.DateTime testDate3 = new System.DateTime (2012, 1, 17);
//		dateList.Add (testDate3);
//		System.DateTime testDate4 = new System.DateTime (2012, 1, 17);
//		dateList.Add (testDate4);
		foreach (System.DateTime date in dateList) {
			foreach (Poll poll in CSVReader.pollByDate [date]) {
				GameObject pin = (GameObject)Instantiate (Pin.pinPrefab);
				pin.GetComponent<Pin> ().Initialize (poll);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
