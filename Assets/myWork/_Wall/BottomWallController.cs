using UnityEngine;
using System.Collections;

public class BottomWallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("ball")) {
			Destroy(col.gameObject);
			GameObject.Find("Main Camera").GetComponent<GameControl>().destroyBall();
		};
	}
}
