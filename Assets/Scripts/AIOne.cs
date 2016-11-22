using UnityEngine;
using System.Collections;

public class AIOne : MonoBehaviour {

    Vector3 player;
    Vector2 playerDirection;
    float Xdif, Ydif;
    public float speed;
    private int Wall;
    float distance;
    public float distanceToChase;
	void Start () {
        Wall = 1 << 8;
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector2.Distance(player, transform.position);
        player = GameObject.Find("Player").transform.position;

        if (distance < distanceToChase)
        {
            Xdif = player.x - transform.position.x;
            Ydif = player.y - transform.position.y;
            playerDirection = new Vector2(Xdif, Ydif);

            if (!Physics2D.Raycast(transform.position, playerDirection, 3, Wall))
            {
                GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized * speed);
            }
        }

    }
}
