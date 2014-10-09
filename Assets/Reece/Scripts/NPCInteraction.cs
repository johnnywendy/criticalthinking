using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCInteraction : MonoBehaviour {

	public BoxCollider interactionZone;

	private bool canTalk = false;
	private bool isTalking = false;
	private List<GameObject> objects = new List<GameObject> {};
	public AirmenAnimator anim;
	private GameObject closest;

	// Use this for initialization
	void Start () {
		anim = GetComponent<AirmenAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		// If 'E' is pressed, start talking to the nearest npc
		if (Input.GetKeyDown(KeyCode.E) && canTalk && !isTalking) {
			isTalking = true;
			closest = objects[0];
			foreach (GameObject obj in objects) {
				if (Vector3.Distance(transform.position,closest.transform.position) > Vector3.Distance(transform.position,obj.transform.position)) {
					closest = obj;
				}
			}
			closest.transform.LookAt(transform.position);
			closest.GetComponent<NPCAIMovement>().StartTalking();
			transform.LookAt(closest.transform.position);
			anim.SetAnimState("Talk");
		}
		else if (Input.GetKeyDown(KeyCode.E) && isTalking) {
			closest.GetComponent<NPCAIMovement>().StopTalking();
			isTalking = false;
			anim.SetAnimState("Idle");
		}
	}

	// If close to a person add them to the possible interactions list
	void OnTriggerEnter(Collider other) {
		if (other.tag == "NPC") {
			canTalk = true;
			objects.Add(other.gameObject);
		}
	}

	// If they leave the zone of interaction remove them from the list
	void OnTriggerExit(Collider other) {
		if (other.tag == "NPC")
			objects.Remove (other.gameObject);
		if (objects.Count <= 0)
			canTalk = false;
	}
}
