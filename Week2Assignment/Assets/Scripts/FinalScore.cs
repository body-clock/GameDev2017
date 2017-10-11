using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
	private Text finalScoreText;

	// Use this for initialization
	void Start ()
	{
		finalScoreText = GetComponent<Text>();
	}

	private void Update()
	{
		finalScoreText.text = "your score was: " + GameManager.Instance.score;
	}
}
