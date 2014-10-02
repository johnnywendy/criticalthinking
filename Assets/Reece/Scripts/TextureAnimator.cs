using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureAnimator : MonoBehaviour {

	public float fps = 30;
	public List<Texture> textures;

	private float rate = 0.0f;
	private bool shouldAnimate = false;
	private int index = 0;

	// Animates through the list of textures at the set fps

	void Start() {
		rate = 1/fps;
	}
	
	public void StartAnimating() {
		GetComponent<MeshRenderer> ().material.mainTexture = textures [index];
		shouldAnimate = true;
		StartCoroutine("NextTexture", rate); 
	}

	public void StopAnimating() {
		shouldAnimate = false;
		index = 0;
	}

	IEnumerator NextTexture(float delay) {
		yield return new WaitForSeconds(delay);
		if (shouldAnimate) {
			index++;
			if (index > textures.Count-1)
				index = 0;
			GetComponent<MeshRenderer> ().material.mainTexture = textures [index];
			StartCoroutine("NextTexture", rate);
		}
	}

}
