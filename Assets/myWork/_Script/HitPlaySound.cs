using UnityEngine;
using System.Collections;

public class HitPlaySound : MonoBehaviour {
	public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
