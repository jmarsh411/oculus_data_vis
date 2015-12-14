using UnityEngine;
using System.Collections;

public class ControlsToggle : MonoBehaviour {
	CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("joystick 1 button 3")) {
			if (canvasGroup.alpha == 1)
				canvasGroup.alpha = 0;
			else
				canvasGroup.alpha = 1;
			}
	}
}
