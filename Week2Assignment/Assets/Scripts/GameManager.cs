using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //not really using this script, as the only thing it does is handle score
	//which I don't have yet
	public int score = 0;
	public int spawnSpeed;
	
	//instantiating singleton
	public static GameManager Instance;

	void Start ()
	{
		//setting it to itself
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
