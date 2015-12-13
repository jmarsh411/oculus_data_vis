using UnityEngine;
using System.Collections;

public class UITimeline : MonoBehaviour {
	private GameObject contextRect;
	private float userY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		matchUserHeight ();
	}

	void matchUserHeight() {
		transform.position = new Vector3(transform.position.x,
		                                 userY,
		                                 transform.position.z);
	}

}
