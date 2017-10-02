using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	private Text scoreTextVisual;

	// Use this for initialization
	void Start ()
	{
		scoreTextVisual = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreTextVisual.text = "score: " + GameManager.Instance.score;
	}
}
