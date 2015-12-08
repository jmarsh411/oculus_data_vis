using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class CreateLine : MonoBehaviour {

    //public static GameObject readerObj = GameObject.FindGameObjectWithTag("CSVReader");
    //public static CSVReader reader = (CSVReader) readerObj.GetComponent(typeof(CSVReader));

	 //public static CSVReader reader = GameObject.FindGameObjectWithTag("CSVReader").GetComponent<CSVReader>();
	 //string testString = reader.test;
	

	public Vector3[] Positions1; //Collection of positions for 1st line graph
	public Vector3[] Positions2; //Collection of positions for 2nd line graph
	public Vector3[] Positions3; //Collection of positions for 3rd line graph
    public DateTime[] Position1Dates;
    public DateTime[] Position2Dates;
    public DateTime[] Position3Dates;
    public string Position1Candidate;
    public string Position2Candidate;
    public string Position3Candidate;
	public UnityEngine.Object trackpiece;


    public int pMark; //Marker to find current position of cart.
	//public Vector3 test;
	//public Vector3 boost = new Vector3(0,.8f,0);

	
	// Use this for initialization
	public void createLine (int candNum, string candName) {
	string colorm = "Red";
	Color color = Color.red;
	float TrackLength;
	candNum = candNum * 10; // Space candidates apart horizontally by 10 units.

		Vector3[] positions = new Vector3[CSVReader.pollByDateCoaster.Count];
		DateTime[] dates = new DateTime[CSVReader.pollByDateCoaster.Count];
		int posI = 0;
		foreach (KeyValuePair<DateTime, Poll> poll in CSVReader.pollByDateCoaster.OrderBy(key => key.Key)) {
			bool found = false;
			dates[posI] = poll.Key;
			if (dates[posI].Equals(new DateTime (2010, 06, 20))) {
				for (int i = 0; i < poll.Value.scores.Length; i++) {
					if (poll.Value.scores[i] != null) {
						print(poll.Key + " " + poll.Value.scores[i].candidate.name + " " + poll.Value.scores[i].percent);
					}
				}
			}
			for (int i = 0; i < poll.Value.scores.Length; i++) {
				if (poll.Value.scores[i] != null) {
					if (poll.Value.scores[i].candidate.name.Equals(candName)) {
						found = true;
						color = poll.Value.scores[i].candidate.color;
						if(candName.Equals("Palin"))
							print (poll.Key + " " + candName + " " + poll.Value.scores[i].percent);
						positions[posI] = new Vector3 { x = candNum, y = poll.Value.scores[i].percent, z = 10 * (posI + 1) };
						posI++;
					}
				}
			}
			if (!found) {
				if (posI == 0) {
					positions[posI] = new Vector3 { x = candNum, y = 0, z = 10};
				}
				else {
					positions[posI] = new Vector3 { x = candNum, y = positions[posI - 1].y, z = positions[posI - 1].z + 10};
				}
				posI++;
			}
		}
        string name = candName;
		createButton (candNum/10, candName, color);

        if (candNum/10 == 1)
		{
			Positions2 = positions;
            Position2Dates = dates;
            Position2Candidate = name;
			Debug.Log("ok0.");
		}


		else if (candNum/10 == 0)
		{
			Positions1 = positions;
            Position1Dates = dates;
            Position1Candidate = name;
            Debug.Log("ok1.");
			
		}
		else if (candNum/10 == 2)
		{
			Positions3 = positions;
            Position3Dates = dates;
            Position3Candidate = name;
            Debug.Log("ok2.");
			
		}
		
		else
		{
			
			Debug.Log("Invalid Candidate Number");
			
		}		
				
			
			
		
	
		trackpiece = Resources.Load("TrackPiece");
	
		//Debug.Log("Script is running.");
		
		for (int i = 0; i < (positions.Length - 1); i++)
		{
			GameObject Track =
				Instantiate(trackpiece, //load track prefab
				positions[i], // take position from positions array
				Quaternion.identity) as GameObject;
				Track.transform.LookAt(positions[i+1]); // aim line towards next point.
				TrackLength = Mathf.Sqrt(100 + Mathf.Pow((positions[i][1] - positions[i + 1][1]),2));//Find Length of TrackPiece to fit between two points.
				//Debug.Log(TrackLength);
				Track.transform.localScale = new Vector3(1f, 0.2f, TrackLength);//Scale Length of TrackPiece appropriately.
				Material newMat = Resources.Load(colorm, typeof(Material)) as Material;
				Transform Piece = Track.transform.FindChild("TrackPieceLine");
				Piece.gameObject.GetComponent<Renderer>().material = newMat;
				Piece.gameObject.GetComponent<Renderer>().material.color = color;

				
			GameObject Ring =
				Instantiate(Resources.Load("TextRing"), //load track prefab
				positions[i], // take position from positions array
				Quaternion.identity) as GameObject;
				
				string currentPercent = positions[i].y.ToString();
				if (currentPercent.Length <= 1)
				{
					currentPercent = " " + currentPercent;
				}
				
				currentPercent = currentPercent.Substring(0,2);
				
			    Ring.gameObject.transform.GetChild(0).GetComponent<Text>().text = (dates[i].ToString().Substring(0,9) + " - " + currentPercent + "%");
		

		}
		
		
		
		
		

	}

	public void createButton(int candNum, string candName, Color color) {
		GameObject buttonContainer = null;
		Button candButton = null;
		Text candText = null;
		switch (candNum) {
			case 0:
				buttonContainer = GameObject.Find ("Candidate1");
				break;
			case 1:
				buttonContainer = GameObject.Find ("Candidate2");
				break;
			case 2:
				buttonContainer = GameObject.Find ("Candidate3");
				break;
		}
		candButton = buttonContainer.GetComponentInChildren<Button>();
		candText = candButton.GetComponentInChildren<Text> ();
		ColorBlock cb = candButton.colors;
		cb.normalColor = color;
		candButton.colors = cb;
		candText.text = candName;
		candText.color = Color.white;
	}
	
	void Start()
	
	{
		
		
		
	
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
	
	}
}
