using UnityEngine;
using System.Collections;



public class CreateLine : MonoBehaviour {
	
	 //public static CSVReader reader = GameObject.FindGameObjectWithTag("CSVReader").GetComponent<CSVReader>();
	 //string testString = reader.test;
	
	public float[] RomneyArray = {18,15,31,24,16,31};
	public float[] GingrichArray = {25,15,18,11,6,6};
	public float[] DanielsArray = {0,2,1,0,0,0};
	
<<<<<<< HEAD
	public Vector3[] Positions1; //Collection of positions for 1st line graph
	public Vector3[] Positions2; //Collection of positions for 2nd line graph
	public Vector3[] Positions3; //Collection of positions for 3rd line graph
	
	public int pMark; //Marker to find current position of cart.
	//public Vector3 test;
	//public Vector3 boost = new Vector3(0,.8f,0);
=======
	Vector3[] DanielsPositions;
	int pMark;
	Vector3 test;
	Vector3 boost = new Vector3(0,2,0);
>>>>>>> master

	
	// Use this for initialization
	public void createLine (int candNum, float[] candArray, string color) {
	
	float TrackLength;
	candNum = candNum * 5; // Space candidates apart horizontally by 5 units.
	
	Vector3[] positions = { new Vector3 { x = candNum, y = candArray[0], z = 10 }, 
                             new Vector3 { x = candNum, y = candArray[1], z = 20},
							 new Vector3 { x = candNum, y = candArray[2], z = 30},
							 new Vector3 { x = candNum, y = candArray[3], z = 40},
							 new Vector3 { x = candNum, y = candArray[4], z = 50},
							 new Vector3 { x = candNum, y = candArray[5], z = 60}
		
							};

		
		if (candNum/5 == 0)
		{
			Positions2 = positions;
			Debug.Log("ok0.");
		}

		else if (candNum/5 == 1)
		{
			Positions1 = positions;
			Debug.Log("ok1.");
			
		}
		else if (candNum/5 == 2)
		{
			Positions3 = positions;
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
