using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float velx,vely;
	public float Velocity;
	Rigidbody2D player;

	void Start(){
		player = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		velx = Input.GetAxisRaw ("Horizontal") * Velocity;
		vely = Input.GetAxisRaw ("Vertical") * Velocity;
		if (Input.GetKey(KeyCode.Space)) {
			Velocity = 200;
		} else {
			Velocity = 100;
		}


		player.AddForce (Vector3.right * velx);
		player.AddForce (Vector3.up * vely);
		player.velocity = Vector2.zero;

	}
}
