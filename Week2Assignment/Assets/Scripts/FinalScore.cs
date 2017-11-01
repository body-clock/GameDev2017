using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
	
	//simple script to control the text in our final score screen
	private Text finalScoreText;

	void Start ()
	{
		finalScoreText = GetComponent<Text>();
	}

	private void Update()
	{
		finalScoreText.text = "your score was: " + GameManager.Instance.score;
	}
}
