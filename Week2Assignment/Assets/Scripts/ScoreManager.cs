using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	
	//simple script to control the text in our final score screen
	public Text finalScoreText;
	public Text highScoreText;

	private bool hasUpdatedHighScore = false;

	void Awake ()
	{
		finalScoreText = GameObject.FindGameObjectWithTag("Final Score").GetComponent<Text>();
		highScoreText = GameObject.FindGameObjectWithTag("High Score").GetComponent<Text>();
	}

	private void Update()
	{
		finalScoreText.text = "your score was: " + GameManager.Instance.score;
		highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

		if (!hasUpdatedHighScore)
		{
			UpdateHighScore();
			hasUpdatedHighScore = true;
		}
	}

	private void UpdateHighScore()
	{
		if (GameManager.Instance.score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", GameManager.Instance.score);
		}
	}
}
