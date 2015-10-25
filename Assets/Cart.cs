﻿using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

		int pMark = 1; // position marker for cart
		int pause = 0; // turn movement on and off
		int state = 3; // which graph is being traversed
		GameObject slot;
		GameObject slot2;
		GameObject slot3;
		float speed1;
		float speed2;
		float speed3;
		
		float speed = 2f;
		
		Vector3 waypointCart; //initiate travel-to point
		Vector3[] candPositions; //collection of points for first graph
		
		Vector3 waypointCart1; //initiate travel-to point
		Vector3[] candPositions1; //collection of points for second graph
		
		Vector3 waypointCart2; //initiate travel-to point
		Vector3[] candPositions2; //collection of points for third graph
		
		
		Vector3 boost;

	// Use this for initialization
	void Start () {
		
		GameObject cart = GameObject.Find("Cart"); // cart
		GameObject slot = GameObject.Find("CartSlot"); // slot for cart to fit into on first graph
		GameObject slot2 = GameObject.Find("CartSlot1"); // slot for cart to fit into on second graph
		GameObject slot3 = GameObject.Find("CartSlot2"); // slot for cart to fit into on third graph
		
	    CreateLine createLine = cart.GetComponent<CreateLine>();
		
		createLine.createLine(2, createLine.DanielsArray, "Blue"); // create 1st graph that cart can ride on
		createLine.createLine(0, createLine.RomneyArray, "Red"); // create 2nd graph that cart can ride on
		createLine.createLine(1, createLine.GingrichArray, "Yellow"); // create 3rd graph that cart can ride on
		
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
		
		slot2.transform.position = createLine.Positions2[0];//initiate camera location to first point
		slot2.transform.LookAt(createLine.Positions2[1]);//initiate camera aim to second point
		
		slot3.transform.position = createLine.Positions3[0];//initiate camera location to first point
		slot3.transform.LookAt(createLine.Positions3[1]);//initiate camera aim to second point
	
		waypointCart = createLine.Positions1[1]; //initiate travel-to point to second point
		candPositions = createLine.Positions1;
		
		waypointCart1 = createLine.Positions2[1]; //initiate travel-to point to second point
		candPositions1 = createLine.Positions2;
		
		waypointCart2 = createLine.Positions3[1]; //initiate travel-to point to second point
		candPositions2 = createLine.Positions3;
		
		//boost = createLine.boost;
		
		

	
	}
	
	void Move ()
	
	{
		
		float camSpeed = 2f;
		speed1 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions[pMark][1] - candPositions[pMark - 1][1]),2)) - 10)/10));
		speed2 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions1[pMark][1] - candPositions1[pMark - 1][1]),2)) - 10)/10));
		speed3 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions2[pMark][1] - candPositions2[pMark - 1][1]),2)) - 10)/10));
		
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
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed1 * Time.deltaTime);

					slot2.transform.LookAt(waypointCart1);//aim camera at next point
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed2 * Time.deltaTime);

					slot3.transform.LookAt(waypointCart2);//aim camera at next point
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed3 * Time.deltaTime);
				
				if (state == 1)
				{
					//transform.parent = slot.transform;
					transform.LookAt(waypointCart);
					transform.position = Vector3.MoveTowards(slot.transform.position, waypointCart, speed1 * Time.deltaTime);
					
				}
				else if (state == 2)
				{
					transform.LookAt(waypointCart1);
					transform.position = Vector3.MoveTowards(slot2.transform.position, waypointCart1, speed2 * Time.deltaTime);
					
				}
				else
				{
					
					transform.LookAt(waypointCart2);
					transform.position = Vector3.MoveTowards(slot3.transform.position, waypointCart2, speed3 * Time.deltaTime);
		
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
	void MoveBackwards ()	//Same as Move, but modified to make the movement go backwards
	{
		
		float camSpeed = 2f;
		speed1 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions[pMark][1] - candPositions[pMark + 1][1]),2)) - 10)/10));
		speed2 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions1[pMark][1] - candPositions1[pMark + 1][1]),2)) - 10)/10));
		speed3 = speed + (speed * ((Mathf.Sqrt(100 + Mathf.Pow((candPositions2[pMark][1] - candPositions2[pMark + 1][1]),2)) - 10)/10));
		
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
					slot.transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark], speed1 * Time.deltaTime);					
					slot2.transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark], speed2 * Time.deltaTime);					
					slot3.transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark], speed3 * Time.deltaTime);
				
				if (state == 1) //If 
				{
					//transform.parent = slot.transform;
					transform.position = Vector3.MoveTowards(slot.transform.position, candPositions[pMark], speed * Time.deltaTime);
				}
				else if (state == 2)
				{
					transform.position = Vector3.MoveTowards(slot2.transform.position, candPositions1[pMark], speed * Time.deltaTime);	
				}
				else
				{	
					transform.position = Vector3.MoveTowards(slot3.transform.position, candPositions2[pMark], speed * Time.deltaTime);			
				}
				
				//transform.position = Vector3.MoveTowards(transform.position, waypointCart1, speed * Time.deltaTime);
				//GetComponent<Camera>().transform.position += boost;
		
	}
	
		
	
	// Update is called once per frame
	void Update () {
		
		
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
	}
	
	if (Input.GetKey("right")) //fast forward
	{
		speed = 7;
		Move();
	}

	if (Input.GetKeyDown("p")) //pause
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
	
	if (Input.GetKey("left")) //rewind
	{
		MoveBackwards();
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
