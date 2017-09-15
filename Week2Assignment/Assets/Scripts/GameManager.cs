using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int score;
	public int spawnSpeed;
	
	public static GameManager Instance;

	void Start ()
	{
		Instance = this;
	}
}
