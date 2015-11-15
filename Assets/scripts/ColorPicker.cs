using UnityEngine;
using System.Collections.Generic;

public class ColorPicker : MonoBehaviour {
	public static Queue<Color> colors;
	void Awake () {
		colors = new Queue<Color> ();
		colors.Enqueue (Color.blue);
		colors.Enqueue (Color.yellow);
		colors.Enqueue (Color.red);
		colors.Enqueue (Color.green);
		colors.Enqueue (Color.white);
		colors.Enqueue (Color.magenta);
		colors.Enqueue (Color.cyan);
		colors.Enqueue (Color.black);
		colors.Enqueue (Color.grey);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
