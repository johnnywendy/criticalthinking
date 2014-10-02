using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IKLimbCtrl : MonoBehaviour 
{	
	protected Animator animator;
	
	public bool ikActive = false;
	public float leftHandWeight = 1.0f;
	public float rightHandWeight = 1.0f;
	public Transform rightFootObj = null;
	public Transform leftFootObj = null;
	public Transform rightHandObj = null;	
	public Transform leftHandObj = null;
	public Transform bodyObj = null;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) 
		{	
			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) 
			{	
				//weight = 1.0 for the right hand means position and rotation will be at the IK goal (the place the character wants to grab)
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,rightHandWeight);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,rightHandWeight);

				animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,leftHandWeight);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,leftHandWeight);

				animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,1.0f);
				animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,1.0f);

				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1.0f);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,1.0f);

				//set the position and the rotation of the right hand where the external object is
				if(rightHandObj != null) 
				{
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
				}

				if(leftHandObj != null) 
				{
					animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
				}


				if(rightFootObj != null) 
				{
					animator.SetIKPosition(AvatarIKGoal.RightFoot,rightFootObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightFoot,rightFootObj.rotation);
				}

				if(leftFootObj != null) 
				{
					animator.SetIKPosition(AvatarIKGoal.LeftFoot,leftFootObj.position);
					animator.SetIKRotation(AvatarIKGoal.LeftFoot,leftFootObj.rotation);
				}

				if(bodyObj != null)
				{
					animator.bodyPosition = bodyObj.position;
					animator.bodyRotation = bodyObj.rotation;
				}
			}
			
			//if the IK is not active, set the position and rotation of the hand back to the original position
			else 
			{          
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 

				animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0); 

				animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,0);    

				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,0);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,0);   

			}
		}
	}    
}
