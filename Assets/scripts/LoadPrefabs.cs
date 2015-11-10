using UnityEngine;
using System.Collections;

public class LoadPrefabs : MonoBehaviour {

	void Awake() {
		Pin.pinPrefab = Resources.Load ("prefabs/Pin");
		Sphere.spherePrefab = Resources.Load ("prefabs/Sphere");
	}
	// Use this for initialization
	void Start () {
	
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
