using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class InteractableObjects : MonoBehaviour {


	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		removeGravity ();
	}

	void removeGravity(){
		rb.gravityScale = 0;
	}
		
	public virtual void Use(){
		
	}
	public virtual void Throw(){
        this.transform.SetParent(null);
        Destroy(this.GetComponent<FixedJoint2D>());
	}
}
