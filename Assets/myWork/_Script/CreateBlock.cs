using UnityEngine;
using System.Collections;

public class CreateBlock : MonoBehaviour {
	public GameObject BlockObject;
	float blockIntervalTime;
	float blockIntervalBase = 0.8f;
	int totalBlockCount;
	int interval1UPBlockCreate = 5;

	// Use this for initialization
	void Start () {
		blockIntervalTime = 0;
		totalBlockCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Main Camera").GetComponent<GameControl>().gameFlag != 2) {
			return;
		} 
				
		blockIntervalTime += Time.deltaTime;
		if (blockIntervalTime > blockIntervalBase) {
			blockIntervalTime = 0;
			createBlock();
		}
	}
	
	void createBlock() {
		totalBlockCount += 1;

		float x = Random.Range(-12, 12);
		float y = 20;
		float z = Random.Range(15, 35);
		float quaternion = Random.Range(0, 180);
		GameObject block = Instantiate(BlockObject, new Vector3(x, y, z), Quaternion.Euler(0, quaternion, 0)) as GameObject;

		// スコア2で一つ1UPブロック作成
		if (totalBlockCount % interval1UPBlockCreate == 0 || totalBlockCount == 2) {
			block.GetComponent<BlockControl>().type = 2;
			block.GetComponent<Renderer>().material.color =  new Color(1f, 0.84f, 0f); // GOLD
		} else {
			block.GetComponent<BlockControl>().type = 1;
		}
	}
}
