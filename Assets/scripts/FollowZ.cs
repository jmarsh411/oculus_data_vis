using UnityEngine;
using System.Collections;

public class FollowZ : MonoBehaviour {
	float z_offset;
	Transform cartTrans;

	// Use this for initialization
	void Start () {
		// setup references
		GameObject cart = GameObject.Find("Cart");
		cartTrans = cart.transform;
		// get graph's starting z position
		z_offset = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		// add the cart's z position to the graph so it follows user
		transform.position = new Vector3 (
			transform.position.x,
			transform.position.y,
			z_offset + cartTrans.position.z);
	}
}
