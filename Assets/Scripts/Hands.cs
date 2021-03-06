﻿using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour {
	public GameObject playerHit;
	GameObject r_Obj, l_Obj;
	public Transform r_Hand, l_Hand;
	public GameObject _objNear;
	bool r_Full,l_Full,canInteract;
	float r_count, l_count;


	void Start () {
		playerHit.SetActive(false);
	}

	void Update () {
		usingHands ();
	}

	void usingHands(){
		getAndDiscartLeftHand ();
		getAndDiscartRightHand ();
	}

	void disableAttack(){
		playerHit.SetActive(false);
	}
	void getAndDiscartLeftHand(){
		if(Input.GetKey(KeyCode.Comma) ){
			l_count++;
			if (l_count > 60f) {
                if (l_Obj != null)
                {
                    l_Obj.GetComponent<Item>().Throw();
                    l_Obj = null;
                }
                else
                {
                    if (canInteract)
                    {
                        l_Obj = _objNear;
                        l_Obj.AddComponent<FixedJoint2D>();
                        keepObjOn_L_Hand();
                        l_Full = true;
                    }
                    l_count = 0f;
                }
			}
		}
		if (Input.GetKeyUp (KeyCode.Comma)&&l_Full) {
			l_count = 0;
			l_Obj.GetComponent<Item> ().Use ();
			playerHit.SetActive(true);
			Invoke("disableAttack",0.5f);
		}
	}
	void getAndDiscartRightHand(){
		if(Input.GetKey(KeyCode.Period)){
			r_count++;
			if (r_count > 60f) {
                if (r_Obj != null)
                {
                    r_Obj.GetComponent<Item>().Throw();
                    r_Obj = null;
                }
                else
                {
                    if (canInteract)
                    {
                        r_Obj = _objNear;
                        r_Obj.AddComponent<FixedJoint2D>();
                        keepObjOn_R_Hand();
                        r_Full = true;
                    }
                    r_count = 0f;
                }
			}
		}
		if (Input.GetKeyUp (KeyCode.Period)&& r_Full) {
			r_count = 0;
			r_Obj.GetComponent<Item> ().Use ();
			playerHit.SetActive(true);
			Invoke("disableAttack",0.5f);
		}
	}
	void keepObjOn_R_Hand (){
		if (r_Obj != null) {
            _objNear.transform.SetParent (r_Hand);
			r_Obj.GetComponent<FixedJoint2D> ().connectedBody = r_Hand.GetComponent<Rigidbody2D> ();
			r_Obj.GetComponent<Depth> ().enabled = false;
			r_Obj.transform.localPosition = Vector2.zero;
		}
	}
    void keepObjOn_L_Hand()
    {
        if (l_Obj != null)
        {
            _objNear.transform.SetParent(l_Hand);
            l_Obj.GetComponent<FixedJoint2D>().connectedBody = l_Hand.GetComponent<Rigidbody2D>();
            l_Obj.GetComponent<Depth>().enabled = false;
            l_Obj.transform.localPosition = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Interactable")){
			canInteract = true;
			_objNear = hit.gameObject;

		}
		else{
			canInteract = false;
			_objNear = null;
		}
	}


}
