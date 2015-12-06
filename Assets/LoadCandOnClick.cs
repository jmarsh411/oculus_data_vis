using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class LoadCandOnClick : MonoBehaviour {

	GameObject mainCam;
	GameObject candSelectMenu;
	GameObject vr_cursor;
	GameObject cart1;
	float countDown = 6.0f;
	int started = 0;

	
	public void startScene(int candNum)
	{
		mainCam = GameObject.FindWithTag("CamContainer");
		cart1 = GameObject.FindWithTag("Cart");
		candSelectMenu = GameObject.FindWithTag("CandSelect");
		cart1.GetComponent<Cart>().state = candNum;

		
		if (candNum == 1)
		{
			cart1.transform.position = GameObject.FindWithTag("CartSlot1").transform.position;
		}
		
		else if (candNum == 2)
		{
			cart1.transform.position = GameObject.FindWithTag("CartSlot2").transform.position;
		}
		
		else if (candNum == 3)
		{
			cart1.transform.position = GameObject.FindWithTag("CartSlot3").transform.position;
		}
		
		
		mainCam.transform.parent = cart1.transform;
		mainCam.transform.rotation = mainCam.transform.parent.transform.rotation;
		mainCam.transform.localPosition = new Vector3(0,1.5f,0);
		candSelectMenu.SetActive(false);

		cart1.GetComponent<Cart>().pause = 1;
		//Debug.Log("Press Start.");
		vr_cursor = GameObject.FindWithTag ("LookCursor");
		vr_cursor.SetActive (false);
		GameObject StartTimer = 
		Instantiate(Resources.Load("StartTimer"), //load track prefab
				new Vector3(0,0,0), // take position from positions array
				Quaternion.identity) as GameObject;
			
		


		
	}
	
	public void vehicleSelect(int vehicleNum)
	{
		cart1 = GameObject.FindWithTag("Cart");
		cart1.GetComponent<Cart>().vehicleSelect(vehicleNum);
		
		Button vSelect1 = GameObject.FindWithTag("vSelect1").GetComponent<Button>();
		Button vSelect2 = GameObject.FindWithTag("vSelect2").GetComponent<Button>();
		Button vSelect3 = GameObject.FindWithTag("vSelect3").GetComponent<Button>();
		
		ColorBlock button1Color = vSelect1.colors;
		ColorBlock button2Color = vSelect2.colors;
		ColorBlock button3Color = vSelect3.colors;
		

		
		if (vehicleNum == 2)
		{	
			button1Color.normalColor = Color.red;
			vSelect1.colors = button1Color;
			
			button2Color.normalColor = Color.white;
			vSelect2.colors = button2Color;
			
			button3Color.normalColor = Color.white;
			vSelect3.colors = button3Color;		
		}
		
		if (vehicleNum == 0)
		{	
			button2Color.normalColor = Color.red;
			vSelect2.colors = button2Color;
			
			button1Color.normalColor = Color.white;
			vSelect1.colors = button1Color;
			
			button3Color.normalColor = Color.white;
			vSelect3.colors = button3Color;		
		}
		
		if (vehicleNum == 1)
		{	
			button3Color.normalColor = Color.red;
			vSelect3.colors = button3Color;
			
			button1Color.normalColor = Color.white;
			vSelect1.colors = button1Color;
			
			button2Color.normalColor = Color.white;
			vSelect2.colors = button2Color;		
		}
		
		
		
	}
	
	void Update()
	{

	}

}
