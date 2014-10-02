using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private Transform origTrans;
	private Animator anim;
	private bool worked = false;

	// Use this for initialization
	void Start () {
		origTrans = gameObject.transform;
		anim = gameObject.GetComponent<Animator>();
		Debug.Log("x: " + origTrans.position.x + " y: " + origTrans.position.y + " z: " + origTrans.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if ( anim.GetCurrentAnimatorStateInfo(0).IsName("Working") )
		{
			Debug.Log("working workig working");
			if ( worked )
			{
				Debug.Log("moving back");
				gameObject.transform.position = new Vector3( gameObject.transform.position.x, gameObject.transform.position.y, origTrans.position.z);
				worked = false;
			}
		}
		else
		{
			Debug.Log("finished working");
			worked = true;
		}
	}

//	IEnumerator lerpBack()
//	{
//		Debug.Log("coroutine");
//		Vector3.Lerp(gameObject.transform.position, origTrans.position, Time.deltaTime);
//		yield return true;
//	}
}
