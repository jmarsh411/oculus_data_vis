using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccessInfo : MonoBehaviour {
	GameObject cart;
	CreateLine lineObj;
	Text candidateText;
	string candPrepend = "Following: ";
	Transform transform;
	Vector3 position;

	// Use this for initialization
	void Start () {
		cart = GameObject.Find ("Cart");
		lineObj = cart.GetComponent<CreateLine> ();
		transform = cart.GetComponent<Transform> ();
		candidateText = GameObject.FindGameObjectWithTag ("currCandidate").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		if (x == 0) {
			candidateText.text = candPrepend + lineObj.Position2Candidate;
		}
		else if (x == 5) {
			candidateText.text = candPrepend + lineObj.Position1Candidate;
		}
		else if (x == 10) {
			candidateText.text = candPrepend + lineObj.Position3Candidate;
		}
	}
}
