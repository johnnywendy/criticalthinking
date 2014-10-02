using UnityEngine;
using System.Collections;

[RequireComponent(typeof(IKLookAt))]
public class IKActivator : MonoBehaviour 
{
	private IKLookAt ik;

	private GameObject obj;
	public GameObject goalLook;

	private bool ikTriggered = false;
	private bool timeStamped = false;

	private float tempTime = -1.0f;
	private float MaxDist = -1.0f;
	public float lerpedLookWeight = -1.0f;


	void OnTriggerEnter(Collider other) 
	{
		ik = GetComponent<IKLookAt>();

		obj = this.gameObject;
		obj.GetComponent<IKLookAt>().ikActive = true;
		obj.GetComponent<IKLookAt>().lookAtObj = goalLook.transform;
	
		ikTriggered = true;
		tempTime = Time.fixedTime;
		ik.enabled = true;
	}

	void Update()
	{
		if(ikTriggered)
		{
			//if IKLookAt is set active, continously checks Max distance between current GameObject and goalLook
			MaxDist = Vector3.Distance(obj.transform.position, goalLook.transform.position);

			//sets the look weight based on a lerped float value 0.0 - 1.0
			lerpedLookWeight = Mathf.Lerp(0.0f, 1.0f, (Time.time - tempTime) / 0.45f);

			//if goal is moved greater than 3, lerps from 1.0 to 0.0 for a smooth ik transition and deactives script
			if(MaxDist > 3)
			{
				if(lerpedLookWeight > 0)
				{
					if(timeStamped == false)
					{
						tempTime = getCurrentTime();
					}

					lerpedLookWeight = Mathf.Lerp(1.0f, 0.0f, (Time.time - tempTime) / 0.45f);
				}
				if(lerpedLookWeight == 0)
				{
					ikTriggered = false;
					ik.enabled = false;
					timeStamped = false;
					//animation.Stop();
				}
			}
		}
	}

	//gets current time stamp
	float getCurrentTime()
	{
		tempTime = Time.fixedTime;
		timeStamped = true;
		return tempTime;
	}
}