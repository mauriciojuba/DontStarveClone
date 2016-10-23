using UnityEngine;
using System.Collections;

public class Item : InteractableObjects {

	public bool Weapon;

	public override void Use ()
	{
		if (Weapon) {
			GetComponent<Animator> ().SetTrigger ("Attack");
		}
	}
}
