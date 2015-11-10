using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	
	RectTransform Bar;

	// Use this for initialization
	void Start () {
	
	Bar = GetComponent<RectTransform>();
	Bar.localScale = new Vector3(0.2f, 0.5f, 1);
	
	}
	

		
	
	
		
	
	// Update is called once per frame
	void Update () {
		
			if (Input.GetKeyDown("space")) // switches cart location to other graphs
			{
				if (Bar.localScale[0] < 0.9)
				{
					Bar.localScale = Bar.localScale +  new Vector3(0.01f, 0, 0);
				}
			}
			

	}
	
    
}