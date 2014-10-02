using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public Camera camera;

	private AirmenAnimator anim;
	private NavMeshAgent agent;
	private bool reachedDestination = true;
	private Vector3 targetPos;
	private GameObject locationPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<AirmenAnimator> ();
		agent = GetComponent<NavMeshAgent> ();
		locationPoint = Instantiate(Resources.Load("LocationPoint", typeof(GameObject))) as GameObject;
		locationPoint.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// if not moving, set new destination on click
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			LayerMask layerMask = ~(1 << 2);
			if (Physics.Raycast(ray, out hit, 1000, layerMask)) {
				if (hit.transform.tag == "Ground") {
					targetPos = hit.point;
					agent.SetDestination(targetPos);
					anim.SetAnimState("Walk");
					reachedDestination = false;
					locationPoint.transform.position = new Vector3(targetPos.x,targetPos.y+0.001f,targetPos.z);
					locationPoint.SetActive (true);
					locationPoint.GetComponent<TextureAnimator>().StartAnimating();
				}
			}
		}
		// if moving, check to see if the destination has been reached
		if (!reachedDestination) {
			if (transform.position.x == targetPos.x && transform.position.z == targetPos.z) {
				locationPoint.GetComponent<TextureAnimator>().StopAnimating();
				locationPoint.SetActive (false);
				reachedDestination = true;
				anim.SetAnimState("Idle");
			}
		}
	}
}
