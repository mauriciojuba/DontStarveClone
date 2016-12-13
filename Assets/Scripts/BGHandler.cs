using UnityEngine;
using System.Collections;

public class BGHandler : MonoBehaviour {

    // Use this for initialization
    Transform cam;
    public float distZ;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z + distZ);
    }
}
