using UnityEngine;
using System.Collections;

public class RacketControll : MonoBehaviour {
	private float Accel = 2500.0f;
	private bool reverseCameraFlag = false;

	// Use this for initialization
	void Start () {
		GameObject mainCamera = GameObject.Find("Main Camera");
		if (mainCamera.GetComponent<GameControl>().reverseCameraFlag) {
			reverseCameraFlag = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float speed = Input.GetAxisRaw( "Horizontal" ) * Accel;
		if (speed != 0f) {
			if (reverseCameraFlag) {
				speed *= -1;
			}
			GetComponent<Rigidbody>().AddForce(
				transform.right * speed,
				ForceMode.Impulse
			);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("ball")) {
			col.gameObject.GetComponent<Rigidbody>().AddForce(
				new Vector3 (100, 0, 0)
			);
		};
	}
}
