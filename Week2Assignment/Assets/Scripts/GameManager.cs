using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public int score;
	public int spawnSpeed;
	
	public static GameManager Instance;

	// Use this for initialization
	void Start ()
	{
		Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
