using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccessInfo : MonoBehaviour {
	GameObject cartObj;
	Cart cart;
	CreateLine lineObj;
	Text candidateText;
	Text percent;
	Text nextPercent;
	Text currDate;
	Text nextDate;
	string candPrepend = "Candidate: ";
	string percentPrepend = "Percent: ";
	string nextPercentPrepend = "Next Percent: ";
	string datePrepend = "Date: ";
	string nextDatePrepend = "Next Date: ";
	Transform transform;
	Vector3 position;

	// Use this for initialization
	void Start () {
		cartObj = GameObject.Find ("Cart");
		cart = cartObj.GetComponent<Cart> ();
//		lineObj = cartObj.GetComponent<CreateLine> ();
//		transform = cartObj.GetComponent<Transform> ();
		candidateText = GameObject.FindGameObjectWithTag ("currCandidate").GetComponent<Text>();
		percent = GameObject.FindGameObjectWithTag ("currPercentage").GetComponent<Text>();
		nextPercent = GameObject.FindGameObjectWithTag ("nextPercentage").GetComponent<Text>();
		currDate = GameObject.FindGameObjectWithTag ("currDate").GetComponent<Text>();
		nextDate = GameObject.FindGameObjectWithTag ("nextDate").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
//		candidateText.text = cart.currentCandidate;
		percent.text = percentPrepend + cart.currentPercent.ToString();
		nextPercent.text = nextPercentPrepend + cart.nextPercent.ToString ();
		currDate.text = datePrepend + cart.currentDate;
		nextDate.text = nextDatePrepend + cart.nextDate;
		//		float x = transform.position.x;
		//		percent.text = percentPrepend + Mathf.Ceil(transform.position.y).ToString();
		//		if (x == 0) {
		//			candidateText.text = candPrepend + lineObj.Position2Candidate;
		//		}
		//		else if (x == 5) {
		//			candidateText.text = candPrepend + lineObj.Position1Candidate;
		//		}
		//		else if (x == 10) {
		//			candidateText.text = candPrepend + lineObj.Position3Candidate;
		//		}
	}
}
