using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public Camera camera;
	public Transform target;
	public Transform angleTracker;
	public float distanceFromTarget = 0.0f;
	public float heightRelativeToTarget = 0.0f;
	public float startingRotationX = 0.0f;
	public float xRotateSpeed = 5.0f;
	public float yRotateSpeed = 1.0f;

	private bool isRotating = false;

	// DONT WORRY BOUT THIS SHI IMMA CHANGE IT YO

	// Use this for initialization
	void Start () {
		transform.position = target.position + (-distanceFromTarget * target.forward.normalized);
		transform.position = new Vector3 (transform.position.x, transform.position.y + heightRelativeToTarget, transform.position.z);
		lookAtTarget ();
		angleTracker.transform.position = new Vector3 (target.position.x, 1.6f, target.position.z);
		angleTracker.parent = target;
		transform.parent = target;
	}
	
	// Update is called once per frame
	void Update () {
		angleTracker.eulerAngles = new Vector3(0.0f,camera.transform.localEulerAngles.y,0.0f);
		if (Input.GetMouseButtonDown(1))
			isRotating = true;
		if (Input.GetMouseButtonUp(1))
			isRotating = false;
		if (isRotating) {
			//Debug.Log (angleTracker.forward + " - " + target.forward);
			camera.transform.RotateAround(target.position,target.up,-Input.GetAxis("Mouse X")*xRotateSpeed);
			camera.transform.RotateAround(target.position,angleTracker.right,Input.GetAxis("Mouse Y")*yRotateSpeed);
		}
	}
	
	void lookAtTarget() {
		camera.transform.LookAt(target);
		camera.transform.eulerAngles = new Vector3 (startingRotationX, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);
	}
}
