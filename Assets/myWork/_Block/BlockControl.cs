using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
	// 1:normal 2:ball発射
	public int type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("ball")) {
			GameObject mainCamera = GameObject.Find("Main Camera");
			mainCamera.GetComponent<GameControl>().updateScore();
			if (type == 2) {
				mainCamera.GetComponent<GameControl>().createBall();
			}
			Destroy(gameObject);
		};
	}
}
