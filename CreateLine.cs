using UnityEngine;
using System.Collections;



public class CreateLine : MonoBehaviour {
	
	 //public static CSVReader reader = GameObject.FindGameObjectWithTag("CSVReader").GetComponent<CSVReader>();
	 //string testString = reader.test;
	
	float[] RomneyArray = {18,15,31,24,16,31};
	float[] GingrichArray = {25,15,18,11,6,6};
	float[] DanielsArray = {0,2,1,0,0,0};
	
	Vector3[] DanielsPositions;
	int pMark;
	Vector3 test;
	Vector3 boost = new Vector3(0,.8f,0);

	
	// Use this for initialization
	void createLine (float candNum, float[] candArray, string color) {
	
	float TrackLength;
	candNum = candNum * 5; // Space candidates apart horizontally by 5 units.
	
	Vector3[] positions = { new Vector3 { x = candNum, y = candArray[0], z = 10 }, 
                             new Vector3 { x = candNum, y = candArray[1], z = 20},
							 new Vector3 { x = candNum, y = candArray[2], z = 30},
							 new Vector3 { x = candNum, y = candArray[3], z = 40},
							 new Vector3 { x = candNum, y = candArray[4], z = 50},
							 new Vector3 { x = candNum, y = candArray[5], z = 60}
		
							};

	
	DanielsPositions = positions;
	
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
		createLine(2, DanielsArray, "Blue");
		createLine(0, RomneyArray, "Red");
		createLine(1, GingrichArray, "Yellow");
		
		
		pMark = 1;
		transform.position = DanielsPositions[0] + boost;//initiate camera location to first point
		//GetComponent<Camera>().transform.LookAt(DanielsPositions[1] + boost);//initiate camera aim to second point
		test = DanielsPositions[1] + boost; //initiate travel-to point to second point
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		float speed = 2f;
		float camSpeed = 2f;
		
			if(transform.position.z >= test[2])
			{
				pMark = pMark+1;
				
				test = DanielsPositions[pMark] += boost;
				
				//var targetRotation = Quaternion.LookRotation(test - GetComponent<Camera>().transform.position);//Smooth rotation code from unity forums
				//GetComponent<Camera>().transform.rotation = Quaternion.Slerp(GetComponent<Camera>().transform.rotation, targetRotation, camSpeed * Time.deltaTime);//
				
				//GetComponent<Camera>().transform.LookAt(test);//aim camera at next point
			}
				
				
				transform.position = Vector3.MoveTowards(transform.position, test, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
			
		
	
	}
}
