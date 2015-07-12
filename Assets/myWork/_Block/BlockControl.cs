using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
	// 1:normal 2:ball発射
	public int type;
	float dropSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Drop();
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
	
	// rigidbody使いたくないので、自作スクリプトで落下させる
	void Drop() {
		if (transform.localPosition.y > 0) {
			transform.Translate(Vector3.down * dropSpeed);
			if (transform.localPosition.y < 0) {
				transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
			}
		}
	}
}
