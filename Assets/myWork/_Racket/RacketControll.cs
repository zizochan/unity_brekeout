using UnityEngine;
using System.Collections;

public class RacketControll : MonoBehaviour {
	private float Accel = 3000.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().AddForce(
			transform.right * Input.GetAxisRaw( "Horizontal" ) * Accel,
    		ForceMode.Impulse
		);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("ball")) {
			col.gameObject.GetComponent<Rigidbody>().AddForce(
				new Vector3 (100, 0, 0)
			);
		};
	}
}
