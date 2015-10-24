using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

		int pMark = 1;
		int pause = 0;
		int state = 3;
		GameObject slot;
		
		float speed = 2f;
		
		Vector3 waypointCart; //initiate travel-to point
		Vector3[] candPositions;
		
		Vector3 waypointCart1; //initiate travel-to point
		Vector3[] candPositions1;
		
		Vector3 waypointCart2; //initiate travel-to point
		Vector3[] candPositions2;
		
		
		Vector3 boost;

	// Use this for initialization
	void Start () {
		
		GameObject cart = GameObject.Find("Cart");
		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");
		
	    CreateLine createLine = cart.GetComponent<CreateLine>();
		
		createLine.createLine(2, createLine.DanielsArray, "Blue");
		createLine.createLine(0, createLine.RomneyArray, "Red");
		createLine.createLine(1, createLine.GingrichArray, "Yellow");
		
		if (state == 1)
		{
			transform.position = createLine.DanielsPositions[0];//initiate camera location to first point
			transform.LookAt(createLine.DanielsPositions[1]);//initiate camera aim to second point
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
		
		slot.transform.position = createLine.DanielsPositions[0];//initiate camera location to first point
		slot.transform.LookAt(createLine.DanielsPositions[1]);//initiate camera aim to second point
		
		slot2.transform.position = createLine.Positions2[0];//initiate camera location to first point
		slot2.transform.LookAt(createLine.Positions2[1]);//initiate camera aim to second point
		
		slot3.transform.position = createLine.Positions3[0];//initiate camera location to first point
		slot3.transform.LookAt(createLine.Positions3[1]);//initiate camera aim to second point
		
		
		
		
		waypointCart = createLine.DanielsPositions[1]; //initiate travel-to point to second point
		candPositions = createLine.DanielsPositions;
		
		waypointCart1 = createLine.Positions2[1]; //initiate travel-to point to second point
		candPositions1 = createLine.Positions2;
		
		waypointCart2 = createLine.Positions3[1]; //initiate travel-to point to second point
		candPositions2 = createLine.Positions3;
		
		
		
		
		
		boost = createLine.boost;
		
		

	
	}
	
	void Move ()
	
	{
		
		float camSpeed = 2f;
		
		GameObject cart = GameObject.Find("Cart");
		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");
		
			if(transform.position.z >= waypointCart[2])
			{
				pMark = pMark+1;
				
				waypointCart = candPositions[pMark];
				waypointCart1 = candPositions1[pMark];
				waypointCart2 = candPositions2[pMark];
				
				

			
			}
			        slot.transform.LookAt(waypointCart);//aim camera at next point
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed * Time.deltaTime);
					
				
			
					slot2.transform.LookAt(waypointCart1);//aim camera at next point
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed * Time.deltaTime);
					
					
				
					slot3.transform.LookAt(waypointCart2);//aim camera at next point
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed * Time.deltaTime);
				
				if (state == 1)
				{
					//transform.parent = slot.transform;
					transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed * Time.deltaTime);
					transform.LookAt(waypointCart);
				}
				else if (state == 2)
				{
					transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed * Time.deltaTime);
					transform.LookAt(waypointCart1);
				}
				else
				{
					transform.LookAt(waypointCart2);
					transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed * Time.deltaTime);
					
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
	void MoveBackwards ()
	
	{
		
		waypointCart = candPositions[pMark - 1]; //initiate travel-to point to second point
	
		
		waypointCart1 = candPositions1[pMark - 1]; //initiate travel-to point to second point
		
		
		waypointCart2 = candPositions2[pMark - 1]; //initiate travel-to point to second point
		
		
		float camSpeed = 2f;
		
		GameObject cart = GameObject.Find("Cart");
		GameObject slot = GameObject.Find("CartSlot");
		GameObject slot2 = GameObject.Find("CartSlot1");
		GameObject slot3 = GameObject.Find("CartSlot2");
		
			if(transform.position.z <= waypointCart[2])
			{
				pMark = pMark -1;
				
				waypointCart = candPositions[pMark];
				waypointCart1 = candPositions1[pMark];
				waypointCart2 = candPositions2[pMark];
				
				

			
			}
			      
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark-1], speed * Time.deltaTime);
					
				
			
					
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark-1], speed * Time.deltaTime);
					
					
				
					
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark-1], speed * Time.deltaTime);
				
				if (state == 1)
				{
					//transform.parent = slot.transform;
					transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark-1], speed * Time.deltaTime);
		
				}
				else if (state == 2)
				{
					transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark-1], speed * Time.deltaTime);
				
				}
				else
				{
					
					transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark-1], speed * Time.deltaTime);
					
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
		
	
	// Update is called once per frame
	void Update () {
		
		
	if (Input.GetKeyDown("space"))
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
	
	if (Input.GetKey("right"))
	{
		speed = 7;
		Move();
	}

	if (Input.GetKeyDown("p"))
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
	}
	
	if (Input.GetKey("left"))
	{
		MoveBackwards();
	}
	if (Input.GetKey("up"))
	{
		speed = 2;
		Move();
	}
	
	if (!Input.anyKey)
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
