using UnityEngine;
using UnityEngine.UI; // for Button
using UnityEngine.EventSystems; // for Button's parameter
using System.Collections;

// simple derivation to add ability to access whether a button is highlighted
// This will be used as a sort of global "Is user looking left/right?" boolean
// The button will be very large and placed on the user's left or right.
public class NoisyButton : Button, IPointerExitHandler, IPointerEnterHandler {
	public bool highlighted;

	public void OnPointerEnter(PointerEventData eventData) {
		base.OnPointerEnter (eventData);
		highlighted = true;
		Debug.Log ("User looking at " + name);
	}

	public void OnPointerExit(PointerEventData eventData) {
		base.OnPointerExit (eventData);
		highlighted = false;
		Debug.Log ("User no longer looking at " + name);
	}
}
