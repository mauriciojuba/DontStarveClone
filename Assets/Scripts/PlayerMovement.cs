using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float velx,vely;
	public float Velocity;
	Rigidbody2D player;
    Vector3 temp;

    void Start(){
		player = GetComponent<Rigidbody2D> ();
        temp.x = 1;
        temp.y = 1;
        temp.z = 1;
    }

	void Update () {
		velx = Input.GetAxisRaw ("Horizontal") * Velocity;
		vely = Input.GetAxisRaw ("Vertical") * Velocity;
		if (Input.GetKey(KeyCode.Space)) {
			Velocity = 200;
		} else {
			Velocity = 100;
		}
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            temp.x = 1;
            transform.localScale = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            temp.x = -1;
            transform.localScale = temp;
        }

		player.AddForce (Vector3.right * velx);
		player.AddForce (Vector3.up * vely);
		player.velocity = Vector2.zero;

	}
}
