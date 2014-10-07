using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	public Texture2D box1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width/2 -520, Screen.height - 110, 1040, 100),"");

		for (int a =-5; a<5; ++a) {
			GUI.Box (new Rect(Screen.width/2 + a*100,Screen.height-100, 100, 80),box1);
		}
	}
}
