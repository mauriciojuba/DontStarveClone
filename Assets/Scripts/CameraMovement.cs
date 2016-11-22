using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    Transform target;

	void Start () {
        target = GameObject.Find("Player").transform;
	}
	void Update () {
        transform.position = target.position + new Vector3(0, 0, -10);
	}
}
