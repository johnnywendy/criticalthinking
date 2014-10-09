using UnityEngine;
using System.Collections;

public class NPCAIMovement : MonoBehaviour {

	public float zoneRadius = 4;
	public float minWait = 2.0f;
	public float maxWait = 10.0f;

	private SphereCollider zone;
	private AirmenAnimator anim;
	private NavMeshAgent agent;
	private bool reachedDestination = true;
	private Vector3 targetPos;
	private bool inRoutine = false;
	private bool shouldWait = false;
	private bool isTalking = false;
	private GameObject locationPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<AirmenAnimator> ();
		agent = GetComponent<NavMeshAgent> ();
		GameObject zoneObj = Instantiate(Resources.Load("NPCZone", typeof(GameObject))) as GameObject;
		zoneObj.transform.position = transform.position;
		zone = zoneObj.GetComponent<SphereCollider> ();
		zone.radius = zoneRadius;
		zone.enabled = false;

		locationPoint = Instantiate(Resources.Load("LocationPoint", typeof(GameObject))) as GameObject;
		locationPoint.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!inRoutine && !isTalking) {
			inRoutine = true;
			if (shouldWait)
				StartCoroutine("Wait", Random.Range(minWait,maxWait));
			else
				WalkToRandomLocation();
		}
		else {
			if (!reachedDestination) {
				if (Vector3.Distance(targetPos,gameObject.transform.position) < 0.8f) {
					inRoutine = false;
					shouldWait = true;
					reachedDestination = true;
					anim.SetAnimState("Idle");
					targetPos = gameObject.transform.position;
					agent.SetDestination(targetPos);
				}
			}
		}
	}

	public void StartTalking() {
		targetPos = gameObject.transform.position;
		agent.SetDestination(targetPos);
		isTalking = true;
		inRoutine = false;
		shouldWait = true;
		reachedDestination = true;
		StartCoroutine("StartAnimating", 2.4f);
	}

	public void StopTalking() {
		isTalking = false;
		anim.SetAnimState("Idle");
	}

	IEnumerator StartAnimating(float delay) {
		yield return new WaitForSeconds(delay);
		anim.SetAnimState("Talk");
		inRoutine = false;
		shouldWait = false;
	}

	IEnumerator Wait(float delay) {
		yield return new WaitForSeconds(delay);
		inRoutine = false;
		shouldWait = false;
	}

	void WalkToRandomLocation() {
		float x = Random.Range(zone.transform.position.x - zone.radius, zone.transform.position.x + zone.radius);
		float z = Random.Range(zone.transform.position.z - zone.radius, zone.transform.position.z + zone.radius);
		targetPos = new Vector3 (x, transform.position.y, z);
		locationPoint.transform.position = new Vector3(targetPos.x,targetPos.y+0.001f,targetPos.z);
		NavMeshHit hit;
		LayerMask layerMask = ~(1 << 2);
		NavMesh.SamplePosition (targetPos, out hit, zoneRadius, layerMask);
		targetPos = hit.position;
		agent.SetDestination(hit.position);
		locationPoint.transform.position = new Vector3(hit.position.x,hit.position.y+0.001f,hit.position.z);
		locationPoint.SetActive (true);
		locationPoint.GetComponent<TextureAnimator>().StartAnimating();
		reachedDestination = false;
		anim.SetAnimState("Walk");
	}
}
