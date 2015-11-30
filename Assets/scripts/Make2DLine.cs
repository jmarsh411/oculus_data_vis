using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	CreateLine createLine;
	GameObject cart;
	UILineRenderer lineRenderer;

	public void Initialize(Vector3[] points, string candidate){
		// setup references
		cart = GameObject.Find("Cart");
		createLine = cart.GetComponent<CreateLine>();
		lineRenderer = GetComponent<UILineRenderer> ();

		lineRenderer.Points = new Vector2[points.Length];
		for (int i = 0; i < points.Length; i++) {
			Vector3 vec3 = points [i];
			lineRenderer.Points [i] = new Vector2 (vec3.z, vec3.y);
			// color is changing, but it's not being visually updated
			// neither of these is getting th ecolor update to occur.
			lineRenderer.material.color = Candidate.candidateList[candidate].color;
			lineRenderer.color = Candidate.candidateList[candidate].color;
			// this forces an update (supposedly)
			lineRenderer.SetAllDirty();
		}
	}

	// when the parent is set, the RectTransform automatically adjusts so its
	// world position stays the same. this to make the RectTransform follow
	// the parent
	public static void followParent(GameObject line, GameObject parent){
		RectTransform rectTrans = line.GetComponent<RectTransform> ();
		rectTrans.SetParent (parent.transform);
		rectTrans.anchoredPosition3D = Vector3.zero;
		rectTrans.rotation = new Quaternion ();
		rectTrans.offsetMax = Vector2.zero;
		rectTrans.offsetMin = Vector2.zero;
	}

//	void Update() {
//		// force update
//		if (lineRenderer != null)
//			lineRenderer.SetVerticesDirty ();
//
//	}


}
