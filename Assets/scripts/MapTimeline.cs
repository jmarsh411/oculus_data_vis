using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapTimeline : MonoBehaviour {
	public static List<DateTime> dateList;
	public static int currentDate;
	
	public enum Status {
		playing,
		paused,
		rewinding,
		fastforwarding
	}
	public Status status;

	void Awake () {
		// create a sorted date list from the pollByDate dictionary's keys
		dateList = new List<DateTime> (CSVReader.pollByDate.Keys);
		dateList.Sort ();
		currentDate = 0;
		status = Status.playing;
	}
	// Use this for initialization
	void Start () {
		print (dateList [currentDate]);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
