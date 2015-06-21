using UnityEngine;
using System.Collections;

public class BallControll : MonoBehaviour {
	int startSpeed = 18;
	float acceleration = 1.3f;
	float speepUpIntervalTime;
	float speedUpPace = 3f;

	// Use this for initialization
	void Start () {
		int x = Random.Range(-20, 20);

		GetComponent<Rigidbody>().AddForce(
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
			GetComponent<Rigidbody>().velocity *= acceleration;
		}
	}
}
