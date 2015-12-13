using UnityEngine;
using System.Collections;

public class mapInput : MonoBehaviour {


	
	void Update() {
	
			if (Input.GetKey(KeyCode.Escape)) //|| Input.GetKey(KeyCode.JoystickButton5)) //Needs to be mapped to JoystickButton
			{
						
				Application.LoadLevel(0); // Goes Back to Menu

			}
	

	}
	
	
}
