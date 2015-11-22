using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	CreateLine createLine;

	// Use this for initialization
	void Start () {
//		int pointCount = 6;
//		UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
//		lineRenderer.Points = new Vector2[pointCount];
//		// for each candidate
//		for (int row = 1; row <= 1; row++){
//			// for each point
//			for (int col=0; col <= pointCount - 1; col++){
//				lineRenderer.Points[col] = new Vector2 {x = (col + 1) * 10, y = CSVReader.candidateSet[row,col].percent};
//			}
//		}

		GameObject cart = GameObject.Find("Cart");
		createLine = cart.GetComponent<CreateLine>();
		UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
		lineRenderer.Points = new Vector2[createLine.Positions1.Length];
		for (int i = 0; i < createLine.Positions1.Length; i++) {
			Vector3 vec3 = createLine.Positions1[i];
			lineRenderer.Points[i] = new Vector2(vec3.z, vec3.y);
		}

	}

	public static void Initialize(){

	}
	// Update is called once per frame
	void Update () {
	
	}
}
