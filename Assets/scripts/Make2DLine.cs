using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	CreateLine createLine;
	GameObject cart;
	UILineRenderer lineRenderer;

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
		// setup references

//		UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
//		lineRenderer.Points = new Vector2[createLine.Positions1.Length];
//		for (int i = 0; i < createLine.Positions1.Length; i++) {
//			Vector3 vec3 = createLine.Positions1[i];
//			lineRenderer.Points[i] = new Vector2(vec3.z, vec3.y);
		}

	public void Initialize(Vector3[] points, string color){
		// setup references
		cart = GameObject.Find("Cart");
		createLine = cart.GetComponent<CreateLine>();
		lineRenderer = GetComponent<UILineRenderer> ();

		lineRenderer.Points = new Vector2[points.Length];
		for (int i = 0; i < points.Length; i++) {
			Vector3 vec3 = points [i];
			lineRenderer.Points [i] = new Vector2 (vec3.z, vec3.y);
			// lineRenderer.material = 
		}
	}

	// when the parent is set, the RectTransform automatically adjusts so its
	// world position stays the same. this is to undo that.
	public static void followParent(GameObject line, GameObject parent){
		RectTransform rectTrans = line.GetComponent<RectTransform> ();
		rectTrans.SetParent (parent.transform);
		rectTrans.anchoredPosition3D = Vector3.zero;
		rectTrans.rotation = new Quaternion ();
		rectTrans.offsetMax = Vector2.zero;
		rectTrans.offsetMin = Vector2.zero;
	}

}
