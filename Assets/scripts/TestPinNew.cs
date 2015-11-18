using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPinNew : MonoBehaviour {
	
	private System.DateTime date;
	// Use this for initialization
	void Start () {
//		List<System.DateTime> dateList = new List<System.DateTime> ();
//		System.DateTime testDate = new System.DateTime (2012, 1, 27);
//		dateList.Add (testDate);
//		System.DateTime testDate2 = new System.DateTime (2012, 2, 20);
//		dateList.Add (testDate2);
//		System.DateTime testDate3 = new System.DateTime (2012, 1, 17);
//		dateList.Add (testDate3);
//		foreach (System.DateTime date in dateList) {
//			foreach (Poll poll in CSVReader.pollByDate [date]) {
//				GameObject pin = (GameObject)Instantiate (Pin.pinPrefab);
//				pin.GetComponent<Pin> ().Initialize (poll);
//			}
//		}

		InvokeRepeating ("DrawPins", 0f, 3.5f);
	}

	// This is temporary demo code. final implementation will be more organized
	void DrawPins () {
		date = MapTimeline.dateList [MapTimeline.currentDate];
		foreach (Poll poll in CSVReader.pollByDate [date]) {
			GameObject pin = (GameObject)Instantiate (Pin.pinPrefab);
			pin.GetComponent<Pin> ().Initialize (poll);
			// Destroy existing pins in that state so they don't overlap
			foreach (Pin existingPin in FindObjectsOfType<Pin>()) {
				if (poll.state == existingPin.state)
					Destroy(existingPin);
			}
		}
		if (MapTimeline.currentDate < MapTimeline.dateList.Count)
			MapTimeline.currentDate++;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
