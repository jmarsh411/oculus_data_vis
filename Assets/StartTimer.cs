using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class StartTimer : MonoBehaviour {


	float countDown = 4.0f;
	int started = 0;
	GameObject cart1;
	
	

	
	public void Start()
	{
		
			
			
		Debug.Log("3");
		gameObject.transform.GetChild(0).GetComponent<Text>().text = "3";		
		
	}
	
	void Update()
	{
		cart1 = GameObject.FindWithTag("Cart");
		countDown -= Time.deltaTime;
			if(countDown <= 3.0f)
			{
				gameObject.transform.GetChild(0).GetComponent<Text>().text = "2";
			}
			if(countDown <= 2.0f)
			{
				gameObject.transform.GetChild(0).GetComponent<Text>().text = "1";
				
			}
		    if(countDown <= 1.0f)
			{
				gameObject.transform.GetChild(0).GetComponent<Text>().text = " ";
				cart1.GetComponent<Cart>().pause = 0;
				
			}

	}

}
