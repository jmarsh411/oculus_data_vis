using UnityEngine;
using System.Collections;

public class LoadPrefabs : MonoBehaviour {

	void Awake() {
		Pin.pinPrefab = Resources.Load ("prefabs/Pin");
	}
	// Use this for initialization
	void Start () {
	
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
