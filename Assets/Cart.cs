using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

		int pMark = 1; // position marker for cart
		public int pause = 0; // turn movement on and off
		public int state = 1; // which graph is being traversed
		GameObject slot;
		GameObject slot2;
		GameObject slot3;
		float speed1;
		float speed2 = 2f;
		float speed3;
		public int vehicle = 0;
		public GameObject car;
		public GameObject pmover;
		public int passedWayPoint;
		
		
		public string currentCandidate;
		public float currentPercent;
		public string currentDate;
		public float nextPercent;
		public string nextDate;
		
		float speed = 2f;
		
		Vector3 waypointCart; //initiate travel-to point
		Vector3[] candPositions; //collection of points for first graph
		
		Vector3 waypointCart1; //initiate travel-to point
		Vector3 waypointCartTemp1; //initiate travel-to point
		Vector3[] candPositions1; //collection of points for second graph
		
		Vector3 waypointCart2; //initiate travel-to point
		Vector3[] candPositions2; //collection of points for third graph
		CreateLine createLine;
		
		Vector3 boost;

	// Use this for initialization
	void Start () {
		
		GameObject cart = GameObject.Find("Cart"); // cart
		GameObject slot = GameObject.Find("CartSlot"); // slot for cart to fit into on first graph
		GameObject slot2 = GameObject.Find("CartSlot1"); // slot for cart to fit into on second graph
		GameObject slot3 = GameObject.Find("CartSlot2"); // slot for cart to fit into on third graph
		vehicleSelect();
		
	    createLine = cart.GetComponent<CreateLine>();
		
		createLine.createLine(2, "Paul", "Blue"); // create 1st graph that cart can ride on
		createLine.createLine(0, "Gingrich", "Red"); // create 2nd graph that cart can ride on
		createLine.createLine(1, "Romney", "Yellow"); // create 3rd graph that cart can ride on
		
		if (state == 1)
		{
			transform.position = createLine.Positions1[0];//initiate camera location to first point
			transform.LookAt(createLine.Positions1[1]);//initiate camera aim to second point
		}
		else if (state == 2)
		{
			transform.position = createLine.Positions2[0];//initiate camera location to first point
			transform.LookAt(createLine.Positions2[1]);//initiate camera aim to second point
		}
		else 
		{
			transform.position = createLine.Positions3[0];//initiate camera location to first point
			transform.LookAt(createLine.Positions3[1]);//initiate camera aim to second point
		}


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
	
	void Move ()
	
	{
		
		
		if (pMark == 0)
		{
			Debug.Log("pMark is 0.");
			pMark = pMark + 1;
			waypointCart = candPositions[pMark];
			waypointCart1 = candPositions1[pMark];
			waypointCart2 = candPositions2[pMark];
		}
		
		
		
		
		speed1 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions[pMark][1] - candPositions[pMark - 1][1]),2)) - 10)/10));
		speed2 = speed2;
		speed3 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions2[pMark][1] - candPositions2[pMark - 1][1]),2)) - 10)/10));

		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");
		
		
		
			
			
			if (candPositions1[pMark][1] >= candPositions1[pMark + 1][1])  //if the next hill is going down or flat
			{
			
			Debug.Log("next hill is going down or flat.");

			
			
				
			if(transform.position.z >= waypointCart1[2] ) // if the segment has been traversed
				{
					Debug.Log("Current Hill going down, next hill going down sharp.");
			
					if (passedWayPoint == 1)
					{
						if(transform.position.z >= waypointCart1[2])
						{
							//waypointCart1 = waypointCartTemp1;
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
						float slope = (candPositions1[pMark][1] - candPositions1[pMark - 1][1]) / (candPositions1[pMark][2] - candPositions1[pMark - 1][2]);
						float yIntercept = candPositions1[pMark][1] - (slope * candPositions1[pMark][1]);
						if ((candPositions1[pMark][1] - candPositions1[pMark + 1][1]) > 8) // if the slope is large
						{
						//waypointCartTemp1 = waypointCart1;
							
							passedWayPoint = 1;
							if (candPositions1[pMark - 1][1] > candPositions1[pMark][1]) //if the current hill is going down
							{
								//waypointCart1[2] = waypointCart1[2] + 2f;
								//waypointCart1[1] = (slope * waypointCart1[2]) + yIntercept;
								Debug.Log("Current Hill going down, next hill going down sharp.");
							}
							else if (candPositions1[pMark - 1][1] <= candPositions1[pMark][1])// if the current hill is going up or flat
							{
								waypointCart1[2] = waypointCart1[2] + 1f;
								waypointCart1[1] = (slope * waypointCart1[2]) + yIntercept;
								Debug.Log("Current Hill going up, next hill going down sharp.");
								
							}
							
						}
						else if ((candPositions1[pMark][1] - candPositions1[pMark + 1][1]) <= 8) // if the slope is small
							{
									passedWayPoint = 1;
									
									if (candPositions1[pMark - 1][1] > candPositions1[pMark][1]) //if the current hill is going down
									{
										//waypointCart1[2] = waypointCart1[2] + 3.5f;
										//waypointCart1[1] = waypointCart1[1] + 2f;
										Debug.Log("Current Hill going down, next hill going down mild.");
									}
									else if (candPositions1[pMark - 1][1] <= candPositions1[pMark][1]) //if the current hill is going up or flat
									{
										waypointCart1[2] = waypointCart1[2] + .5f;
										waypointCart1[1] = (slope * waypointCart1[2]) + yIntercept;
											Debug.Log("Current Hill going up, next hill going down mild.");
									}
									
							}
						
					}
						
				}
		}
			
			else if (candPositions1[pMark][1] < candPositions1[pMark + 1][1]) // if the next hill is going up
			{
			
				Debug.Log("next hill is going up.");
				Debug.Log(waypointCart1[2]);
				Debug.Log(waypointCart1[1]);
				Debug.Log(transform.position.z);
				//if(transform.position.z >= waypointCart1[2]) // if the segment has been traversed
				//{
					float slope = (candPositions1[pMark][1] - candPositions1[pMark - 1][1]) / (candPositions1[pMark][2] - candPositions1[pMark - 1][2]);
					float yIntercept = candPositions1[pMark][1] - (slope * candPositions1[pMark][1]);
			
					if (passedWayPoint == 1)
					{
						
					
						if(transform.position.z >= waypointCart1[2] - .5)
						{
							//waypointCart1 = waypointCartTemp1;
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
						if ((candPositions1[pMark + 1][1] - candPositions1[pMark][1]) > 8) // if the slope is large
						{
						//waypointCartTemp1 = waypointCart1;
						Debug.Log(" next hill going up");	
							

							if (candPositions1[pMark - 1][1] <= candPositions1[pMark][1])// if the current hill is going up or flat
							{
								waypointCart1[2] = waypointCart1[2] - 1f; // stops clipping when going into a steep valley.
								//waypointCart1[1] = waypointCart1[1] + 1f;
								Debug.Log("Current Hill going up, next hill going up sharp.");
								
							}
							
						}
						else if ((candPositions1[pMark + 1][1] - candPositions1[pMark][1]) <= 8) // if the slope is small
							{
									passedWayPoint = 1;

									if (candPositions1[pMark - 1][1] <= candPositions1[pMark][1]) //if the current hill is going up
									{
										Debug.Log("PEAK.");
										//waypointCart1[2] = waypointCart1[2] + 3f;
										waypointCart1[1] = waypointCart1[1] + 1f;//this fixes bug on large peaks.
										
									}
									
							}
						
					}
						
				//}
			}
		
			if (candPositions1[pMark - 1][1] > candPositions1[pMark][1]) //if the current hill is going down
			{
				if (speed2 < 12)
				{
					speed2 = speed2 * 1.05f;
				}
			}
			
			else if (candPositions1[pMark-1][1] < candPositions1[pMark][1]) //if the current hill is going up
			{
				if (speed2 > 4)
				{
					speed2 = speed2 * .995f;
				}
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
	
	void MoveBackwards ()	//Same as Move, but modified to make the movement go backwards
	{
		speed1 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions[pMark][1] - candPositions[pMark + 1][1]),2)) - 10)/10));
		speed2 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions1[pMark][1] - candPositions1[pMark + 1][1]),2)) - 10)/10));
		speed3 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions2[pMark][1] - candPositions2[pMark + 1][1]),2)) - 10)/10));

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
	
	void vehicleSelect()
	{
		
		car = GameObject.FindWithTag("car");
		pmover = GameObject.FindWithTag("pmover");
		
		if (vehicle == 0)
		{
			car.transform.localScale = new Vector3(0f,0f,0f);
			pmover.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
			vehicle = 1;
			
		}
		
		else if (vehicle == 1)
		{
			car.transform.localScale = new Vector3(0.03f,0.03f,0.03f);
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
		Debug.Log(state);
	}
	
	if (Input.GetKey("right") || Input.GetKey(KeyCode.JoystickButton5)) //fast forward
	{
		speed = 7;
		speed2 = 7;
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
		else
		{
			pause = 0;
		}
            print("button 9 pause");
	}
	
	if (Input.GetKey("left") || Input.GetKey(KeyCode.JoystickButton4)) //rewind
	{
		MoveBackwards();
            print("button 4 rewind");
	}
	
	if (Input.GetKeyDown("c")) //vehicle select
	{
			vehicleSelect();
            print("vehicle select");
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
