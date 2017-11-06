using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakText : MonoBehaviour
{

	public Text streakText;
	public Turret turretScript;

	// Use this for initialization
	void Start ()
	{
		streakText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		streakText.text = "streak: " + turretScript.streakCounter;
	}
}
