using UnityEngine;
using System.Collections;
using System;

public class CreateLine : MonoBehaviour {
	
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


    public int pMark; //Marker to find current position of cart.
	//public Vector3 test;
	//public Vector3 boost = new Vector3(0,.8f,0);

	
	// Use this for initialization
	public void createLine (int candNum, string color) {
	
	float TrackLength;
	candNum = candNum * 5; // Space candidates apart horizontally by 5 units.
	
	Vector3[] positions = { new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,0].percent, z = 10 }, 
                             new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,1].percent, z = 20},
							 new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,2].percent, z = 30},
							 new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,3].percent, z = 40},
							 new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,4].percent, z = 50},
							 new Vector3 { x = candNum, y = CSVReader.candidateSet[candNum+1,5].percent, z = 60}
		
							};
        DateTime[] dates = { CSVReader.candidateSet[candNum + 1, 0].date,
                         CSVReader.candidateSet[candNum + 1, 1].date,
                         CSVReader.candidateSet[candNum + 1, 2].date,
                         CSVReader.candidateSet[candNum + 1, 3].date,
                         CSVReader.candidateSet[candNum + 1, 4].date,
                         CSVReader.candidateSet[candNum + 1, 5].date
        };
        string name = CSVReader.candidateSet[candNum + 1, 0].name;

        if (candNum/5 == 0)
		{
			Positions2 = positions;
            Position2Dates = dates;
            Position2Candidate = name;
			Debug.Log("ok0.");
		}

		else if (candNum/5 == 1)
		{
			Positions1 = positions;
            Position1Dates = dates;
            Position1Candidate = name;
            Debug.Log("ok1.");
			
		}
		else if (candNum/5 == 2)
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
				
			
			
		
	

	
		//Debug.Log("Script is running.");
		
		for (int i = 0; i < (positions.Length - 1); i++)
		{
			GameObject Track =
				Instantiate(Resources.Load("TrackPiece"), //load track prefab
				positions[i], // take position from positions array
				Quaternion.identity) as GameObject;
				Track.transform.LookAt(positions[i+1]); // aim line towards next point.
				TrackLength = Mathf.Sqrt(100 + Mathf.Pow((positions[i][1] - positions[i + 1][1]),2));//Find Length of TrackPiece to fit between two points.
				//Debug.Log(TrackLength);
				Track.transform.localScale = new Vector3(1f, 0.2f, TrackLength);//Scale Length of TrackPiece appropriately.
				Material newMat = Resources.Load(color, typeof(Material)) as Material;
				
				Transform Piece = Track.transform.FindChild("TrackPieceLine");
				Piece.gameObject.GetComponent<Renderer>().material = newMat;

		}
		
		
		
		
		

	}
	
	void Start()
	
	{
		
		
		
	
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
	
	}
}
