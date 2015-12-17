using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasGetMainCamera : MonoBehaviour {

	void Awake() {
		// use the main camera for this Canvas
		GetComponent<Canvas> ().worldCamera = Camera.main;
	}
}
