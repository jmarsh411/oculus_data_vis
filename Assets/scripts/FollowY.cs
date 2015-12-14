using UnityEngine;
using System.Collections;

public class FollowY : MonoBehaviour {
	private GameObject contextPanel;
	private Transform cartTrans;

	// Use this for initialization
	void Start () {
		// get cart transform reference
		GameObject cart = GameObject.Find("Cart");
		cartTrans = cart.transform;
	}
	
	// Update is called once per frame
	void Update () {
		matchUserHeight ();
	}

	void matchUserHeight() {
		transform.position = new Vector3(transform.position.x,
		                                 cartTrans.position.y,
		                                 transform.position.z);
	}
}
