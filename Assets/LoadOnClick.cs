using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int scene_index){
		Application.LoadLevel (scene_index);
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			LoadScene(1);
		}
		else if (Input.GetMouseButtonDown (1)) {
			LoadScene(2);
		}
	}
}
