using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]  

public class IKLookAt : MonoBehaviour 
{	
	protected Animator avatar;
	protected IKActivator activator;
	public float lerpWeight;
	
	public bool ikActive = false;
	public Transform lookAtObj = null;

	public float lookAtWeight = 0.0f;

	void Start() 
	{
		avatar = GetComponent<Animator>();
		activator = GetComponent<IKActivator>();
	}

	public void Enable()
	{
		avatar = avatar ?? GetComponent<Animator>();
		this.enabled = true;
		ikActive = true;
	}

	public void Disable()
	{
		this.enabled = false;
		ikActive = false;
	}

	void OnAnimatorIK(int layerIndex)
	{	
		if(avatar)
		{
			//if IK is active, continuously sets the look at weight based on IKActivator lerpedLookWeight
			if(ikActive)
			{
				avatar.SetLookAtWeight(lerpWeight,0.15f, 0.75f, 1.0f, 0.5f);

				if(lookAtObj != null)
				{
					avatar.SetLookAtPosition(lookAtObj.position);
				}	
			}

			else
			{	
				avatar.SetLookAtWeight(1.0f);
			}
		}
	}

	void Update () 
	{
		if(avatar)
		{
			if(!ikActive)
			{
				if(lookAtObj != null)
				{
					lookAtObj.position = avatar.bodyPosition + avatar.bodyRotation * new Vector3(0,0.5f,1);
				}				
			}
		}		
	}   		  
}
