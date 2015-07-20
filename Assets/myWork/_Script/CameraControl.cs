using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	private Vector3 difference;
	private bool reverseCameraFlag = false;

	// Use this for initialization
	void Start () {
		GameObject mainCamera = GameObject.Find("Main Camera");
		if (mainCamera.GetComponent<GameControl>().reverseCameraFlag) {
			reverseCameraFlag = true;
		}
		if (reverseCameraFlag) {
			transform.localPosition = new Vector3(0, 5, 20);
			transform.localRotation = Quaternion.Euler(25, 180, 0);
			difference = transform.localPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (reverseCameraFlag) {
			if (GameObject.Find("ball(Clone)") == true) {
				Vector3 startVec = GameObject.Find("ball(Clone)").transform.localPosition;
				transform.localPosition = new Vector3((startVec.x / 3) + difference.x, startVec.y + difference.y, startVec.z + difference.z);
			}
		}
	}
}
