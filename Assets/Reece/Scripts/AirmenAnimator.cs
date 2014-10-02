using UnityEngine;
using System.Collections;

public class AirmenAnimator : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Allows you to specify an animation state with one of the given strings and this function will set everything up for you
	public void SetAnimState(string state) {
		switch (state) {
		case "Idle":
			anim.SetBool("TV",false);
			anim.SetBool("Talk",false);
			anim.SetBool("Idle",true);
			anim.SetBool("Walk",false);
			break;
		case "Walk":
			anim.SetBool("TV",false);
			anim.SetBool("Talk",false);
			anim.SetBool("Idle",false);
			anim.SetBool("Walk",true);
			break;
		case "Talk":
			anim.SetBool("TV",false);
			anim.SetBool("Idle",false);
			anim.SetBool("Talk",true);
			anim.SetBool("Walk",false);
			break;
		case "TV":
			anim.SetBool("Talk",false);
			anim.SetBool("Idle",false);
			anim.SetBool("TV",true);
			anim.SetBool("Walk",false);
			break;
		default:
			anim.SetBool("Idle",true);
			anim.SetBool("Walk",false);
			break;
		}
	}
}
