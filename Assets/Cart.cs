using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

		int pMark = 1; // position marker for cart
		public int pause = 0; // turn movement on and off
		public int state = 0; // which graph is being traversed
		GameObject slot;
		GameObject slot2;
		GameObject slot3;
		float speed1 = 5f;
		float speed2 = 5f;
		float speed3 = 5f;
		
		public string currentCandidate;
		public float currentPercent;
		public string currentDate;
		public float nextPercent;
		public string nextDate;
		public int passedWayPoint;
		public int vehicle = 0;
		public GameObject car;
		public GameObject pmover;
		
		float speed = 2f;
		
		Vector3 lookAheadCart;
		
		Vector3[] currentCandPosition;
		Vector3 currentwayPointCart;
		
		Vector3 waypointCart; //initiate travel-to point
		Vector3[] candPositions; //collection of points for first graph
		
		Vector3 waypointCart1; //initiate travel-to point
		Vector3[] candPositions1; //collection of points for second graph
		
		Vector3 waypointCart2; //initiate travel-to point
		Vector3[] candPositions2; //collection of points for third graph
		CreateLine createLine;
		
		GameObject graphCanvas;
		GameObject line2DPrefab;
		
		Vector3 boost;

	// Use this for initialization
	void Start () {
		
		GameObject cart = GameObject.Find("Cart"); // cart
		GameObject slot = GameObject.Find("CartSlot"); // slot for cart to fit into on first graph
		GameObject slot2 = GameObject.Find("CartSlot1"); // slot for cart to fit into on second graph
		GameObject slot3 = GameObject.Find("CartSlot2"); // slot for cart to fit into on third graph

		// grab necessary billboard graph elements
		line2DPrefab = Resources.Load ("prefabs/UI LineRenderer") as GameObject;
		graphCanvas = GameObject.Find ("GraphCanvas");

	    createLine = cart.GetComponent<CreateLine>();
		for (int i = 0; i < 3; i++) {
			createLine.createLine (i, CSVReader.topThreeCandidates [i]);
		}
		//createLine.createLine(2, "Palin"); // create 1st graph that cart can ride on
		//createLine.createLine(0, "Gingrich"); // create 2nd graph that cart can ride on
		//createLine.createLine(1, "Romney"); // create 3rd graph that cart can ride on

		GameObject line1 = Instantiate (line2DPrefab);
		GameObject line2 = Instantiate (line2DPrefab);
		GameObject line3 = Instantiate (line2DPrefab);

		line1.GetComponent<Make2DLine> ().Initialize (createLine.Positions2, CSVReader.topThreeCandidates [0]);
		line2.GetComponent<Make2DLine> ().Initialize (createLine.Positions1, CSVReader.topThreeCandidates [1]);
		line3.GetComponent<Make2DLine> ().Initialize (createLine.Positions3, CSVReader.topThreeCandidates [2]);
		Make2DLine.followParent (line1, graphCanvas);
		Make2DLine.followParent (line2, graphCanvas);
		Make2DLine.followParent (line3, graphCanvas);



		slot.transform.position = createLine.Positions1[0];//initiate camera location to first point
		slot.transform.LookAt(createLine.Positions1[1]);//initiate camera aim to second point
		currentPercent = createLine.Positions1[0][1];
		nextPercent = createLine.Positions1[1][1];
		Debug.Log(currentPercent);
		
		slot2.transform.position = createLine.Positions2[0];//initiate camera location to first point
		slot2.transform.LookAt(createLine.Positions2[1]);//initiate camera aim to second point
		currentPercent = createLine.Positions2[0][1];
		nextPercent = createLine.Positions2[1][1];
		Debug.Log(currentPercent);
		
		slot3.transform.position = createLine.Positions3[0];//initiate camera location to first point
		slot3.transform.LookAt(createLine.Positions3[1]);//initiate camera aim to second point
		currentPercent = createLine.Positions3[0][1];
		nextPercent = createLine.Positions3[1][1];
		Debug.Log(currentPercent);
	
		waypointCart = createLine.Positions1[1]; //initiate travel-to point to second point
		candPositions = createLine.Positions1;
		
		waypointCart1 = createLine.Positions2[1]; //initiate travel-to point to second point
		candPositions1 = createLine.Positions2;
		
		waypointCart2 = createLine.Positions3[1]; //initiate travel-to point to second point
		candPositions2 = createLine.Positions3;
		
		//boost = createLine.boost;
		
		currentDate = createLine.Position1Dates[0].Date.ToString("d");
		nextDate = createLine.Position1Dates[1].Date.ToString("d");
		currentCandidate = createLine.Position1Candidate;
		pause = 1;
	
	}

	
	
	void Move () // This function sets the cart in motion.
	
	{
		
		
		if (pMark == 0) // if pMark has not yet been set.
		{
			Debug.Log("pMark is 0.");
			pMark = pMark + 1;
			waypointCart = candPositions[pMark]; //waypointCarts are where the cart is moving towards. One for each line.
			waypointCart1 = candPositions1[pMark];
			waypointCart2 = candPositions2[pMark];
		}

		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");
		
		if (passedWayPoint != 3)
		
		{
			if (state == 1)
			{
				getMovement(waypointCart, candPositions);
			}
		
			else if (state == 2)
			{
				getMovement(waypointCart1, candPositions1);
			}
			else
			{
				getMovement(waypointCart2, candPositions2);
			}
		}
		
		if (transform.position.z >= candPositions1[candPositions1.Length-1][2])
		{
			Application.LoadLevel(1);
		}
			

			Debug.Log(candPositions1[pMark - 1][1]);
			Debug.Log(candPositions1[pMark][1]);
				
					var targetRotation = Quaternion.LookRotation(waypointCart - slot.transform.position);
			        slot.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed1 * Time.deltaTime);
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed1 * Time.deltaTime);
					
					var targetRotation2 = Quaternion.LookRotation(waypointCart1 - slot2.transform.position);
					slot2.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation2, 10f * Time.deltaTime);
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed2 * Time.deltaTime);

					var targetRotation3 = Quaternion.LookRotation(waypointCart2 - slot3.transform.position);
					slot3.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation3, speed3 * Time.deltaTime);
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed3 * Time.deltaTime);
					
					currentDate = createLine.Position1Dates[pMark - 1].Date.ToString("d");
					nextDate = createLine.Position1Dates[pMark].Date.ToString("d");
				
				if (state == 1)
				{
					//transform.parent = slot.transform;
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed1 * Time.deltaTime);
					currentPercent = candPositions[pMark-1][1];
					nextPercent = candPositions[pMark][1];
					currentCandidate = createLine.Position1Candidate;
					
					Debug.Log(currentDate);
					
				}
				else if (state == 2)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation2, speed * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed2 * Time.deltaTime);
					currentPercent = candPositions1[pMark -1][1];
					nextPercent = candPositions1[pMark][1];
					currentCandidate = createLine.Position2Candidate;
					Debug.Log(currentDate);
					
				}
				else
				{
					
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation3, speed3 * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed3 * Time.deltaTime);
					currentPercent = candPositions2[pMark][1];
					nextPercent = candPositions2[pMark][1];
					currentCandidate = createLine.Position3Candidate;
					
					Debug.Log(currentDate);
		
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
	void getMovement(Vector3 currentwayPointCart, Vector3[] currentCandPositions) // This function looks ahead on the graph to apply anti-clipping physics.
	{
			
			if (currentCandPositions[pMark][1] >= currentCandPositions[pMark + 1][1])  //if the next hill is going down or flat
			{
			
			Debug.Log("next hill is going down or flat.");

			
			
				
			if(transform.position.z >= currentwayPointCart[2] ) // if the segment has been traversed
				{
					Debug.Log("Current Hill going down, next hill going down sharp.");
			
					if (passedWayPoint == 1)
					{
						if(transform.position.z >= currentwayPointCart[2])
						{
							//currentwayPointCart = waypointCartTemp1;
							pMark = pMark+1;
							passedWayPoint = 0;
							if (pMark >= candPositions.Length-1)
							{
								passedWayPoint = 3;
								
							}
							waypointCart = candPositions[pMark];
							waypointCart1 = candPositions1[pMark];
							waypointCart2 = candPositions2[pMark];		
						}
					}
					
					if (passedWayPoint == 0)
					{
						float slope = (currentCandPositions[pMark][1] - currentCandPositions[pMark - 1][1]) / (currentCandPositions[pMark][2] - currentCandPositions[pMark - 1][2]);
						float yIntercept = currentCandPositions[pMark][1] - (slope * currentCandPositions[pMark][1]);
						if ((currentCandPositions[pMark][1] - currentCandPositions[pMark + 1][1]) > 8) // if the slope is large
						{
						//waypointCartTemp1 = currentwayPointCart;
							
							passedWayPoint = 1;
							if (currentCandPositions[pMark - 1][1] > currentCandPositions[pMark][1]) //if the current hill is going down
							{
								//currentwayPointCart[2] = currentwayPointCart[2] + 2f;
								//currentwayPointCart[1] = (slope * currentwayPointCart[2]) + yIntercept;
								Debug.Log("Current Hill going down, next hill going down sharp.");
							}
							else if (currentCandPositions[pMark - 1][1] <= currentCandPositions[pMark][1])// if the current hill is going up or flat
							{
								currentwayPointCart[2] = currentwayPointCart[2] + 3f;
								currentwayPointCart[1] = (slope * currentwayPointCart[2]) + yIntercept;
								Debug.Log("Current Hill going up, next hill going down sharp.");
								
							}
							
						}
						else if ((currentCandPositions[pMark][1] - currentCandPositions[pMark + 1][1]) <= 8) // if the slope is small
							{
									passedWayPoint = 1;
									
									if (currentCandPositions[pMark - 1][1] > currentCandPositions[pMark][1]) //if the current hill is going down
									{
										currentwayPointCart[2] = currentwayPointCart[2] + 3.5f;
										currentwayPointCart[1] = currentwayPointCart[1] + 2f;
										Debug.Log("Current Hill going down, next hill going down mild.");
									}
									else if (currentCandPositions[pMark - 1][1] <= currentCandPositions[pMark][1]) //if the current hill is going up or flat
									{
										currentwayPointCart[2] = currentwayPointCart[2] + 3f;
										currentwayPointCart[1] = (slope * currentwayPointCart[2]) + yIntercept;
											Debug.Log("Current Hill going up, next hill going down mild.");
									}
									
							}
						
					}
						
				}
		}
			
			else if (currentCandPositions[pMark][1] < currentCandPositions[pMark + 1][1]) // if the next hill is going up
			{
			
				Debug.Log("next hill is going up.");
				Debug.Log(currentwayPointCart[2]);
				Debug.Log(currentwayPointCart[1]);
				Debug.Log(transform.position.z);
				//if(transform.position.z >= currentwayPointCart[2]) // if the segment has been traversed
				//{
					float slope = (currentCandPositions[pMark][1] - currentCandPositions[pMark - 1][1]) / (currentCandPositions[pMark][2] - currentCandPositions[pMark - 1][2]);
					float yIntercept = currentCandPositions[pMark][1] - (slope * currentCandPositions[pMark][1]);
			
					if (passedWayPoint == 1)
					{
						
					
						if(transform.position.z >= currentwayPointCart[2] - .5)
						{
							//currentwayPointCart = waypointCartTemp1;
							pMark = pMark+1;
							passedWayPoint = 0;
							if (pMark >= candPositions.Length)
							{
								Application.LoadLevel(1);
							}
							waypointCart = candPositions[pMark];
							waypointCart1 = candPositions1[pMark];
							waypointCart2 = candPositions2[pMark];		
						}
					}
					
					if (passedWayPoint == 0)
					{
						passedWayPoint = 1;
						if ((currentCandPositions[pMark + 1][1] - currentCandPositions[pMark][1]) > 8) // if the slope is large
						{
						//waypointCartTemp1 = currentwayPointCart;
						Debug.Log(" next hill going up");	
							

							if (currentCandPositions[pMark - 1][1] <= currentCandPositions[pMark][1])// if the current hill is going up or flat
							{
								currentwayPointCart[2] = currentwayPointCart[2] - 1f; // stops clipping when going into a steep valley.
								//currentwayPointCart[1] = currentwayPointCart[1] + 1f;
								Debug.Log("Current Hill going up, next hill going up sharp.");
								
							}
							
							else if (currentCandPositions[pMark - 1][1] <= currentCandPositions[pMark][1]) //if the current hill is going up
									{
										Debug.Log("PEAK.");
										//currentwayPointCart[2] = currentwayPointCart[2] + 4f;
										currentwayPointCart[1] = currentwayPointCart[1] + 4f;//this fixes bug on large peaks.
										
									}
							
						}
						else if ((currentCandPositions[pMark + 1][1] - currentCandPositions[pMark][1]) <= 8) // if the slope is small
							{
									passedWayPoint = 1;

									if (currentCandPositions[pMark - 1][1] <= currentCandPositions[pMark][1]) //if the current hill is going up
									{
										Debug.Log("PEAK.");
										//currentwayPointCart[2] = currentwayPointCart[2] + 4f;
										currentwayPointCart[1] = currentwayPointCart[1] + 4f;//this fixes bug on large peaks.
										
									}
									
							}
						
					}
						
				//}
			}
			
		
			// the following if statements modify the speed of each cart depending on whether it is going downhill or uphill.
			if (currentCandPositions[pMark - 1][1] > currentCandPositions[pMark][1]) //if the current hill is going down
			{
				if (speed2 < 12)
				{
					speed2 = speed2 * 1.05f;
				}
				if (speed1 < 12)
				{
					speed1 = speed1 * 1.05f;
				}
				if (speed3 < 12)
				{
					speed3 = speed3 * 1.05f;
				}
			}
			
			else if (currentCandPositions[pMark-1][1] < currentCandPositions[pMark][1]) //if the current hill is going up
			{
				if (speed2 > 4)
				{
					speed2 = speed2 * .995f;
				}
				if (speed3 > 4)
				{
					speed3 = speed3 * .995f;
				}
				if (speed1 > 4)
				{
					speed1 = speed1 * .995f;
				}
			}
		
	}
	
	void MoveBackwards ()	//Same as Move, but modified to make the movement go backwards // Non-clipping physics not applied.
	{


		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");

		
			if(transform.position.z <= waypointCart[2])
			{
				if (pMark !=0)
				{
					pMark = pMark -1;
				    waypointCart = candPositions[pMark];
				    waypointCart1 = candPositions1[pMark];
				    waypointCart2 = candPositions2[pMark];
					
				}
	
			}		      
			
					var targetRotation = Quaternion.LookRotation(candPositions[pMark +1] - slot.transform.position);
			        slot.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed1 * Time.deltaTime);
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark], speed1 * Time.deltaTime);
					
					var targetRotation2 = Quaternion.LookRotation(candPositions1[pMark +1] - slot2.transform.position);
			        slot2.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation2, speed2 * Time.deltaTime);
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark], speed2 * Time.deltaTime);		
					
					var targetRotation3 = Quaternion.LookRotation(candPositions2[pMark +1] - slot3.transform.position);
			        slot3.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation3, speed3 * Time.deltaTime);
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark], speed3 * Time.deltaTime);
				
				if (state == 1) //If 
				{
					//transform.parent = slot.transform;
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark], speed1 * Time.deltaTime);
					Debug.Log(pMark + 1);
				}
				else if (state == 2)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation2, speed * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark], speed2 * Time.deltaTime);	
				}
				else
				{	
					transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation3, speed * Time.deltaTime);
					transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark], speed3 * Time.deltaTime);			
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
	public void vehicleSelect(int vehicleNum)
	{
		
		car = GameObject.FindWithTag("car");
		pmover = GameObject.FindWithTag("pmover");

		
		if (vehicleNum == 0) //if cart is selected as vehicle...
		{
			car.transform.localScale = new Vector3(0f,0f,0f);// scale to make invisible.
			pmover.transform.localScale = new Vector3(1.5f,1.5f,1.5f);// scale to make appropriate size.
			vehicle = 1;	
		}
		
		else if (vehicleNum == 1)
		{
			car.transform.localScale = new Vector3(0.018f,0.018f,0.018f);
			pmover.transform.localScale = new Vector3(0f,0f,0f);
			vehicle = 2;	
		}
		
		else
		{
			car.transform.localScale = new Vector3(0f,0f,0f);
			pmover.transform.localScale = new Vector3(0f,0f,0f);
			vehicle = 0;	
		}
	
		
		
	}
	
		
	
	// Update is called once per frame
	void Update () {
	
    if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (state == 1)
                state = 3;
            else
                state--;
            print("button 7 shift right");
        }	
		
    if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            if (state == 3)
                state = 1;
            else
                state++;
            print("button 6 shift left");
        }

		if (Input.GetKeyDown("space")) // switches cart location to other graphs
	{
		if (state == 1)
		{
			GameObject slot = GameObject.Find("CartSlot1");
			transform.position = candPositions1[0];
			slot.transform.position = candPositions1[0];//initiate camera location to first point
			slot.transform.LookAt(candPositions1[1]);//initiate camera aim to second point
			pMark=0;
			waypointCart = candPositions1[1];
			
			state = 2;
		}
		else if (state == 2)
		{
			GameObject slot = GameObject.Find("CartSlot2");
			transform.position = candPositions2[0];
			slot.transform.position = candPositions2[0];//initiate camera location to first point
			slot.transform.LookAt(candPositions2[1]);//initiate camera aim to second point
			pMark=0;
			waypointCart = candPositions2[1];
			
			state = 3;
		}
		else
		{
			
			GameObject slot = GameObject.Find("CartSlot");
			transform.position = candPositions[0];
			slot.transform.position = candPositions[0];//initiate camera location to first point
			slot.transform.LookAt(candPositions[1]);//initiate camera aim to second point
			pMark=0;
			waypointCart = candPositions[1];
			state = 1;
		}
		
		
		
	}
	
	if (Input.GetKeyDown("s")) // switches cart location to other graphs
	{
		if (state == 1)
		{
			
			
			state = 2;
		}
		else if (state == 2)
		{
			
			
			state = 3;
		}
		else
		{
			
			
			state = 1;
		}
		
		
		
	}
	
	
	
	
	if (Input.GetKey("right") || Input.GetKey(KeyCode.JoystickButton5)) //fast forward
	{
		

		
		speed1 = 45;
		speed2 = 45;
		speed3 = 45;
		
		Move();
            print("button 5 fast forward");
	}
	
	if (Input.GetKeyUp("right") || Input.GetKey(KeyCode.JoystickButton5)) //fast forward release
	{
		
		speed1 = 5;
		speed2 = 5;
		speed3 = 5;
		
		Move();
            print("button 5 fast forward");
	}

	if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.JoystickButton9)) //pause
	{
		if(pause == 1)
		{
			pause = 0;
		}
		else if(pause == 0)
		{
			pause = 1;
		}
		//else
		//{
		//	pause = 0;
		//}
            print("button 9 pause");
	}
	
	if (Input.GetKey("left") || Input.GetKey(KeyCode.JoystickButton4)) //rewind
	{
		MoveBackwards();
            print("button 4 rewind");
	}
	
	if (Input.GetKeyDown("c")) //vehicle select
	{
			if (vehicle == 1)
			{
				vehicleSelect(2);
			}
			
			else if (vehicle == 2)
			{
				vehicleSelect(0);
			}
			
			if (vehicle == 0)
			{
				vehicleSelect(1);
			}
            //print("vehicle select");
	}
	
	if (Input.GetKey(KeyCode.Escape)) //|| Input.GetKey(KeyCode.JoystickButton5)) //Needs to be mapped to JoystickButton
			{
						
				Application.LoadLevel(0); // Goes Back to Menu

			}

	
	if (!Input.anyKey) // if no key is pressed and the game is not paused move forward.
	{
		if (pause == 0)
		{
			speed = 2;
			Move();
		}
	}
	
	//;
	
	}
}
