using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {

	float depth;
	
	// Update is called once per frame
	void Update () {
		depth = transform.position.y;
		transform.position = new Vector3 (transform.position.x, transform.position.y, depth);
	}
}
