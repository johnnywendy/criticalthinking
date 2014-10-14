using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
		SpriteRenderer itemSprite;
		Rigidbody2D itemRigid;

		void Start ()
		{		
				itemSprite = GetComponent<SpriteRenderer> ();
				itemRigid = GetComponent<Rigidbody2D> ();
		}

		void Update ()
		{
	
		}

		public Sprite PickUp ()
		{
				Sprite temp = itemSprite.sprite;
				Destroy (itemSprite);
				Destroy (itemRigid);
				return temp;
		}

}

