using UnityEngine;
using System.Collections;

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
	
	void Update()
	{

	}

}
