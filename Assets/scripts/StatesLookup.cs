using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatesLookup: MonoBehaviour {
	// dictionary for state, vector3 pairs
	public static Dictionary<string, Vector3> pos;
	public static float y;

	void Awake() {
		y = 1f;
		pos = new Dictionary<string, Vector3> ();
		pos.Add ("AL", new Vector3 (-3.54f, y, 2.29f));
		pos.Add ("AK", new Vector3 (12.43f, y, -8.65f));
		pos.Add ("AZ", new Vector3 (5.74f, y, 1.41f));
		pos.Add ("AR", new Vector3 (-1.47f, y, 1.47f));
		pos.Add ("CA", new Vector3 (8.42f, y, -0.58f));
		pos.Add ("CO", new Vector3 (3.18f, y, -0.49f));
		pos.Add ("CT", new Vector3 (-7.881f, y, -2.426f));
		pos.Add ("DE", new Vector3 (-7.319f, y, -0.982f));
		pos.Add ("FL", new Vector3 (-5.89f, y, 3.88f));
		pos.Add ("GA", new Vector3 (-4.95f, y, 2.28f));
		pos.Add ("HI", new Vector3 (9.91f, y, 5f));
		pos.Add ("ID", new Vector3 (6.04f, y, -3.13f));
		pos.Add ("IL", new Vector3 (-2.51f, y, -0.75f));
		pos.Add ("IN", new Vector3 (-3.54f, y, -0.87f));
		pos.Add ("IA", new Vector3 (-0.84f, y, -1.61f));
		pos.Add ("KS", new Vector3 (0.79f, y, 0f));
		pos.Add ("KY", new Vector3 (-4.15f, y, 0.2f));
		pos.Add ("LA", new Vector3 (-1.54f, y, 3.13f));
		pos.Add ("ME", new Vector3 (-8.76f, y, -4.33f));
		pos.Add ("MD", new Vector3 (-6.85f, y, -1.158f));
		pos.Add ("MA", new Vector3 (-8.49f, y, -2.728f));
		pos.Add ("MI", new Vector3 (-3.75f, y, -2.38f));
//		pos.Add ("MN", new Vector3 (, y, ));
//		pos.Add ("MS", new Vector3 (, y, ));
//		pos.Add ("MO", new Vector3 (, y, ));
//		pos.Add ("MT", new Vector3 (, y, ));
//		pos.Add ("NE", new Vector3 (, y, ));
//		pos.Add ("NV", new Vector3 (, y, ));
//		pos.Add ("NH", new Vector3 (, y, ));
//		pos.Add ("NJ", new Vector3 (, y, ));
//		pos.Add ("NM", new Vector3 (, y, ));
//		pos.Add ("NY", new Vector3 (, y, ));
//		pos.Add ("NC", new Vector3 (, y, ));
//		pos.Add ("ND", new Vector3 (, y, ));
//		pos.Add ("OH", new Vector3 (, y, ));
//		pos.Add ("OK", new Vector3 (, y, ));
//		pos.Add ("OR", new Vector3 (, y, ));
//		pos.Add ("PA", new Vector3 (, y, ));
//		pos.Add ("RI", new Vector3 (, y, ));
//		pos.Add ("SC", new Vector3 (, y, ));
		pos.Add ("SD", new Vector3 (1.21f, y, -2.53f));
		pos.Add ("TN", new Vector3 (-3.29f, y, 0.88f));
		pos.Add ("TX", new Vector3 (1.28f, y, 3.26f));
		pos.Add ("UT", new Vector3 (5.36f, y, -0.85f));
		pos.Add ("VT", new Vector3 (-7.62f, y, -3.82f));
		pos.Add ("VA", new Vector3 (-6.36f, y, -0.21f));
		pos.Add ("WA", new Vector3 (7.16f, y, -4.83f));
		pos.Add ("WV", new Vector3 (-5.48f, y, -0.59f));
		pos.Add ("WI", new Vector3 (-2.13f, y, -2.66f));
		pos.Add ("WY", new Vector3 (3.57f, y, -2.31f));
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
