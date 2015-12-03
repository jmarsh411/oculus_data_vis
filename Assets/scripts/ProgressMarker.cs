using UnityEngine;
using System.Collections;

public class ProgressMarker : MonoBehaviour {
	RectTransform rectTrans;
	GameObject cartRef;
	Transform cartTrans;

	// Use this for initialization
	void Start () {
		rectTrans = GetComponent<RectTransform> ();
		cartRef = GameObject.Find ("Cart");
		cartTrans = cartRef.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTrans.anchoredPosition = new Vector2(cartTrans.position.z, 0f);
	}
}
