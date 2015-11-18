using UnityEngine;
using System.Collections;

public class LoadCandOnClick : MonoBehaviour {

	GameObject mainCam;
	GameObject candSelectMenu;
	GameObject vr_cursor;
	GameObject cart1;
	public void startScene(int candNum)
	{
		mainCam = GameObject.FindWithTag("CamContainer");
		cart1 = GameObject.FindWithTag("Cart");
		candSelectMenu = GameObject.FindWithTag("CandSelect");
		cart1.GetComponent<Cart>().state = candNum;
		
		
		
		mainCam.transform.parent = cart1.transform;
		mainCam.transform.rotation = mainCam.transform.parent.transform.rotation;
		mainCam.transform.localPosition = new Vector3(0,1,0);
		candSelectMenu.SetActive(false);
		cart1.GetComponent<Cart>().pause = 0;
		vr_cursor = GameObject.FindWithTag ("LookCursor");
		vr_cursor.SetActive (false);
		
	}
	
	void Update()
	{
		
	}

}
