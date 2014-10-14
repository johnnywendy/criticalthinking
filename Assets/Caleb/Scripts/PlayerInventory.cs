using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{

		public int itemPickupDistance;
		public Transform character;
		public Texture2D box1;

		private Sprite[] playerinventory = new Sprite[10];
		private int itemsHeld = 0;


		

		void Start ()
		{
				playerinventory.Initialize ();
		}


		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.E)) {

						Collider2D itemcollider = Physics2D.OverlapCircle (character.position, itemPickupDistance);
						Item i = itemcollider.GetComponent<Item> ();
						addItem (i.PickUp ());
				}

		}

		private void addItem (Sprite i)
		{
				//CURRENTLY THIS WILL DELETE AN ITEM IF ITS PICKED UP WHILE THE PLAYER HAS 10 ITEMS
				// NEED TO IMPLEMENT LATER
				if (itemsHeld < 10) {
						playerinventory [itemsHeld] = i;

				}
		}

		void OnGUI ()
		{
				GUI.Box (new Rect (Screen.width / 2 - 520, Screen.height - 110, 1040, 100), "");

				for (int a =-5; a<5; ++a) {
						GUI.Box (new Rect (Screen.width / 2 + a * 100, Screen.height - 100, 100, 80), box1);
						GUI.Label (new Rect (Screen.width / 2 + a * 100, Screen.height - 100, 100, 80), playerinventory [a + 5].texture);
				}
		}
}
