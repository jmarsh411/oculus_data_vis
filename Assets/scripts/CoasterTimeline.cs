using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoasterTimeline : MonoBehaviour {
	static UnityEngine.Object textPrefab;
	public static List<GameObject> timelineList;

	void Awake () {
		// load the text prefab only if it's not already loaded
		if (textPrefab == null)
			textPrefab = Resources.Load ("prefabs/Text");
		if (timelineList == null) {
			timelineList = new List<GameObject>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Initialize (Vector3 [] linePoints){
		// for each point
		for (int pointNum = 0; pointNum < linePoints.Length; pointNum++) {
			// create a new text object
			GameObject textObj = (GameObject)Instantiate(textPrefab);
			// become the parent of this newly instantiated object
			textObj.transform.SetParent(transform, false);
			// set its text to the point's value
			textObj.GetComponent<Text> ().text = Mathf.Round(linePoints[pointNum].y).ToString();
			// set its local Position to the z value
			RectTransform rectTrans = textObj.GetComponent<RectTransform> ();
			rectTrans.anchoredPosition3D = new Vector3(linePoints[pointNum].z, 0f, 0f);
		}
		// add this newly instantiated timeline to the global timeline list
		timelineList.Add (gameObject);
	}
}
