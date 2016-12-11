using UnityEngine;
using System.Collections;

public class AIOne : MonoBehaviour {

    Vector3 player;
    Vector2 playerDirection;
    float Xdif, Ydif;
    int Wall;
    float distance;
	public float Life;
	public float speed;
	public bool passive;
    public float distanceToChase;
	public float distanceToAttack;
	public float distanceToRunAway;
	enum States {idle, chase, run, attack, gethit, die};
	[SerializeField]
	States _state;

	void Start () {
        Wall = 1 << 8;
		_state = States.idle;
	}

	void Update () {
		calculateDistance ();

		switch (_state) {
		case States.idle:
			Idle ();
				break;
		case States.chase:
			Chasing ();
				break;
		case States.attack:
			Attacking ();
				break;
		case States.gethit:
			GetHit ();
				break;
		case States.die:
			Dead ();
				break;
		case States.run:
			Running ();
				break;
		}
    }
	void calculateDistance(){
		distance = Vector2.Distance(player, transform.position);
		player = GameObject.Find("Player").transform.position;
		Xdif = player.x - transform.position.x;
		Ydif = player.y - transform.position.y;
		playerDirection = new Vector2 (Xdif, Ydif);
	}
	void Idle(){
		if (distance < distanceToChase && distance > distanceToAttack && !passive) {
			_state = States.chase;
		} else {
			//wandering
		}

		if (distance < distanceToRunAway && passive) {
			_state = States.run;
		}
	}
	void Chasing(){
		if (passive) {
			_state = States.run;
		} else if (distance > distanceToAttack) {
			if (!Physics2D.Raycast (transform.position, playerDirection, 3, Wall)) {
				GetComponent<Rigidbody2D> ().AddForce (playerDirection.normalized * speed);
			} else {
				_state = States.idle;
			}
		} else {
			_state = States.attack;
		}
	}
	void Attacking(){
		if (passive) {
			_state = States.run;
		} else {
			//attack
			_state = States.chase;
		}
	}
	void GetHit(){
		Life -= 30;
		if (Life <= 0) {
			_state = States.die;
		} else {
			_state = States.chase;
		}

	}
	void Dead(){
		Destroy(gameObject,0.5f);
	}
	void Running(){
		//foge do player
		if (passive) {
			if (!Physics2D.Raycast (transform.position, playerDirection, 3, Wall)) {
				GetComponent<Rigidbody2D> ().AddForce (-playerDirection.normalized * speed);
			} else {
				_state = States.idle;
			}
			if (distance > distanceToRunAway) {
				_state = States.idle;
			}
		} else {
			_state = States.chase;
		}
	}
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("PlayerHit")){
			Debug.Log("Atacou");
			_state = States.gethit;
		}
	}
}
