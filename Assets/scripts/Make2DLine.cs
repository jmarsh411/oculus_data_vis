using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class Make2DLine : MonoBehaviour {
	UILineRenderer lineRenderer;

	static Object material;
	Material matInstance;

	public void Initialize(Vector3[] points, string candidate){
		// load material if not already loaded
		if (material == null)
			material = Resources.Load ("UILineRendererMaterial");
		
		lineRenderer = GetComponent<UILineRenderer> ();

		// create a new material instance and set its color
		matInstance = new Material(material as Material);
		matInstance.SetColor ("_Color", Candidate.candidateList [candidate].color);
		lineRenderer.material = matInstance;

		lineRenderer.Points = new Vector2[points.Length];
		for (int i = 0; i < points.Length; i++) {
			Vector3 vec3 = points [i];
			lineRenderer.Points [i] = new Vector2 (vec3.z, vec3.y);
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

}
