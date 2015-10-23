using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	// Use this for initialization
	void Start () {
		UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
		lineRenderer.Points [0] = new Vector2 (5, 10);
		lineRenderer.Points [1] = new Vector2 (6, 5);
		lineRenderer.Points [2] = new Vector2 (7,12);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
