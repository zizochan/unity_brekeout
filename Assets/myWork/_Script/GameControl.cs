using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {
	public GameObject GameStartBtn;
	public GameObject ResetBtn;	
	public GameObject ballObject;
	public Text scoreText;
	public Text gameLevelText;
	public int score;
	public int restBall; 
	public int gameLevel;

	// 1:タイトル画面 2:プレイ中 3:ゲームオーバー
	public int gameFlag;

	// Use this for initialization
	void Start () {
		gameFlag = 1;
		score = 0;
		restBall = 0;
		gameLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void PushGameStartButton() {
		if (gameFlag == 1) {
			GameStartBtn.SetActive(false);
			gameFlag = 2;
			createBall();
		}
	}
	
	public void PushResetButton() {
		Application.LoadLevel("gameScene");
	}
	
	public void updateScore() {
		score += 1;
		scoreText.text = "Score: " + score;
		if (score % 10 == 0) {
			updateGameLevel();
		}
	}
	
	void updateGameLevel() {
		gameLevel += 1;
		gameLevelText.text = "Level: " + gameLevel;
		updateRacketStatus();
	}

	void updateRacketStatus() {
		GameObject racket = GameObject.Find("racket");
		float defaultRacketWidth = 10f;
		float racketWidth = defaultRacketWidth - (gameLevel / 2);
		if (racketWidth < 1) {
			racketWidth = 1f;
		}
		racket.transform.localScale = new Vector3(racketWidth, 1, 1);
	}
	
	public void createBall() {
		Instantiate(ballObject);
		restBall += 1;
	}
	
	public void destroyBall() {
		restBall -= 1;
		if (restBall <= 0) {
			gameFlag = 3;
			ResetBtn.SetActive(true);
		}
	}
}
