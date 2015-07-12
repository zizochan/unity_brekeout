using UnityEngine;
using System.Collections;

public class BallControll : MonoBehaviour {
	int startSpeed = 16;
	float acceleration = 1.2f;
	float speepUpIntervalTime;
	float speedUpPace = 3f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		int x = Random.Range(-20, 20);
		rb = GetComponent<Rigidbody>();

		rb.AddForce(
			new Vector3 (x, 0, getBallStartSpeed()),
			ForceMode.VelocityChange
		);
		speepUpIntervalTime = 0;
	}
	
	float getBallStartSpeed() {
		float speed = startSpeed;
		int gameLevel = GameObject.Find("Main Camera").GetComponent<GameControl>().gameLevel;
		speed += gameLevel;
		return speed;
	}

	// Update is called once per frame
	void Update () {
		speepUpIntervalTime += Time.deltaTime;
		if (speepUpIntervalTime > speedUpPace) {
			speepUpIntervalTime = 0;
			rb.velocity *= acceleration;
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("wall")) {
			CollisionWithWall();
		}
	}
	
	// 壁との衝突処理。適度に曲げる
	void CollisionWithWall() {
		int z = Random.Range(-1, -5);
		int x = Random.Range(-5, -10);
		rb.AddRelativeForce(
			new Vector3 (x, 0, z),
			ForceMode.VelocityChange
		);
	}
}
