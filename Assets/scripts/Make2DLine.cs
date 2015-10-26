using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	// Use this for initialization
	void Start () {
		int pointCount = 6;
		UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
		lineRenderer.Points = new Vector2[pointCount];
		// for each candidate
		for (int row = 1; row <= 1; row++){
			// for each point
			for (int col=0; col <= pointCount - 1; col++){
				lineRenderer.Points[col] = new Vector2 {x = (col + 1) * 10, y = CSVReader.candidateSet[row,col].percent};
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
