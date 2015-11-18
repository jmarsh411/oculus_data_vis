using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	float horiz;
	float vert;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horiz = Input.GetAxis ("Horizontal");
		vert = Input.GetAxis ("Vertical");
		transform.position = new Vector3(transform.position.x + horiz,
			                             transform.position.y,
			                             transform.position.z + vert);
	}
}
