﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameMode: MonoBehaviour {

	//int totalBlock = 84;

	// for debug
	int totalBlock = 2;

	public GameObject winPanel;
	public GameObject overPanel;
	public GameObject ball; 
	public GameObject paddle;
	public GameObject retryButton;
	public GameObject shareButton;

	// Use this for initialization
	void Start () {
		// to stay "Screen ON"
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		// set objects
		winPanel = GameObject.Find("Canvas/WinParent/WinPanel");
		winPanel.SetActive (false);
		overPanel = GameObject.Find("Canvas/OverParent/OverPanel");
		overPanel.SetActive (false);
		ball = GameObject.Find ("Ball");
		paddle = GameObject.Find ("Paddle");
		retryButton = GameObject.Find ("RetryButton");
		retryButton.SetActive (false);
		shareButton = GameObject.Find ("ShareButton");
		shareButton.SetActive (false);

		Time.timeScale = 1;

		// set blocks
		int i, j;

		for (i = 0; i < 21; i++) {
			//for (j = 1; j < 8; j++) {
			for(j = 1; j < 2; j++){
				Vector3 pos = Vector3.zero;
				pos.x = (float)i * 0.24f - 2.4f;
				pos.y = (float)j * 0.24f;


				/*if (i >= 1 && i <= 5) {
					if (i == 1 && j == 1 ||
					    i == 1 && j == 7 ||
					    i == 5 && j == 1 ||
					    i == 5 && j == 7 ||
					    i == 3 && j >= 3 && j <= 5) {
						continue;
					} else {
						Instantiate (Resources.Load ("Prefabs/Block_blue"), pos, Quaternion.identity);
					}
				} else if (i >= 7 && i <= 11) {
					if (i == 11 && j == 7 ||
						i == 11 && j == 3 ||
						i == 9 && j == 5 ||
						i >= 9 && i <= 11 && j >= 1 && j <= 2) {
						continue;
					} else {
						Instantiate (Resources.Load ("Prefabs/Block_orange"), pos, Quaternion.identity);
					}
				} else if (i >= 13 && i <= 14) {
					Instantiate (Resources.Load ("Prefabs/Block_yellow"), pos, Quaternion.identity);
				} else if (i >= 16 && i <= 19 && j >= 1 && j <= 5) {
					if (i == 16 && j == 5 ||
					    i == 16 && j == 1 ||
					    i >= 18 && i <= 19 && j == 3) {
						continue;
					} else {
						Instantiate (Resources.Load ("Prefabs/Block_green"), pos, Quaternion.identity);
					}
				} else {
					continue;
				}*/


				// for debug
				if (i >= 13 && i <= 14) {
					Instantiate (Resources.Load ("Prefabs/Block_yellow"), pos, Quaternion.identity);
				}
			}
		}


	}
	
	// Update is called once per frame
	void Update () {

		// back key -> return to main scene
		if(Application.platform == RuntimePlatform.Android) {
			if(Input.GetKey(KeyCode.Escape)) {
				SceneManager.LoadScene ("main");
			}
		}
	}

	/**
	 * Block counter down -> to check remain blocks
	 * if all blocks broken, player wins
	 */
	void CounterDown() {
		totalBlock--;

		if (totalBlock == 0) {
			Win ();
		}
	}

	/**
	 * case WIN
	 */
	void Win() {
		Debug.Log("WIN");

		// game pause
		Time.timeScale = 0;

		// message on - retry, quit, back key(quit), share
		winPanel.SetActive (true);
		shareButton.SetActive (true);
		retryButton.SetActive (true);
	}

	/**
	 * case LOSE - timeover / ball down
	 */
	void GameOver() {
		Debug.Log("GAME OVER");

		// game pause
		Time.timeScale = 0;

		// message on - retry, quit, back key(quit)
		overPanel.SetActive(true);
		retryButton.SetActive (true);
	}
}
